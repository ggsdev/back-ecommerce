using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels.Product
{
    public class CreateUpdateCategoryViewModel
    {
        [Required(ErrorMessage = $"O campo {nameof(Name)} é obrigatório")]
        [StringLength(120, ErrorMessage = $"O campo {nameof(Name)} máximo 120 caracteres")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = $"O campo {nameof(IsParent)} é obrigatório")]
        public bool? IsParent { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? Description { get; set; }
        [Base64String]
        public string? Image { get; set; }
    }
}
