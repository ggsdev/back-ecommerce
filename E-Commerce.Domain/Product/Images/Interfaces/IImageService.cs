using E_Commerce.Domain.Product.Images.Entites;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Images.Interfaces
{
    public interface IImageService
    {
        Task<List<Image>> CreateImages(List<CreateUpdateImageViewModel> body);
    }
}
