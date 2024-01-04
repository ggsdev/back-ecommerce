using E_Commerce.Shared;

namespace E_Commerce.DTOs.DTOs
{
    public record SubCategoryDto(
        int Id,
        string CreatedAt,
        string? UpdatedAt,
        string Name,
        string? Description,
        CategoryDto Category
    ) : BaseDto(Id, CreatedAt, UpdatedAt);
}
