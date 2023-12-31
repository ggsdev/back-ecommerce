﻿using E_Commerce.Shared;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Categories.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategory(CreateUpdateCategoryViewModel viewModel, User loggedUser);
        Task DeleteCategory(int id, User loggedUser);
        Task<CategoryDto> UpdateCategory(CreateUpdateCategoryViewModel viewModel, int id, User loggedUser);
        Task<PaginatedDataDTO<CategoryDto>> GetAllCategories(FilterQuery queryParams, string requestUrl);
        Task<CategoryDto> GetCategoryById(int id);

    }
}
