using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "O campo {1} é obrigatório.")]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "O campo {2} é obrigatório.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "O campo {3} é obrigatório.")]
        public AddressViewModel Address { get; set; } = null!;
        [Required(ErrorMessage = "O campo {4} é obrigatório.")]
        public InfoViewModel Info { get; set; } = null!;
    }
}
