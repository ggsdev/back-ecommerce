using E_Commerce.Common;

namespace E_Commerce.DTOs.DTOs
{
    public record CategoryDto(
         long Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string Name,
        string? Description,
        string? Image
    ) : BaseDto(Id,
        CreatedAt,
        UpdatedAt);
}
