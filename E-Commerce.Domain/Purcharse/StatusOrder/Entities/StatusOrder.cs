using E_Commerce.Domain.Purcharse.Orders.Entities;
using E_Commerce.Domain.Purcharse.Status.Enums;
using E_Commerce.Shared;

namespace E_Commerce.Domain.Purcharse.Status.Entities
{
    public class StatusOrder : BaseEntity
    {
        public StatusEnum StatusValue;
        public string Description { get; set; } = null!;
        public bool CanRate { get; set; }

        public Order Order { get; set; } = null!;
    }
}
