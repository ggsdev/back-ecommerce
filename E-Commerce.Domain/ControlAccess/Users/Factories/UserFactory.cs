using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.DTOs.ViewModels.ControlAccess;

namespace E_Commerce.Domain.ControlAccess.Users.Factories
{
    internal class UserFactory : IUserFactory
    {
        public User Create(CreateUserViewModel body, Info createdInfo)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(body.Password);

            return new User
            {
                Name = body.Name,
                Password = hashedPassword,
                Info = createdInfo,
                Age = body.Age,
                Surname = body.Surname,
            };
        }

        public User Update(User user, UpdateUserViewModel body)
        {
            user.Name = body.Name;
            user.Surname = body.Surname;

            return user;
        }
    }
}
