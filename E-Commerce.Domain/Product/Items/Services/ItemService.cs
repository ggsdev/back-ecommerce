using AutoMapper;
using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.Product.Images.Interfaces;
using E_Commerce.Domain.Product.Items.Interfaces;
using E_Commerce.Domain.Product.SubCategories.Interfaces;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Items.Services
{
    internal class ItemService(IItemRepository itemRepository, IItemFactory itemFactory, IMapper mapper, IImageService imageService, ISubCategoryRepository subCategoryRepository) : IItemService
    {
        private readonly IItemRepository _repository = itemRepository;
        private readonly ISubCategoryRepository _subCategoryRepository = subCategoryRepository;
        private readonly IItemFactory _factory = itemFactory;
        private readonly IMapper _mapper = mapper;
        private readonly IImageService _imageService = imageService;

        public async Task<ItemDto> CreateItem(CreateUpdateItemViewModel viewModel, User loggedUser)
        {
            if (!loggedUser.IsAdmin)
                throw new UnauthorizedAccessException("User not admin");

            var anyInDatabase = await _repository.AnyByName(viewModel.Name);

            if (anyInDatabase)
                throw new Exception("Already registered in database");

            var subCategoryInDatabase = await _subCategoryRepository.GetByIdClean(viewModel.SubCategoryId!.Value)
                ?? throw new Exception("SubCategory not found");

            var images = await _imageService.CreateImages(viewModel.Images);

            var createdItem = _factory.Create(viewModel, images);

            await _repository.Add(createdItem);

            await _repository.Save();

            var itemDto = _mapper.Map<ItemDto>(createdItem);

            return itemDto;
        }

        public async Task DeleteItem(long id, User loggedUser)
        {
            if (!loggedUser.IsAdmin)
                throw new UnauthorizedAccessException("User not admin");

            var item = await _repository.GetByIdClean(id)
                ?? throw new Exception("Not found");

            _repository.Delete(item);

            await _repository.Save();

            return;
        }

        public async Task<ItemDto?> GetItemById(long id)
        {
            var item = await _repository.GetByIdClean(id)
               ?? throw new Exception("Not found");

            var itemDto = _mapper.Map<ItemDto>(item);

            return itemDto;
        }

        public async Task<PaginatedDataDTO<ItemDto>> GetItems(FilterQuery queryParams, string requestUrl, CancellationToken ct)
        {
            var totalCount = await _repository.Count();

            var items = await _repository.GetAll(queryParams, ct);

            var itemsDto = _mapper.Map<List<ItemDto>>(items);

            var paginatedData = APIGetReturn.Paginate(itemsDto, queryParams.PageNumber, queryParams.PageSize, totalCount, requestUrl);

            return paginatedData;
        }

        public async Task<ItemDto> UpdateItem(CreateUpdateItemViewModel viewModel, long id, User loggedUser)
        {
            if (!loggedUser.IsAdmin)
                throw new UnauthorizedAccessException("User not admin");

            var anyInDatabase = await _repository.AnyByName(viewModel.Name, id);

            if (anyInDatabase)
                throw new Exception("Already registered in database");

            var updatedItem = await _repository.GetById(id)
                ?? throw new Exception("Not found");

            var images = await _imageService.CreateImages(viewModel.Images);

            updatedItem = _factory.Update(updatedItem, viewModel, images);

            _repository.Update(updatedItem);

            await _repository.Save();

            var updatedItemDto = _mapper.Map<ItemDto>(updatedItem);

            return updatedItemDto;
        }
    }
}
