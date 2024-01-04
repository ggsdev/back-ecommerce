using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.Product.Items.Entities;
using E_Commerce.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Product.Ratings.Entities
{
    public class Rating : BaseEntity
    {
        public byte Value { get; set; }
        public string Comment { get; set; } = null!;
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public User User { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
    }
}
