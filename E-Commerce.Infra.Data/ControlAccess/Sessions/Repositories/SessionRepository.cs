using E_Commerce.Domain.ControlAccess.Sessions.Entities;
using E_Commerce.Domain.ControlAccess.Sessions.Interfaces;

namespace E_Commerce.Infra.Data.ControlAccess.Sessions.Repositories
{
    internal class SessionRepository(DataContext context) : BaseRepository<Session>(context), ISessionRepository
    {
        private readonly DataContext _context = context;
    }
}
