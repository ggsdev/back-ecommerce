using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Street { get; set; } = null!;
        [Required(ErrorMessage = "O campo {1} é obrigatório.")]
        public string Number { get; set; } = null!;
        [Required(ErrorMessage = "O campo {2} é obrigatório.")]
        public string Complement { get; set; } = null!;
        [Required(ErrorMessage = "O campo {3} é obrigatório.")]
        public string City { get; set; } = null!;
        [Required(ErrorMessage = "O campo {4} é obrigatório.")]
        public string State { get; set; } = null!;
        [Required(ErrorMessage = "O campo {5} é obrigatório.")]
        public string ZipCode { get; set; } = null!;
        [Required(ErrorMessage = "O campo {6} é obrigatório.")]
        public string Reference { get; set; } = null!;
    }
}
