namespace E_Commerce.DTOs.DTOs
{
    public class SessionDto
    {
        public string Token { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
    }
}
