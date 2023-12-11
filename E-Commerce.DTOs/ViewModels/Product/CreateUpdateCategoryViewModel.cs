using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels.Product
{
    public class CreateUpdateCategoryViewModel
    {
        [Required(ErrorMessage = $"O campo {nameof(Name)} é obrigatório")]
        [StringLength(120, ErrorMessage = $"O campo {nameof(Name)} máximo 120 caracteres")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}
