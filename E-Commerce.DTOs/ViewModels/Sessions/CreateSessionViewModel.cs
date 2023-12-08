using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels.Sessions
{
    public class CreateSessionViewModel
    {
        [Required(ErrorMessage = $"O campo {nameof(Email)} é obrigatório")]
        [EmailAddress(ErrorMessage = $"O campo {nameof(Email)} está em formato inválido")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = $"O campo {nameof(Password)} é obrigatório")]
        public string Password { get; set; } = null!;
    }
}
