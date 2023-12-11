using E_Commerce.Domain.Product.Images.Entites;
using E_Commerce.Domain.Product.Images.Interfaces;
using E_Commerce.Domain.Product.Items.Entities;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Images.Services
{
    internal class ImageService(IImageRepository imageRepository) : IImageService
    {
        private readonly IImageRepository _imageRepository = imageRepository;

        public async Task<List<Image>> CreateImages(List<CreateUpdateImageViewModel> bodyImages, Item item)
        {
            var images = new List<Image>();

            foreach (var image in bodyImages)
            {
                var imageContent = Convert.FromBase64String(image.ImageContent);
                var imageInDatabase = await _imageRepository.GetByContent(imageContent);

                if (imageInDatabase is null)
                {
                    var createdImage = new Image
                    {
                        ImageContent = imageContent,
                        Name = image.Name,
                        IsShowCase = image.IsShowCase,
                        Item = item
                    };

                    images.Add(createdImage);
                    await _imageRepository.Add(createdImage);
                }
                else
                {
                    images.Add(imageInDatabase);
                }
            }

            return images;
        }
    }
}
