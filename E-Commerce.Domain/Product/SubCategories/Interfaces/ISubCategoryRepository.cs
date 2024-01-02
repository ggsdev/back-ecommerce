using E_Commerce.Shared;
using E_Commerce.Domain.Product.SubCategories.Entities;

namespace E_Commerce.Domain.Product.SubCategories.Interfaces
{
    public interface ISubCategoryRepository : IBaseRepository<SubCategory>
    {
        Task<bool> AnyByName(string name, long? id = null);
        Task<List<SubCategory>> GetAll(FilterQuery queryParams);
    }
}
