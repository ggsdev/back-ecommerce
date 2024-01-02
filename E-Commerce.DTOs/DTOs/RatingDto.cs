using E_Commerce.Shared;

namespace E_Commerce.DTOs.DTOs
{
    public record RatingDto(
        long Id,
        string CreatedAt,
        string? UpdatedAt,
        int Value,
        string Comment,
        long ItemId,
        long UserId
    ) : BaseDto(Id, CreatedAt, UpdatedAt);
}
