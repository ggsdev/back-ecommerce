using E_Commerce.DTOs.ViewModels.Infos;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels.Users
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = $"O campo {nameof(Name)} é obrigatório.")]
        [StringLength(120, ErrorMessage = "120 caracteres")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = $"O campo {nameof(Surname)} é obrigatório.")]
        [StringLength(120, ErrorMessage = "120 caracteres")]
        public string Surname { get; set; } = null!;
        [Required(ErrorMessage = $"O campo {nameof(Password)} é obrigatório.")]
        [StringLength(250, ErrorMessage = "250 caracteres")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = $"O campo {nameof(Address)} é obrigatório.")]
        public CreateUpdateAddressViewModel Address { get; set; } = null!;
        [Required(ErrorMessage = $"O campo {nameof(Info)} é obrigatório.")]
        public CreateUpdateInfoViewModel Info { get; set; } = null!;
        [Range(1, 120, ErrorMessage = "Idade inválida ou em branco, deve ser obrigatoriamente um valor entre 1 e 120.")]
        public int Age { get; set; }
    }
}
