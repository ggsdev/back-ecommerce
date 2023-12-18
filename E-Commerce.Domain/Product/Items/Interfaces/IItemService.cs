using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Items.Interfaces
{
    public interface IItemService
    {
        Task<ItemDto> CreateItem(CreateUpdateItemViewModel viewModel, User loggedUser);
        Task<ItemDto> UpdateItem(CreateUpdateItemViewModel viewModel, long id, User loggedUser);
        Task DeleteItem(long id, User loggedUser);
        Task<ItemDto?> GetItemById(long id);
        Task<PaginatedDataDTO<ItemDto>> GetItems(FilterQuery filterQuery, string requestUrl, CancellationToken ct);
    }
}
