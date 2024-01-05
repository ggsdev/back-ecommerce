using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infra.Data
{
    public class BaseRepository<T>(DataContext context) : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context = context;

        public async Task Add(T entity)
        {
            await _context.AddAsync(entity);
        }
        public async Task<bool> AnyById(int id)
        {
            return await _context
                .Set<T>()
                .Where(x => x.Id.Equals(id))
                .AnyAsync();
        }
        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void DeleteRange(List<T> entities)
        {
            _context.RemoveRange(entities);
        }

        public void UpdateRange(List<T> entities)
        {
            _context.UpdateRange(entities);
        }

        public async Task AddRange(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<List<T>> GetAllClean()
        {
            return await _context
                    .Set<T>()
                    .ToListAsync();
        }
        public async Task<T?> GetByIdClean(int id)
        {
            return await _context
                    .Set<T>()
                    .Where(x => x.Id.Equals(id))
                    .FirstOrDefaultAsync();
        }
        public async Task<int> Count()
        {
            return await _context
                    .Set<T>()
                    .CountAsync();
        }
    }
}
