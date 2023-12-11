using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels.Product
{
    public class CreateUpdateImageViewModel
    {
        [Required(ErrorMessage = $"O campo {nameof(ImageContent)} é obrigatório")]
        public string ImageContent { get; set; } = null!;
        [Required(ErrorMessage = $"O campo {nameof(IsShowCase)} é obrigatório")]
        public bool IsShowCase { get; set; }
        [Required(ErrorMessage = $"O campo {nameof(Name)} é obrigatório")]
        [StringLength(120, ErrorMessage = $"O campo {nameof(Name)} deve ter no máximo 120 caracteres")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
