using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels.Product
{
    public class CreateUpdateStockViewModel
    {
        [Required(ErrorMessage = "Quantity is required")]
        public short Quantity { get; set; }
        [Required(ErrorMessage = "IsAvailable is required")]
        public bool IsAvailable { get; set; }
    }
}
