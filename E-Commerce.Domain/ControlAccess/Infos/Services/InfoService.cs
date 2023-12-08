using AutoMapper;
using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Infos;

namespace E_Commerce.Domain.ControlAccess.Infos.Services
{
    internal class InfoService(IInfoRepository repository, IInfoFactory factory, IMapper mapper) : IInfoService
    {
        private readonly IInfoRepository _repository = repository;
        private readonly IInfoFactory _factory = factory;
        private readonly IMapper _mapper = mapper;

        public async Task<Info> CreateInfo(CreateUpdateInfoViewModel infoViewModel, CreateUpdateAddressViewModel addressViewModel)
        {
            var isInfoAlreadyRegistered = await _repository
                .AnyByEmailOrCellphone(infoViewModel.Email, infoViewModel.Cellphone);

            if (isInfoAlreadyRegistered)
                throw new Exception("Info already registered");

            var createdInfo = _factory
                .Create(infoViewModel, addressViewModel);

            await _repository.Add(createdInfo);

            await _repository.Save();

            return createdInfo;
        }

        public async Task<AddressDto> UpdateAddress(CreateUpdateAddressViewModel addressViewModel, long addressId)
        {
            var addressInDatabase = await _repository.GetAddressById(addressId)
                ?? throw new Exception("Address not found");

            _factory.UpdateAddress(addressInDatabase, addressViewModel);

            await _repository.Save();

            var addressDto = _mapper.Map<AddressDto>(addressInDatabase);

            return addressDto;
        }

        public async Task UpdateInfo(CreateUpdateInfoViewModel infoViewModel, Info userInfo)
        {
            var isInfoAlreadyRegistered = await _repository
               .AnyByEmailOrCellphone(infoViewModel.Email, infoViewModel.Cellphone, userInfo.Id);

            if (isInfoAlreadyRegistered)
                throw new Exception("Info already registered");

            _factory.UpdateInfo(userInfo, infoViewModel);
        }
    }
}
