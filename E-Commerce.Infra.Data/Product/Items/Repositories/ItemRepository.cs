﻿using E_Commerce.Domain.Product.Categories.Entities;
using E_Commerce.Domain.Product.Images.Entites;
using E_Commerce.Domain.Product.Items.Entities;
using E_Commerce.Domain.Product.Items.Interfaces;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace E_Commerce.Infra.Data.Product.Items.Repositories
{
    internal class ItemRepository(DataContext context, IDistributedCache cache) : BaseRepository<Item>(context), IItemRepository
    {
        private readonly IDistributedCache _cache = cache;
        private readonly DataContext _context = context;

        public async Task<bool> AnyByName(string name, int? id = null)
        {
            return await _context.Items
                .Where(product => EF.Functions.Like(product.Name, name) && product.Id != id)
                .AnyAsync();
        }

        public async Task<List<Item>> GetAll(FilterQuery paramQuery, CancellationToken ct)
        {
            var key = $"items-{paramQuery.PageNumber}-{paramQuery.PageSize}-{paramQuery.SortOrder}-{paramQuery.SortColumn}-{paramQuery.Search}";

            string? cachedMember = await _cache.GetStringAsync(key, ct);

            if (string.IsNullOrEmpty(cachedMember))
            {
                IQueryable<Item> query = _context.Items;

                if (!string.IsNullOrWhiteSpace(paramQuery.Search))
                {
                    query = query.Where(item => EF.Functions.Like(item.Name, paramQuery.Search));
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

                var resultQuery = await query
                    .Select(x => new Item
                    {
                        Id = x.Id,
                        Name = x.Name,
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt,
                        Description = x.Description,
                        SubCategory = new Category
                        {
                            Id = x.SubCategory.Id,
                            Name = x.SubCategory.Name,
                            Image = x.SubCategory.Image,
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
                    .ToListAsync(cancellationToken: ct);

                await _cache.SetStringAsync(
                    key,
                    JsonConvert.SerializeObject(resultQuery),
                    ct);

                return resultQuery;
            }

            return JsonConvert.DeserializeObject<List<Item>>(
                cachedMember)!;
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

        public async Task<Item?> GetById(int id)
        {
            return await _context.Items
                .Include(item => item.SubCategory)
                .Include(item => item.Images)
                .Include(x => x.Stock)
                .Where(item => item.Id == id)
                .Select(x => new Item
                {
                    Id = x.Id,
                    Price = x.Price,
                    Name = x.Name,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    Description = x.Description,
                    SubCategory = new Category
                    {
                        Id = x.SubCategory.Id,
                        Name = x.SubCategory.Name,
                        Image = x.SubCategory.Image,

                        ParentCategory = new Category
                        {
                            Id = x.SubCategory.ParentCategory!.Id,
                            Name = x.SubCategory.ParentCategory!.Name,
                        }
                    },
                    Images = x.Images.Select(i => new Image
                    {
                        Id = i.Id,
                        ImageContent = i.ImageContent,
                        Name = i.Name,
                        IsShowCase = i.IsShowCase,
                    }).ToList(),
                    Stock = x.Stock
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
