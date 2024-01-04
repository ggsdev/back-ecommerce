using E_Commerce.Domain.Payment.PaymentMethods.Enums;
using E_Commerce.Domain.Purcharse.Orders.Entities;
using E_Commerce.Shared;

namespace E_Commerce.Domain.Payment.PaymentMethods.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public MethodEnum PaymentMethodValue { get; set; }
        public bool IsDefault { get; set; }
        public string? Description { get; set; }
        public Order Order { get; set; } = null!;
    }
}
