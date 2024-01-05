using E_Commerce.Shared;

namespace E_Commerce.DTOs.DTOs
{
    public record CategoryDto(
        int Id,
        string CreatedAt,
        string? UpdatedAt,
        bool IsParent,
        string Name,
        string? Description,
        byte[]? Image,
        List<CategoryDto> SubCategories
    ) : BaseDto(Id, CreatedAt, UpdatedAt);
}
