using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.DTOs.ViewModels.Users;

namespace E_Commerce.Domain.ControlAccess.Users.Interfaces
{
    internal interface IUserFactory
    {
        User Create(CreateUserViewModel body, Info createdInfo);
        User Update(User user, UpdateUserViewModel body);
    }
}
