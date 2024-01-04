using E_Commerce.Domain.Product.Categories.Entities;
using E_Commerce.Domain.Product.Categories.Interfaces;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce.Infra.Data.Product.Categories.Repositories
{
    internal class CategoryRepository(DataContext context) : BaseRepository<Category>(context), ICategoryRepository
    {
        private readonly DataContext _context = context;
        public async Task<bool> AnyByName(string name, int? id = null)
        {
            return await _context.Categories
                    .Where(category => EF.Functions.Like(category.Name, name) && category.Id != id)
                    .AnyAsync();
        }

        public async Task<List<Category>> GetAll(FilterQuery paramQuery)
        {
            IQueryable<Category> query = _context.Categories;

            if (!string.IsNullOrWhiteSpace(paramQuery.Search))
            {
                query = query.Where(category => EF.Functions.Like(category.Name, paramQuery.Search));
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
                .Include(x => x.SubCategories)
                .Select(x => new Category
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    Description = x.Description,
                    Image = x.Image,
                    SubCategories = x.SubCategories != null ? x.SubCategories
                    .Select(x => new Category
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList() : null,
                })
                .AsNoTracking()
                .Skip((paramQuery.PageNumber - 1) * paramQuery.PageSize)
                .Take(paramQuery.PageSize)
                .ToListAsync();
        }

        private static Expression<Func<Category, object>> GetSortProperty(string propertyName)
        {
            Expression<Func<Category, object>> keySelector = propertyName.ToLower() switch
            {
                "name" => category => category.Name,
                _ => category => category.Id
            };

            return keySelector;
        }

        public async Task<Category?> GetSubCategory(int id)
        {
            return await _context.Categories
                .Where(x => x.Id.Equals(id) && !x.IsParent)
                .FirstOrDefaultAsync();
        }
    }
}
