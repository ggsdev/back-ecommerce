using AutoMapper;
using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Sessions.Entities;
using E_Commerce.Domain.ControlAccess.Sessions.Interfaces;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.ControlAccess;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_Commerce.Domain.ControlAccess.Sessions.Services
{
    internal class SessionService(ISessionRepository sessionRepository, IUserRepository userRepository, IMapper mapper) : ISessionService
    {
        private readonly ISessionRepository _repository = sessionRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<SessionDto> CreateSession(CreateSessionViewModel body)
        {
            var userByEmail = await _userRepository.GetByEmail(body.Email)
                ?? throw new Exception("Invalid email or password");

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(body.Password, userByEmail.Password);

            if (isPasswordValid is false)
                throw new Exception("Invalid email or password");

            if (userByEmail.Session is not null && userByEmail.Session.ExpirationDate > DateTime.Now)
            {
                var sessionDto = _mapper.Map<SessionDto>(userByEmail.Session);

                return sessionDto;
            }

            if (userByEmail.Session is not null)
                _repository.Delete(userByEmail.Session);

            var tokenDto = GenerateJwtToken(userByEmail);

            var createdSession = new Session
            {
                Token = tokenDto.Token,
                User = userByEmail,
                ExpirationDate = tokenDto.ExpirationDate
            };

            await _repository.Add(createdSession);

            await _repository.Save();

            return tokenDto;
        }

        private static SessionDto GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new SessionDto
            (
                tokenHandler.WriteToken(token),
                token.ValidTo
            );
        }
    }
}
