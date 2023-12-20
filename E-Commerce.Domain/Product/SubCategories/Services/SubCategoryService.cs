﻿using AutoMapper;
using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.Product.Categories.Interfaces;
using E_Commerce.Domain.Product.SubCategories.Interfaces;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.SubCategories.Services
{
    internal class SubCategoryService(ISubCategoryFactory factory, ISubCategoryRepository repository, IMapper mapper, ICategoryRepository categoryRepository) : ISubCategoryService
    {
        private readonly ISubCategoryRepository _repository = repository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ISubCategoryFactory _factory = factory;

        public async Task<SubCategoryDto> CreateSubCategory(CreateUpdateSubCategoryViewModel viewModel, User loggedUser)
        {
            if (!loggedUser.IsAdmin)
                throw new Exception("User not admin");

            var anyByName = await _repository.AnyByName(viewModel.Name);

            if (anyByName)
                throw new Exception("Category already registered");

            var anyCategoryInDatabase = await _categoryRepository
                .AnyById(viewModel.CategoryId);

            if (!anyCategoryInDatabase)
                throw new Exception("Category not found");

            var createdCategory = _factory.Create(viewModel);

            await _repository.Add(createdCategory);

            await _repository.Save();

            var categoryDto = _mapper.Map<SubCategoryDto>(createdCategory);

            return categoryDto;
        }

        public async Task DeleteSubCategory(long id, User loggedUser)
        {
            if (!loggedUser.IsAdmin)
                throw new Exception("User not admin");

            var subCategoryInDatabase = await _repository.GetByIdClean(id)
                ?? throw new Exception("SubCategory not found");

            _repository.Delete(subCategoryInDatabase);

            await _repository.Save();

            return;
        }

        public async Task<PaginatedDataDTO<SubCategoryDto>> GetSubCategories(FilterQuery queryParams, string requestUrl)
        {
            var subCategories = await _repository.GetAll(queryParams);

            var totalCount = await _repository.Count();

            var subCategoriesDto = _mapper.Map<List<SubCategoryDto>>(subCategories);

            var paginatedData = APIGetReturn.Paginate(subCategoriesDto, queryParams.PageNumber, queryParams.PageSize, totalCount, requestUrl);

            return paginatedData;
        }

        public async Task<SubCategoryDto> GetSubCategoryById(long id)
        {
            var subCategory = await _repository.GetByIdClean(id)
                ?? throw new Exception("SubCategory not found");

            var subCategoryDto = _mapper.Map<SubCategoryDto>(subCategory);

            return subCategoryDto;
        }

        public async Task<SubCategoryDto> UpdateSubCategory(long id, CreateUpdateSubCategoryViewModel viewModel, User loggedUser)
        {
            if (!loggedUser.IsAdmin)
                throw new Exception("User not admin");

            var subCategory = await _repository.GetByIdClean(id)
               ?? throw new Exception("SubCategory not found");

            var updatedSubCategory = _factory.Update(subCategory, viewModel);

            await _repository.Save();

            var subCategoryDto = _mapper.Map<SubCategoryDto>(updatedSubCategory);

            return subCategoryDto;
        }
    }
}