using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels.Product
{
    public class CreateUpdateRatingViewModel
    {
        [Required(ErrorMessage = "Value is required")]
        public short? Value { get; set; } = null!;
        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; } = null!;
        [Required(ErrorMessage = "UserId is required")]
        public long? UserId { get; set; } = null!;
        [Required(ErrorMessage = "ItemId is required")]
        public long? ItemId { get; set; } = null!;
        [Required(ErrorMessage = "OrderId is required")]
        public long? OrderId { get; set; }
    }
}
