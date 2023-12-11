using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Categories.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategory(CreateUpdateCategoryViewModel viewModel, User loggedUser);
        Task DeleteCategory(long id, User loggedUser);
        Task<CategoryDto> UpdateCategory(CreateUpdateCategoryViewModel viewModel, long id, User loggedUser);
        Task<PaginatedDataDTO<CategoryDto>> GetAllCategories(FilterQuery queryParams, string requestUrl);
        Task<CategoryDto> GetCategoryById(long id);

    }
}
