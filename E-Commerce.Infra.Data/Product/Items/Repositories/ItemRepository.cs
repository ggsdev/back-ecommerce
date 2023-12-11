using E_Commerce.Common;
using E_Commerce.Domain.Product.Images.Entites;
using E_Commerce.Domain.Product.Items.Entities;
using E_Commerce.Domain.Product.Items.Interfaces;
using E_Commerce.Domain.Product.SubCategories.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce.Infra.Data.Product.Items.Repositories
{
    internal class ItemRepository(DataContext context) : BaseRepository<Item>(context), IItemRepository
    {
        private readonly DataContext _context = context;

        public async Task<bool> AnyByName(string name, long? id = null)
        {
            return await _context.Items
                .Where(product => EF.Functions.Like(product.Name, name) && product.Id != id)
                .AnyAsync();
        }

        public async Task<List<Item>> GetAll(FilterQuery paramQuery)
        {
            IQueryable<Item> query = _context.Items;

            if (!string.IsNullOrWhiteSpace(paramQuery.Search))
            {
                query = query.Where(item => EF.Functions.Like(item.Name, paramQuery.Search));
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
                .Select(x => new Item
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    Description = x.Description,
                    SubCategory = new SubCategory
                    {
                        Id = x.SubCategory.Id,
                        Name = x.SubCategory.Name,
                    },
                    Images = x.Images.Select(i => new Image
                    {
                        Id = i.Id,
                        ImageContent = i.ImageContent,
                        Name = i.Name,
                        IsShowCase = i.IsShowCase,
                    }).ToList(),
                })
                .AsNoTracking()
                .Skip((paramQuery.PageNumber - 1) * paramQuery.PageSize)
                .Take(paramQuery.PageSize)
                .ToListAsync();
        }

        private static Expression<Func<Item, object>> GetSortProperty(string propertyName)
        {
            Expression<Func<Item, object>> keySelector = propertyName.ToLower() switch
            {
                "name" => item => item.Name,
                _ => item => item.Id
            };

            return keySelector;
        }

        public async Task<Item?> GetById(long id)
        {
            return await _context.Items
                .Include(item => item.SubCategory)
                .Include(item => item.Images)
                .Where(item => item.Id == id)
                .Select(x => new Item
                {
                    Id = x.Id,
                    Price = x.Price,
                    Name = x.Name,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    Description = x.Description,
                    SubCategory = new SubCategory
                    {
                        Id = x.SubCategory.Id,
                        Name = x.SubCategory.Name,
                    },
                    Images = x.Images.Select(i => new Image
                    {
                        Id = i.Id,
                        ImageContent = i.ImageContent,
                        Name = i.Name,
                        IsShowCase = i.IsShowCase,
                    }).ToList(),
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
