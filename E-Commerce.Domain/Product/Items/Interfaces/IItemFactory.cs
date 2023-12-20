using E_Commerce.Domain.Product.Images.Entites;
using E_Commerce.Domain.Product.Items.Entities;
using E_Commerce.Domain.Product.Stocks.Entities;
using E_Commerce.Domain.Product.SubCategories.Entities;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Items.Interfaces
{
    public interface IItemFactory
    {
        Item Create(CreateUpdateItemViewModel viewModel, List<Image> images, Stock stock, SubCategory subCategory);
        Item Update(Item item, CreateUpdateItemViewModel viewModel, List<Image> images);
    }
}
