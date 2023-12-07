using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;

namespace E_Commerce.Infra.Data.ControlAccess.Users.Repositories
{
    internal class UserRepository(DataContext context) : BaseRepository<User>(context), IUserRepository
    {
        private readonly DataContext _context = context;

    }
}
