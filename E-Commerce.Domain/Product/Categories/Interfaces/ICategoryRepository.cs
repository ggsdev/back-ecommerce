using E_Commerce.Shared;
using E_Commerce.Domain.Product.Categories.Entities;

namespace E_Commerce.Domain.Product.Categories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<bool> AnyByName(string name, long? id = null);
        Task<List<Category>> GetAll(FilterQuery queryParams);
    }
}
