using E_Commerce.Shared;

namespace E_Commerce.DTOs.DTOs
{
    public record AddressDto(
        int Id,
        string CreatedAt,
        string? UpdatedAt,
        string Street,
        string Number,
        string Complement,
        string City,
        string State,
        string ZipCode,
        string? Reference
    ) : BaseDto(Id, CreatedAt, UpdatedAt);
}
