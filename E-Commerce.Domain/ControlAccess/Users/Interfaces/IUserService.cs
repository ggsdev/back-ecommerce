using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Users;

namespace E_Commerce.Domain.ControlAccess.Users.Interfaces
{
    public interface IUserService
    {
        Task<PaginatedDataDTO<UserDto>> GetAllUsers(FilterQuery queryParams, string requestUrl, User loggedUser);
        Task<UserDto> GetUserById(long id, User loggedUser);
        Task<UserDto> CreateUser(CreateUserViewModel user);
        Task<UserDto> UpdateUser(UpdateUserViewModel body, long id, User loggedUser);
        Task DeleteUser(long id, User loggedUser);
    }
}
