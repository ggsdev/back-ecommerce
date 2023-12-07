namespace E_Commerce.DTOs.DTOs
{
    public class InfoDto
    {
        public string Cellphone { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public AddressDto Address { get; set; } = null!;
    }
}
