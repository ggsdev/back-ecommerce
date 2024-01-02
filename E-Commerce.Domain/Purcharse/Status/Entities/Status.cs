using E_Commerce.Domain.Purcharse.Status.Enums;
using E_Commerce.Shared;

namespace E_Commerce.Domain.Purcharse.Status.Entities
{
    public class Status : BaseEntity
    {
        public StatusEnum StatusValue;
        public string Description { get; set; } = null!;
        public bool CanRate { get; set; }
    }
}
