using E_Commerce.Shared;
using E_Commerce.Domain.Product.Images.Entites;

namespace E_Commerce.Domain.Product.Images.Interfaces
{
    public interface IImageRepository : IBaseRepository<Image>
    {
        Task<bool> AnyByContent(byte[] content);
        Task<Image?> GetByContent(byte[] content);
    }
}
