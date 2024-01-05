using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.ControlAccess.Infos.Entities
{
    public class Info : BaseEntity
    {
        public string Cellphone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Address Address { get; set; } = null!;
        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }
        public User User { get; set; } = null!;
    }
}
