using E_Commerce.Shared;

namespace E_Commerce.DTOs.DTOs
{
    public record UserDto(
        long Id,
        string CreatedAt,
        string? UpdatedAt,
        string Name,
        string Surname,
        int Age,
        InfoDto Info
    ) : BaseDto(Id, CreatedAt, UpdatedAt);
}
