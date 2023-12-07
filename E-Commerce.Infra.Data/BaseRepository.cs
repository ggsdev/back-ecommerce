using E_Commerce.Common;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infra.Data
{
    public class BaseRepository<T>(DataContext context) : IBaseRepository<T> where T : class
    {
        private readonly DataContext _context = context;

        public async Task Add(T entity)
        {
            await _context.AddAsync(entity);
        }
        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<List<T>> GetAll()
        {
            return await _context
                .Set<T>()
                .ToListAsync();
        }
        public async Task<T?> GetById(long id)
        {
            return await _context
               .Set<T>()
               .FindAsync(id);
        }
    }
}
