using AutoMapper;
using E_Commerce.Domain.Product.Categories.Interfaces;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Product;
using E_Commerce.Shared;

namespace E_Commerce.Domain.Product.Categories.Services
{
    internal class CategoryService(ICategoryRepository repository, ICategoryFactory factory, IMapper mapper) : ICategoryService
    {
        private readonly ICategoryRepository _repository = repository;
        private readonly ICategoryFactory _factory = factory;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryDto> CreateCategory(CreateUpdateCategoryViewModel viewModel)
        {
            var anyByName = await _repository.AnyByName(viewModel.Name);

            if (anyByName)
                throw new Exception("Category already registered");

            var createdCategory = _factory.Create(viewModel);

            await _repository.Add(createdCategory);

            await _repository.Save();

            var categoryDto = _mapper.Map<CategoryDto>(createdCategory);
            return categoryDto;
        }

        public async Task DeleteCategory(int id)
        {
            var categoryToBeDeleted = await _repository.GetByIdClean(id)
                ?? throw new Exception("Category not found");

            _repository.Delete(categoryToBeDeleted);

            await _repository.Save();

            return;
        }

        public async Task<CategoryDto> UpdateCategory(CreateUpdateCategoryViewModel viewModel, int id)
        {
            var categoryInDatabase = await _repository.GetByIdClean(id)
                ?? throw new Exception("Category not found");

            var anyByName = await _repository
                .AnyByName(viewModel.Name, id);

            if (anyByName)
                throw new Exception("Category already registered");

            var updatedCategory = _factory.Update(categoryInDatabase, viewModel);

            await _repository.Save();

            var categoryDto = _mapper.Map<CategoryDto>(updatedCategory);

            return categoryDto;
        }

        public async Task<PaginatedDataDTO<CategoryDto>> GetAllCategories(FilterQuery queryParams, string requestUrl)
        {
            var totalCount = await _repository.Count();

            var categories = await _repository.GetAll(queryParams);

            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            var paginatedData = APIGetReturn.Paginate(categoriesDto, queryParams.PageNumber, queryParams.PageSize, totalCount, requestUrl);

            return paginatedData;
        }
        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category = await _repository.GetByIdClean(id)
                ?? throw new Exception("Category not found");

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }
    }
}
