﻿using E_Commerce.Shared;

namespace E_Commerce.DTOs.DTOs
{
    public record InfoDto(long Id, DateTime CreatedAt, DateTime? UpdatedAt, string Cellphone, string Email, AddressDto Address) : BaseDto(Id, CreatedAt, UpdatedAt);
}
