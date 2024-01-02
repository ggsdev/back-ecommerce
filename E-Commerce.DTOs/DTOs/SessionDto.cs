namespace E_Commerce.DTOs.DTOs
{
    public record SessionDto(
        string Token,
        string ExpirationDate);
}
