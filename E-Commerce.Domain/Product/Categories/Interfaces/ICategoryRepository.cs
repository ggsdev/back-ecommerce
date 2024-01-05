using E_Commerce.Domain.Product.Categories.Entities;
using E_Commerce.Shared;

namespace E_Commerce.Domain.Product.Categories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<bool> AnyByName(string name, int? id = null);
        Task<List<Category>> GetAll(FilterQuery queryParams);
        Task<Category?> GetSubCategory(int id);
    }
}
