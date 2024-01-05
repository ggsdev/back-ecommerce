using E_Commerce.Domain.Product.Images.Entites;
using E_Commerce.Domain.Product.Images.Interfaces;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Images.Factories
{
    internal class ImageFactory : IImageFactory
    {
        public Image Create(CreateUpdateImageViewModel viewModel)
        {
            return new Image
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                ImageContent = Convert.FromBase64String(viewModel.ImageContent),
                IsShowCase = viewModel.IsShowCase,
            };
        }

        public Image Update(Image image, CreateUpdateImageViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
