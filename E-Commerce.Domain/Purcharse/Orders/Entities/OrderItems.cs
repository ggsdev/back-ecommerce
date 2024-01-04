using E_Commerce.Domain.Product.Items.Entities;
using E_Commerce.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Purcharse.Orders.Entities
{
    public class OrderItems : BaseEntity
    {
        public Order Order { get; set; } = null!;
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Item Item { get; set; } = null!;
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public byte Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
