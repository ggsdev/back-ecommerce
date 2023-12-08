using E_Commerce.Common;

namespace E_Commerce.DTOs.DTOs
{
    public record AddressDto(long Id, DateTime CreatedAt, DateTime? UpdatedAt, string Street, string Number, string Complement, string City, string State, string ZipCode, string? Reference)
        : BaseDto(Id, CreatedAt, UpdatedAt);
}
