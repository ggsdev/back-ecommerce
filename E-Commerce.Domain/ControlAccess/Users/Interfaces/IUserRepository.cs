using E_Commerce.Shared;
using E_Commerce.Domain.ControlAccess.Users.Entities;

namespace E_Commerce.Domain.ControlAccess.Users.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetAll(FilterQuery queryParam);
        Task<User?> GetById(long id);
        Task<User?> GetByEmail(string email);
    }
}
