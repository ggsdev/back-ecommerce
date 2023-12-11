using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.ViewModels.ControlAccess
{
    public class CreateUpdateAddressViewModel
    {
        [Required(ErrorMessage = $"O campo {nameof(Street)} é obrigatório.")]
        [StringLength(250, ErrorMessage = $"O campo {nameof(Street)} deve ter no máximo 250 caracteres.")]
        public string Street { get; set; } = null!;
        [Required(ErrorMessage = $"O campo {nameof(Number)} é obrigatório.")]
        [StringLength(10, ErrorMessage = $"O campo {nameof(Number)} deve ter no máximo 10 caracteres.")]
        public string Number { get; set; } = null!;
        [Required(ErrorMessage = $"O campo {nameof(Complement)} é obrigatório.")]
        [StringLength(60, ErrorMessage = $"O campo {nameof(Complement)} deve ter no máximo 60 caracteres.")]
        public string Complement { get; set; } = null!;
        [Required(ErrorMessage = $"O campo {nameof(City)} é obrigatório.")]
        [StringLength(120, ErrorMessage = $"O campo {nameof(City)} deve ter no máximo 120 caracteres.")]
        public string City { get; set; } = null!;
        [Required(ErrorMessage = $"O campo {nameof(State)} é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = $"O campo {nameof(State)} deve ter 2 caracteres.")]
        public string State { get; set; } = null!;
        [Required(ErrorMessage = $"O campo {nameof(ZipCode)} é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = $"O campo {nameof(ZipCode)} está inválido, deve ser no formato 00000-000.")]
        [StringLength(maximumLength: 9, MinimumLength = 9, ErrorMessage = $"O campo {nameof(ZipCode)} deve ter 9 caracteres.")]
        public string ZipCode { get; set; } = null!;
        [StringLength(120, ErrorMessage = $"O campo {nameof(Reference)} deve ter no máximo 120 caracteres.")]
        public string? Reference { get; set; }
    }
}
