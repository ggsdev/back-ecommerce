using E_Commerce.Common;
using E_Commerce.Domain.Product.Items.Entities;

namespace E_Commerce.Domain.Product.Items.Interfaces
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        Task<bool> AnyByName(string name, long? id = null);

        Task<Item?> GetById(long id);
        Task<List<Item>> GetAll(FilterQuery queryParams, CancellationToken ct);
    }
}
