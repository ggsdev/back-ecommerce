using E_Commerce.Domain.Product.SubCategories.Entities;
using E_Commerce.Domain.Product.SubCategories.Interfaces;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.SubCategories.Factories
{
    internal class SubCategoryFactory : ISubCategoryFactory
    {
        public SubCategory Create(CreateUpdateSubCategoryViewModel viewModel)
        {
            return new SubCategory
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                CategoryId = viewModel.CategoryId,
            };
        }

        public SubCategory Update(SubCategory subCategory, CreateUpdateSubCategoryViewModel viewModel)
        {
            subCategory.Name = viewModel.Name;
            subCategory.Description = viewModel.Description;
            subCategory.CategoryId = viewModel.CategoryId;

            return subCategory;
        }
    }
}
