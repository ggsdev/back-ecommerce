using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels;

namespace E_Commerce.Domain.ControlAccess.Users.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAll();
        Task<UserDto> GetById(long id);
        Task<UserDto> Create(UserCreateViewModel user);
        Task Update(UserDto user);
        Task Delete(long id);
    }
}
