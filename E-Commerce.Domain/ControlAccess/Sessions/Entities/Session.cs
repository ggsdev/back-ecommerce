using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.ControlAccess.Sessions.Entities
{
    public class Session : BaseEntity
    {
        public string Token { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}
