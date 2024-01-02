﻿using E_Commerce.Shared;

namespace E_Commerce.DTOs.DTOs
{
    public record ItemDto(
        long Id,
        string Name,
        decimal Price,
        string? Description,
        SubCategoryDto SubCategory,
        StockDto Stock,
        string CreatedAt,
        string? UpdatedAt
    ) : BaseDto(Id, CreatedAt, UpdatedAt);
}
