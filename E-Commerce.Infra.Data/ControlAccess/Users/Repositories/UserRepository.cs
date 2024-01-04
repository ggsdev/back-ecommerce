using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce.Infra.Data.ControlAccess.Users.Repositories
{
    internal class UserRepository(DataContext context) : BaseRepository<User>(context), IUserRepository
    {
        private readonly DataContext _context = context;

        public async Task<List<User>> GetAll(FilterQuery paramQuery)
        {
            IQueryable<User> query = _context.Users
                .Include(x => x.Info)
                    .ThenInclude(x => x.Address);

            if (!string.IsNullOrWhiteSpace(paramQuery.Search))
            {
                query = query
                    .Where(x => EF.Functions.Like(x.Name, paramQuery.Search)
                    || EF.Functions.Like(x.Surname, paramQuery.Search)
                    );
            }

            if (!string.IsNullOrWhiteSpace(paramQuery.SortColumn))
            {
                if (string.IsNullOrWhiteSpace(paramQuery.SortOrder) || paramQuery.SortOrder.Equals(Constants.ASC_SORT_ORDER, StringComparison.OrdinalIgnoreCase))
                {
                    query = query.OrderBy(GetSortProperty(paramQuery.SortColumn));
                }
                else if (paramQuery.SortOrder.Equals(Constants.DESC_SORT_ORDER, StringComparison.OrdinalIgnoreCase))
                {
                    query = query.OrderByDescending(GetSortProperty(paramQuery.SortColumn));
                }
            }
            else
            {
                query = query.OrderBy(x => x.Id);
            }

            return await query
                .Select(x => new User
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Age = x.Age,
                    Info = new Info
                    {
                        Id = x.Info.Id,
                        CreatedAt = x.Info.CreatedAt,
                        Cellphone = x.Info.Cellphone,
                        Email = x.Info.Email,
                        Address = x.Info.Address
                    },
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                })
                .AsNoTracking()
                .Skip((paramQuery.PageNumber - 1) * paramQuery.PageSize)
                .Take(paramQuery.PageSize)
                .ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _context
                .Users
                .Include(x => x.Info)
                    .ThenInclude(x => x.Address)
                .Where(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        private static Expression<Func<User, object>> GetSortProperty(string propertyName)
        {
            Expression<Func<User, object>> keySelector = propertyName.ToLower() switch
            {
                "name" => user => user.Name,
                "surname" => user => user.Surname,
                "age" => user => user.Age,
                "email" => user => user.Info.Email,
                "cellphone" => user => user.Info.Cellphone,
                _ => user => user.Id
            };

            return keySelector;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context
                .Users
                .Include(x => x.Session)
                .Include(x => x.Info)
                .Where(user => EF.Functions.Like(user.Info.Email, email))
                .FirstOrDefaultAsync();
        }
    }
}
