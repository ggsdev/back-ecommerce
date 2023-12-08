using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Sessions;

namespace E_Commerce.Domain.ControlAccess.Sessions.Interfaces
{
    public interface ISessionService
    {
        Task<SessionDto> CreateSession(CreateSessionViewModel sessionViewModel);
        Task<SessionDto> GetSessionByToken(string token);
        Task DeleteSession(string token);
    }
}
