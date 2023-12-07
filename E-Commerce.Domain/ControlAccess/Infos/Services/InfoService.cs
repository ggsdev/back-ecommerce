using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using E_Commerce.DTOs.ViewModels;

namespace E_Commerce.Domain.ControlAccess.Infos.Services
{
    internal class InfoService(IInfoRepository infoRepository) : IInfoService
    {
        private readonly IInfoRepository _repository = infoRepository;

        public async Task<Info> Create(InfoViewModel infoViewModel, AddressViewModel addressViewModel)
        {
            var isInfoAlreadyRegistered = await _repository
                .AnyByEmailOrCellphone(infoViewModel.Email, infoViewModel.Cellphone);

            if (isInfoAlreadyRegistered)
            {
                throw new Exception("Info already registered");
            }

            var createdAddress = new Address
            {
                City = addressViewModel.City,
                Number = addressViewModel.Number,
                State = addressViewModel.State,
                Street = addressViewModel.Street,
                ZipCode = addressViewModel.ZipCode
            };

            var createdInfo = new Info
            {
                Cellphone = infoViewModel.Cellphone,
                Email = infoViewModel.Email,
                Address = createdAddress,
            };

            await _repository.Add(createdInfo);

            await _repository.Save();

            return createdInfo;
        }
    }
}
