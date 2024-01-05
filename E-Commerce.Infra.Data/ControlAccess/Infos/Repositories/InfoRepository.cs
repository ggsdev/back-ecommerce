using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infra.Data.ControlAccess.Infos.Repositories
{
    internal class InfoRepository(DataContext context) : BaseRepository<Info>(context), IInfoRepository
    {
        private readonly DataContext _context = context;

        public async Task<bool> AnyByEmailOrCellphone(string email, string cellphone, int? id = null)
        {
            return await _context.Users
                .Select(x => new
                {
                    x.Id,
                    x.Info.Email,
                    x.Info.Cellphone,
                    x.CreatedAt,
                    x.UpdatedAt
                })
                .Where(user => (EF.Functions.Like(user.Email, email) || EF.Functions.Like(user.Cellphone, cellphone)) && user.Id != id)
               .AnyAsync();
        }

        public async Task<Address?> GetAddressById(int addressId)
        {
            return await _context.Addresses
                .FirstOrDefaultAsync(x => x.Id == addressId);
        }
    }
}
