using E_Commerce.Domain.Product.Images.Entites;
using E_Commerce.Domain.Product.Images.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infra.Data.Product.Images.Repositories
{
    internal class ImageRepository(DataContext context) : BaseRepository<Image>(context), IImageRepository
    {
        private readonly DataContext _context = context;
        public async Task<bool> AnyByContent(byte[] content)
        {
            return await _context.Images
                .Where(x => x.ImageContent == content)
                .AnyAsync();
        }

        public async Task<Image?> GetByContent(byte[] content)
        {
            return await _context.Images
               .Where(x => x.ImageContent == content)
               .FirstOrDefaultAsync();
        }
    }
}
