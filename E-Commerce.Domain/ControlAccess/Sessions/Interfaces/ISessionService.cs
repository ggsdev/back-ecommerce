using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.ControlAccess;

namespace E_Commerce.Domain.ControlAccess.Sessions.Interfaces
{
    public interface ISessionService
    {
        Task<SessionDto> CreateSession(CreateSessionViewModel sessionViewModel);
    }
}
