using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Product;
using E_Commerce.Shared;

namespace E_Commerce.Domain.Product.Items.Interfaces
{
    public interface IItemService
    {
        Task<ItemDto> CreateItem(CreateUpdateItemViewModel viewModel);
        Task<ItemDto> UpdateItem(CreateUpdateItemViewModel viewModel, int id);
        Task DeleteItem(int id);
        Task<ItemDto?> GetItemById(int id);
        Task<PaginatedDataDTO<ItemDto>> GetItems(FilterQuery filterQuery, string requestUrl, CancellationToken ct);
    }
}
