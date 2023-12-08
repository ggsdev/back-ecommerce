using E_Commerce.Domain.ControlAccess.Users.Entities;
using FluentValidation;

namespace E_Commerce.Domain.ControlAccess.Users.Validators
{
    internal class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("The Name field is required.")
                .Length(0, 120).WithMessage("The Name field must be a string with a maximum length of 120.");

            RuleFor(user => user.Surname)
                .NotEmpty().WithMessage("The Surname field is required.")
                .Length(0, 120).WithMessage("The Surname field must be a string with a maximum length of 120.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("The Password field is required.")
                .Length(0, 250).WithMessage("The Password field must be a string with a maximum length of 250.");

            RuleFor(user => user.Info)
                .NotNull().WithMessage("The Info field is required.");

            RuleFor(user => user.Age)
                .InclusiveBetween(1, 120).WithMessage("The Age field must be between 1 and 120.");
        }
    }
}