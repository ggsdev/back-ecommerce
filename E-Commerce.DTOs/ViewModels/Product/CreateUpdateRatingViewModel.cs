using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels.Product
{
    public class CreateUpdateRatingViewModel
    {
        [Required(ErrorMessage = "Value is required")]
        [Range(1, 5, ErrorMessage = "Value must be between 1 and 5")]
        public byte? Value { get; set; } = null!;
        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; } = null!;
        [Required(ErrorMessage = "UserId is required")]
        public int? UserId { get; set; } = null!;
        [Required(ErrorMessage = "ItemId is required")]
        public int? ItemId { get; set; } = null!;
        [Required(ErrorMessage = "OrderId is required")]
        public int? OrderId { get; set; }
    }
}
