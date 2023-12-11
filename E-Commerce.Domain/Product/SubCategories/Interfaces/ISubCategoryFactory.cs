using E_Commerce.Domain.Product.SubCategories.Entities;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.SubCategories.Interfaces
{
    public interface ISubCategoryFactory
    {
        SubCategory Create(CreateUpdateSubCategoryViewModel viewModel);
        SubCategory Update(SubCategory subCategory, CreateUpdateSubCategoryViewModel viewModel);
    }
}
