using E_Commerce.Common;
using E_Commerce.Domain.Product.Images.Entites;
using E_Commerce.Domain.Product.SubCategories.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Product.Items.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public List<Image> Images { get; set; } = [];
        [ForeignKey(nameof(SubCategory))]
        public long SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; } = null!;
    }
}
