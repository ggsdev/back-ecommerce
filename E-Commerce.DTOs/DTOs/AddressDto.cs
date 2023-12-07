using E_Commerce.Common;

namespace E_Commerce.DTOs.DTOs
{
    public class AddressDto : BaseDto
    {
        public string Street { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string Complement { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Reference { get; set; } = null!;
    }
}
