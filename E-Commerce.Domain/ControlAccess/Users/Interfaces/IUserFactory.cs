using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.DTOs.ViewModels.ControlAccess;

namespace E_Commerce.Domain.ControlAccess.Users.Interfaces
{
    public interface IUserFactory
    {
        User Create(CreateUserViewModel body, Info createdInfo);
        User Update(User user, UpdateUserViewModel body);
    }
}
