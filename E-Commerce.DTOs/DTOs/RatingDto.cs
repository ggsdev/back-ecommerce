using E_Commerce.Shared;

namespace E_Commerce.DTOs.DTOs
{
    public record RatingDto(
        int Id,
        string CreatedAt,
        string? UpdatedAt,
        int Value,
        string Comment,
        int ItemId,
        int UserId
    ) : BaseDto(Id, CreatedAt, UpdatedAt);
}
