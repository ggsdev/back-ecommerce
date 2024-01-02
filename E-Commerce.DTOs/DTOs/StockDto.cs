﻿using E_Commerce.Shared;

namespace E_Commerce.DTOs.DTOs
{
    public record StockDto(
        long Id,
        string CreatedAt,
        string? UpdatedAt

    ) : BaseDto(Id, CreatedAt, UpdatedAt);
}
