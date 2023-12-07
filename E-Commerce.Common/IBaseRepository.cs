namespace E_Commerce.Common
{
    public interface IBaseRepository<T> where T : class
    {
        Task Add(T entity);
        void Update(T entity);
        Task Save();
        Task<List<T>> GetAll();
        Task<T?> GetById(long id);
    }
}
