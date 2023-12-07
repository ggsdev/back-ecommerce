using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.ControlAccess.Infos.Entities
{
    public class Info : BaseEntity
    {
        public string Cellphone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public virtual Address Address { get; set; } = null!;
        [ForeignKey(nameof(Address))]
        public long AddressId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
