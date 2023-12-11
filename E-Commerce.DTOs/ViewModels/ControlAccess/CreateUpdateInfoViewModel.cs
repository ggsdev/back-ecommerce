using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels.ControlAccess
{
    public class CreateUpdateInfoViewModel
    {
        [Required(ErrorMessage = $"O campo {nameof(Email)} é obrigatório.")]
        [EmailAddress(ErrorMessage = $"O campo {nameof(Email)} está em formato inválido.")]
        [StringLength(120, ErrorMessage = $"O campo {nameof(Email)} deve ter no máximo 120 caracteres.")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = $"O campo {nameof(Cellphone)} é obrigatório.")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = $"O campo {nameof(Cellphone)} deve ter 11 caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = $"O campo {nameof(Cellphone)} deve conter apenas números.")]
        public string Cellphone { get; set; } = null!;
    }
}
