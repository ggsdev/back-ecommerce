using E_Commerce.Shared;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.ControlAccess;

namespace E_Commerce.Domain.ControlAccess.Users.Interfaces
{
    public interface IUserService
    {
        Task<PaginatedDataDTO<UserDto>> GetAllUsers(FilterQuery queryParams, string requestUrl, User loggedUser);
        Task<UserDto> GetUserById(int id, User loggedUser);
        Task<UserDto> CreateUser(CreateUserViewModel user);
        Task<UserDto> UpdateUser(UpdateUserViewModel body, int id, User loggedUser);
        Task DeleteUser(int id, User loggedUser);
    }
}
