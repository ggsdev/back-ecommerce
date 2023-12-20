using E_Commerce.Common;
using E_Commerce.Domain.Product.Items.Entities;

namespace E_Commerce.Domain.Product.Stocks.Entities
{
    public class Stock : BaseEntity
    {
        public short Quantity { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Item Item { get; set; } = null!;
    }
}
