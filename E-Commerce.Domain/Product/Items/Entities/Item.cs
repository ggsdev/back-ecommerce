using E_Commerce.Domain.Product.Categories.Entities;
using E_Commerce.Domain.Product.Images.Entites;
using E_Commerce.Domain.Product.Ratings.Entities;
using E_Commerce.Domain.Product.Stocks.Entities;
using E_Commerce.Domain.Purcharse.Orders.Entities;
using E_Commerce.Shared;
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
        public int SubCategoryId { get; set; }
        public Category SubCategory { get; set; } = null!;

        [ForeignKey(nameof(Stock))]
        public int StockId { get; set; }
        public Stock Stock { get; set; } = null!;
        public List<Rating> Ratings { get; set; } = [];

        public List<OrderItems> OrderProducts { get; set; } = [];
    }
}
