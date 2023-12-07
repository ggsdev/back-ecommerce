using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infra.Data.ControlAccess.Infos.Repositories
{
    internal class InfoRepository(DataContext context) : BaseRepository<Info>, IInfoRepository
    {
        private readonly DataContext _context = context;

        public async Task<bool> AnyByEmailOrCellphone(string email, string cellphone, long? id = null)
        {
            return await _context.Users
                .Select(x => new
                {
                    x.Id,
                    x.Info.Email,
                    x.Info.Cellphone,
                })
                .Where(user => (EF.Functions.Like(user.Email, email) || EF.Functions.Like(user.Cellphone, cellphone)) && user.Id != id)
               .AnyAsync();
        }
    }
}
