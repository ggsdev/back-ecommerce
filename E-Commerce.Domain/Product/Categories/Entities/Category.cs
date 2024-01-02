using E_Commerce.Shared;
using E_Commerce.Domain.Product.SubCategories.Entities;

namespace E_Commerce.Domain.Product.Categories.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public List<SubCategory> SubCategories { get; set; } = [];
    }
}
