using E_Commerce.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Product.Categories.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public bool IsParent { get; set; }
        [ForeignKey(nameof(ParentCategory))]
        public int? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public List<Category>? SubCategories { get; set; }
    }
}
