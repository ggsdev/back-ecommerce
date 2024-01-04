using E_Commerce.Shared;

namespace E_Commerce.DTOs.DTOs
{
    public record CategoryDto(
        int Id,
        string CreatedAt,
        string? UpdatedAt,
        string Name,
        string? Description,
        string? Image
    ) : BaseDto(Id, CreatedAt, UpdatedAt);
}
