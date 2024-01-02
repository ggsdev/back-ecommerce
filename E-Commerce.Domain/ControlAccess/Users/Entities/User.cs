using E_Commerce.Shared;
using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Sessions.Entities;
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
        public virtual Info Info { get; set; } = null!;
        [ForeignKey(nameof(Info))]
        public long InfoId { get; set; }
        public virtual Session? Session { get; set; }
    }
}
