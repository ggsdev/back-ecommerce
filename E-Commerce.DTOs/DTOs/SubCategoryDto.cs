using E_Commerce.Shared;

namespace E_Commerce.DTOs.DTOs
{
    public record SubCategoryDto(
        long Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string Name,
        string? Description,
        CategoryDto Category
        ) : BaseDto(Id, CreatedAt, UpdatedAt);
}
