using E_Commerce.Common;

namespace E_Commerce.DTOs.DTOs
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public InfoDto Info { get; set; } = null!;
    }
}
