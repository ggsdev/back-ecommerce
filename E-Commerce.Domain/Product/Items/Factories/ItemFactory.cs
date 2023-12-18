using E_Commerce.Domain.Product.Images.Entites;
using E_Commerce.Domain.Product.Items.Entities;
using E_Commerce.Domain.Product.Items.Interfaces;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Items.Factories
{
    internal class ItemFactory : IItemFactory
    {
        public Item Create(CreateUpdateItemViewModel viewModel, List<Image> images)
        {
            return new Item
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                SubCategoryId = viewModel.SubCategoryId!.Value,
                Images = images
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
