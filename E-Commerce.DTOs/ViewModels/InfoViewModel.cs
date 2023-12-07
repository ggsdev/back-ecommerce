using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels
{
    public class InfoViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "O campo {1} é obrigatório.")]
        public string Cellphone { get; set; } = null!;
    }
}
