namespace E_Commerce.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task Save();
        Task<List<T>> GetAllClean();
        Task<T?> GetByIdClean(long id);
        Task<bool> AnyById(long id);
        Task AddRange(List<T> entities);
        void UpdateRange(List<T> entities);
        void DeleteRange(List<T> entities);
        Task<int> Count();
    }
}
