using E_Commerce.Domain.Product.Ratings.Entities;
using E_Commerce.Domain.Product.Ratings.Interfaces;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Ratings.Services
{
    internal class RatingService(IRatingRepository repository, IRatingFactory factory)
    {
        private readonly IRatingRepository _repository = repository;
        private readonly IRatingFactory _factory = factory;

        public async Task<Rating> Create(CreateUpdateRatingViewModel createUpdateRatingViewModel)
        {
            //adicionar validação de order concluida, pelo orderId, usuarios só poderão avaliar produtos de pedidos concluidos

            var createdRating = _factory.Create(createUpdateRatingViewModel);

            await _repository.Add(createdRating);

            await _repository.Save();

            return createdRating;
        }
    }
}