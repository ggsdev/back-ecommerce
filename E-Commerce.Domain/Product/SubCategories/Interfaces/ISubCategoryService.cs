using E_Commerce.Shared;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.SubCategories.Interfaces
{
    public interface ISubCategoryService
    {
        Task<SubCategoryDto> CreateSubCategory(CreateUpdateSubCategoryViewModel viewModel, User loggedUser);
        Task<SubCategoryDto> UpdateSubCategory(int id, CreateUpdateSubCategoryViewModel viewModel, User loggedUser);
        Task DeleteSubCategory(int id, User loggedUser);
        Task<SubCategoryDto> GetSubCategoryById(int id);
        Task<PaginatedDataDTO<SubCategoryDto>> GetSubCategories(FilterQuery queryParams, string requestUrl);
    }
}
