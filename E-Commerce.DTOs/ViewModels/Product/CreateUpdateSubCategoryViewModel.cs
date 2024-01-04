using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels.Product
{
    public class CreateUpdateSubCategoryViewModel
    {
        [Required(ErrorMessage = $"O campo {nameof(Name)} é obrigatório")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Required(ErrorMessage = $"O campo {nameof(CategoryId)} é obrigatório")]
        public int CategoryId { get; set; }
    }
}
