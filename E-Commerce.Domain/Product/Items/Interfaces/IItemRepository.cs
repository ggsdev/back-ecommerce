using E_Commerce.Shared;
using E_Commerce.Domain.Product.Items.Entities;

namespace E_Commerce.Domain.Product.Items.Interfaces
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        Task<bool> AnyByName(string name, int? id = null);

        Task<Item?> GetById(int id);
        Task<List<Item>> GetAll(FilterQuery queryParams, CancellationToken ct);
    }
}
