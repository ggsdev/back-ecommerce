using E_Commerce.Common;

namespace E_Commerce.DTOs.DTOs
{
    public record UserDto(long Id, DateTime CreatedAt, DateTime? UpdatedAt, string Name, string Surname, int Age, InfoDto Info) : BaseDto(Id, CreatedAt, UpdatedAt);
}
