using E_Commerce.Shared;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Items.Interfaces
{
    public interface IItemService
    {
        Task<ItemDto> CreateItem(CreateUpdateItemViewModel viewModel, User loggedUser);
        Task<ItemDto> UpdateItem(CreateUpdateItemViewModel viewModel, int id, User loggedUser);
        Task DeleteItem(int id, User loggedUser);
        Task<ItemDto?> GetItemById(int id);
        Task<PaginatedDataDTO<ItemDto>> GetItems(FilterQuery filterQuery, string requestUrl, CancellationToken ct);
    }
}
