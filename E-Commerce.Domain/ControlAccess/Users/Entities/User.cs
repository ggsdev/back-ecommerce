using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Sessions.Entities;
using E_Commerce.Domain.Product.Ratings.Entities;
using E_Commerce.Domain.Purcharse.Orders.Entities;
using E_Commerce.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.ControlAccess.Users.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Age { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; } = null!;
        public Info Info { get; set; } = null!;
        [ForeignKey(nameof(Info))]
        public int InfoId { get; set; }
        public Session? Session { get; set; }
        public List<Rating> Ratings { get; set; } = [];
        public List<Order> Orders { get; set; } = [];
    }
}
