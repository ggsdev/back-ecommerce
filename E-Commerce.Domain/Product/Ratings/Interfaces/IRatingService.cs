using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Ratings.Interfaces
{
    internal interface IRatingService
    {
        Task<RatingDto> Create(CreateUpdateRatingViewModel createUpdateRatingViewModel);
    }
}