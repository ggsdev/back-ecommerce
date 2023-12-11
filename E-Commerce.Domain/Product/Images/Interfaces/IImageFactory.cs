using E_Commerce.Domain.Product.Images.Entites;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Images.Interfaces
{
    public interface IImageFactory
    {
        Image Create(CreateUpdateImageViewModel viewModel);
        Image Update(Image image, CreateUpdateImageViewModel viewModel);
    }
}
