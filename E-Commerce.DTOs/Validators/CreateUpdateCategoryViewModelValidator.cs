using E_Commerce.DTOs.ViewModels.Product;
using FluentValidation;

namespace E_Commerce.DTOs.Validators
{
    public class CreateUpdateCategoryViewModelValidator : AbstractValidator<CreateUpdateCategoryViewModel>
    {
        public CreateUpdateCategoryViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O campo Name é obrigatório")
                .Length(0, 120)
                .WithMessage("O campo Name deve ter no máximo 120 caracteres");

            RuleFor(x => x.IsParent)
                .NotNull()
                .WithMessage("O campo IsParent é obrigatório");

            RuleFor(x => x.ParentCategoryId)
                .NotNull()
                .When(x => !x.IsParent.HasValue || !x.IsParent.Value)
                .WithMessage("ParentCategoryId deve ser não nulo quando IsParent é falso")

                .Null()
                .When(x => x.IsParent.HasValue && x.IsParent.Value)
                .WithMessage("ParentCategoryId deve ser nulo quando IsParent é verdadeiro");
        }
    }
}
