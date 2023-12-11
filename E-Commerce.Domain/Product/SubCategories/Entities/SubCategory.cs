using E_Commerce.Common;
using E_Commerce.Domain.Product.Categories.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Product.SubCategories.Entities
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Category Category { get; set; } = null!;
        [ForeignKey(nameof(Category))]
        public long CategoryId { get; set; }
    }
}
