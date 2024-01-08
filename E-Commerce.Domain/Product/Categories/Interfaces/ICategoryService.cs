using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Product;
using E_Commerce.Shared;

namespace E_Commerce.Domain.Product.Categories.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategory(CreateUpdateCategoryViewModel viewModel);
        Task DeleteCategory(int id);
        Task<CategoryDto> UpdateCategory(CreateUpdateCategoryViewModel viewModel, int id);
        Task<PaginatedDataDTO<CategoryDto>> GetAllCategories(FilterQuery queryParams, string requestUrl);
        Task<CategoryDto> GetCategoryById(int id);

    }
}
