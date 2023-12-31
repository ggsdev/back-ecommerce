﻿namespace E_Commerce.Shared
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task Save();
        Task<List<T>> GetAllClean();
        Task<T?> GetByIdClean(int id);
        Task<bool> AnyById(int id);
        Task AddRange(List<T> entities);
        void UpdateRange(List<T> entities);
        void DeleteRange(List<T> entities);
        Task<int> Count();
    }
}
