using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.ControlAccess;
using E_Commerce.Shared;

namespace E_Commerce.Domain.ControlAccess.Users.Interfaces
{
    public interface IUserService
    {
        Task<PaginatedDataDTO<UserDto>> GetAllUsers(FilterQuery queryParams, string requestUrl);
        Task<UserDto> GetUserById(int id);
        Task<UserDto> CreateUser(CreateUserViewModel user);
        Task<UserDto> UpdateUser(UpdateUserViewModel body, int id);
        Task DeleteUser(int id);
    }
}
