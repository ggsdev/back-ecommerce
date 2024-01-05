using AutoMapper;
using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.ControlAccess;

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
                throw new Exception("Info already registered, email or cellphone duplicated");

            var createdInfo = _factory
                .Create(infoViewModel, addressViewModel);

            await _repository.Add(createdInfo);

            return createdInfo;
        }

        public async Task<AddressDto> UpdateAddress(CreateUpdateAddressViewModel addressViewModel, int addressId)
        {
            var addressInDatabase = await _repository.GetAddressById(addressId)
                ?? throw new Exception("Address not found");

            var updatedAddress = _factory.UpdateAddress(addressInDatabase, addressViewModel);

            await _repository.Save();

            var addressDto = _mapper.Map<AddressDto>(updatedAddress);

            return addressDto;
        }

        public async Task<InfoDto> UpdateInfo(CreateUpdateInfoViewModel infoViewModel, Info userInfo)
        {
            var isInfoAlreadyRegistered = await _repository
               .AnyByEmailOrCellphone(infoViewModel.Email, infoViewModel.Cellphone, userInfo.Id);

            if (isInfoAlreadyRegistered)
                throw new Exception("Info already registered");

            var updatedInfo = _factory.UpdateInfo(userInfo, infoViewModel);

            var infoDto = _mapper.Map<InfoDto>(updatedInfo);

            return infoDto;
        }
    }
}
