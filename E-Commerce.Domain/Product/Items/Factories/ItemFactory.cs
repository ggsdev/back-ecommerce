using E_Commerce.Domain.Product.Images.Entites;
using E_Commerce.Domain.Product.Items.Entities;
using E_Commerce.Domain.Product.Items.Interfaces;
using E_Commerce.Domain.Product.Stocks.Entities;
using E_Commerce.Domain.Product.SubCategories.Entities;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Items.Factories
{
    internal class ItemFactory : IItemFactory
    {
        public Item Create(CreateUpdateItemViewModel viewModel, List<Image> images, Stock stock, SubCategory subCategory)
        {
            return new Item
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                SubCategoryId = viewModel.SubCategoryId!.Value,
                Images = images,
                Stock = stock,
                SubCategory = subCategory
            };
        }

        public Item Update(Item item, CreateUpdateItemViewModel viewModel, List<Image> images)
        {
            item.Name = viewModel.Name;
            item.Price = viewModel.Price;
            item.SubCategoryId = viewModel.SubCategoryId!.Value;
            item.Images = images;

            return item;
        }
    }
}
