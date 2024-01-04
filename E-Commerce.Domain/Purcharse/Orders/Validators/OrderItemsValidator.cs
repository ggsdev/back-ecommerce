using E_Commerce.Domain.Purcharse.Orders.Entities;
using FluentValidation;

namespace E_Commerce.Domain.Purcharse.Orders.Validators
{
    public class OrderItemsValidator : AbstractValidator<OrderItems>
    {
        public OrderItemsValidator()
        {
            RuleFor(orderItems => orderItems.OrderId)
                .NotEmpty()
                .WithMessage("The OrderId field is required.");

            RuleFor(orderItems => orderItems.ItemId)
                .NotEmpty()
                .WithMessage("The ItemId field is required.");

            RuleFor(orderItems => orderItems.Quantity)
                .NotEmpty()
                .WithMessage("The Quantity field is required.")
                .GreaterThanOrEqualTo((byte)1)
                .WithMessage("The Quantity field must be between 1 and 255.")
                .LessThanOrEqualTo((byte)255)
                .WithMessage("The Quantity field must be between 1 and 255.");

            RuleFor(orderItems => orderItems.Price)
                .NotEmpty()
                .WithMessage("The Price field is required.")
                .GreaterThan(0)
                .WithMessage("The Price field must be greater than 0.");

            RuleFor(orderItems => orderItems.Total)
                .NotEmpty()
                .WithMessage("The Total field is required.")
                .GreaterThan(0)
                .WithMessage("The Total field must be greater than 0.");
        }
    }
}
