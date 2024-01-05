using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.Payment.PaymentMethods.Entities;
using E_Commerce.Domain.Purcharse.Status.Entities;
using E_Commerce.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Purcharse.Orders.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; } = null!;
        public decimal Total { get; set; }
        public DateTime EstimatedDeliverTime { get; set; }
        public DateTime? DeliveredTime { get; set; }
        public DateTime? CanceledTime { get; set; }
        public decimal FreightCost { get; set; } //frete
        public List<OrderItems> OrderProducts { get; set; } = null!;
        public StatusOrder StatusOrder { get; set; } = null!;
        [ForeignKey("StatusOrder")]
        public int StatusOrderId { get; set; }
        public User Buyer { get; set; } = null!;
        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = null!;
        [ForeignKey(nameof(PaymentMethod))]
        public int PaymentMethodId { get; set; }
    }
}
