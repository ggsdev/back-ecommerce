using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Sessions.Entities;
using E_Commerce.Domain.ControlAccess.Sessions.Interfaces;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Sessions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_Commerce.Domain.ControlAccess.Sessions.Services
{
    internal class SessionService(ISessionRepository sessionRepository, IUserRepository userRepository) : ISessionService
    {
        private readonly ISessionRepository _repository = sessionRepository;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<SessionDto> CreateSession(CreateSessionViewModel body)
        {
            var userByEmail = await _userRepository.GetByEmail(body.Email)
                ?? throw new Exception("Invalid email or password");

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(body.Password, userByEmail.Password);

            if (isPasswordValid is false)
                throw new Exception("Invalid email or password");

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

        public Task DeleteSession(string token)
        {
            throw new NotImplementedException();
        }

        public Task<SessionDto> GetSessionByToken(string token)
        {
            throw new NotImplementedException();
        }

        private static SessionDto GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
            }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new SessionDto
            {
                Token = tokenHandler.WriteToken(token),
                ExpirationDate = token.ValidTo
            };
        }
    }
}
