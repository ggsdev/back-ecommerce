using E_Commerce.Shared;
using E_Commerce.Domain.Product.SubCategories.Entities;
using E_Commerce.Domain.Product.SubCategories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce.Infra.Data.Product.SubCategories.Repositories
{
    internal class SubCategoryRepository(DataContext context) : BaseRepository<SubCategory>(context), ISubCategoryRepository
    {
        private readonly DataContext _context = context;
        public async Task<bool> AnyByName(string name, long? id = null)
        {
            return await _context.SubCategories
                    .Where(category => EF.Functions.Like(category.Name, name) && category.Id != id)
                    .AnyAsync();
        }

        public async Task<List<SubCategory>> GetAll(FilterQuery paramQuery)
        {
            IQueryable<SubCategory> query = _context.SubCategories;

            if (!string.IsNullOrWhiteSpace(paramQuery.Search))
            {
                query = query.Where(category => EF.Functions.Like(category.Name, paramQuery.Search));
            }

            if (!string.IsNullOrWhiteSpace(paramQuery.SortColumn))
            {
                if (string.IsNullOrWhiteSpace(paramQuery.SortOrder) || paramQuery.SortOrder.Equals(Constants.ASCSORTORDER, StringComparison.OrdinalIgnoreCase))
                {
                    query = query.OrderBy(GetSortProperty(paramQuery.SortColumn));
                }
                else if (paramQuery.SortOrder.Equals(Constants.DESCSORTORDER, StringComparison.OrdinalIgnoreCase))
                {
                    query = query.OrderByDescending(GetSortProperty(paramQuery.SortColumn));
                }
            }
            else
            {
                query = query.OrderBy(x => x.Id);
            }

            return await query
                .Select(x => new SubCategory
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    Description = x.Description,
                })
                .AsNoTracking()
                .Skip((paramQuery.PageNumber - 1) * paramQuery.PageSize)
                .Take(paramQuery.PageSize)
                .ToListAsync();
        }

        private static Expression<Func<SubCategory, object>> GetSortProperty(string propertyName)
        {
            Expression<Func<SubCategory, object>> keySelector = propertyName.ToLower() switch
            {
                "name" => category => category.Name,
                _ => category => category.Id
            };

            return keySelector;
        }
    }
}
