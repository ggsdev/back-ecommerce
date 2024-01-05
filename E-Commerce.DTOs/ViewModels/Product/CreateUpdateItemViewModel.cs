using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels.Product
{
    public class CreateUpdateItemViewModel
    {
        [Required(ErrorMessage = $"O campo {nameof(Name)} é obrigatório.")]
        [StringLength(120, ErrorMessage = "120 caracteres")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Base64String(ErrorMessage = "Imagem inválida.")]
        public string? MainImage { get; set; }
        [Required(ErrorMessage = $"O campo {nameof(Price)} é obrigatório.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = $"O campo {nameof(SubCategoryId)} é obrigatório.")]
        public int? SubCategoryId { get; set; }
        [Required(ErrorMessage = $"O campo {nameof(Images)} é obrigatório.")]
        [Length(1, 5, ErrorMessage = "Mínimo 1 imagem, máximo 5 imagens.")]
        public List<CreateUpdateImageViewModel> Images { get; set; } = [];
        [Required(ErrorMessage = $"O campo {nameof(Stock)} é obrigatório.")]
        public CreateUpdateStockViewModel Stock { get; set; } = null!;
    }
}
