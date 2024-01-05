using E_Commerce.Domain.Product.Categories.Entities;
using E_Commerce.Domain.Product.Categories.Interfaces;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Categories.Factories
{
    internal class CategoryFactory : ICategoryFactory
    {
        public Category Create(CreateUpdateCategoryViewModel viewModel) => new()
        {
            Name = viewModel.Name,
            Description = viewModel.Description,
            Image = viewModel.Image is not null ? Convert.FromBase64String(viewModel.Image) : null,
        };

        public Category Update(Category category, CreateUpdateCategoryViewModel viewModel)
        {
            category.Name = viewModel.Name;
            category.Description = viewModel.Description;
            category.Image = viewModel.Image is not null ? Convert.FromBase64String(viewModel.Image) : null;

            return category;
        }
    }
}
