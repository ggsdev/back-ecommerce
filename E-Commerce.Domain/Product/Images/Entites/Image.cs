using E_Commerce.Shared;
using E_Commerce.Domain.Product.Items.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Product.Images.Entites
{
    public class Image : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public byte[] ImageContent { get; set; } = null!;
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
        public bool IsShowCase { get; set; } //vitrine do produto
    }
}
