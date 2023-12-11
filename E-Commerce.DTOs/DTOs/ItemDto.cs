using E_Commerce.Common;

namespace E_Commerce.DTOs.DTOs
{
    public record ItemDto(long Id, DateTime CreatedAt, DateTime? UpdatedAt) : BaseDto(Id, CreatedAt, UpdatedAt)
    {
    }
}
