using E_Commerce.Domain.Product.Categories.Entities;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Categories.Interfaces
{
    public interface ICategoryFactory
    {
        Category Create(CreateUpdateCategoryViewModel viewModel);
        Category Update(Category category, CreateUpdateCategoryViewModel viewModel);
    }
}
