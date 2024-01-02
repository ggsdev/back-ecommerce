using AutoMapper;
using E_Commerce.Domain.Product.Ratings.Interfaces;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Ratings.Services
{
    internal class RatingService(IRatingRepository repository, IRatingFactory factory, IMapper mapper) : IRatingService
    {
        private readonly IRatingRepository _repository = repository;
        private readonly IRatingFactory _factory = factory;
        private readonly IMapper _mapper = mapper;

        public async Task<RatingDto> Create(CreateUpdateRatingViewModel createUpdateRatingViewModel)
        {
            //adicionar validação de order concluida, pelo orderId, usuarios só poderão avaliar produtos de pedidos concluidos

            var createdRating = _factory.Create(createUpdateRatingViewModel);

            await _repository.Add(createdRating);

            await _repository.Save();

            var ratingDto = _mapper.Map<RatingDto>(createdRating);

            return ratingDto;
        }
    }
}