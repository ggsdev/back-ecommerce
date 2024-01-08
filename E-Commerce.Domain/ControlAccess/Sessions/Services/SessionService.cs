using AutoMapper;
using E_Commerce.Domain.ControlAccess.Sessions.Entities;
using E_Commerce.Domain.ControlAccess.Sessions.Interfaces;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.ControlAccess;
using E_Commerce.Shared;
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

            var token = GenerateJwtToken(userByEmail);

            await _repository.Add(token);

            await _repository.Save();

            var tokenDto = _mapper.Map<SessionDto>(token);

            return tokenDto;
        }

        private static Session GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.IsAdmin ? Constants.ADMIN : Constants.USER)

            }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new Session
            {
                User = user,
                Token = tokenHandler.WriteToken(token),
                ExpirationDate = token.ValidTo
            };
        }
    }
}
