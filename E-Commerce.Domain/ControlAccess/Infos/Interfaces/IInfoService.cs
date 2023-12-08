using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.Infos;

namespace E_Commerce.Domain.ControlAccess.Infos.Interfaces
{
    internal interface IInfoService
    {
        Task<Info> CreateInfo(CreateUpdateInfoViewModel infoViewModel, CreateUpdateAddressViewModel addressViewModel);
        Task UpdateInfo(CreateUpdateInfoViewModel infoViewModel, Info userInfo);
        Task<AddressDto> UpdateAddress(CreateUpdateAddressViewModel addressViewModel, long addressId);
    }
}
