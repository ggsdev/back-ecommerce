using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Shared;

namespace E_Commerce.Domain.ControlAccess.Users.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetAll(FilterQuery queryParam);
        Task<User?> GetById(int id);
        Task<User?> GetByEmail(string email);
    }
}
