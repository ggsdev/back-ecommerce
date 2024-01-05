using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.ControlAccess;

namespace E_Commerce.Domain.ControlAccess.Infos.Interfaces
{
    public interface IInfoService
    {
        Task<Info> CreateInfo(CreateUpdateInfoViewModel infoViewModel, CreateUpdateAddressViewModel addressViewModel);
        Task<InfoDto> UpdateInfo(CreateUpdateInfoViewModel infoViewModel, Info userInfo);
        Task<AddressDto> UpdateAddress(CreateUpdateAddressViewModel addressViewModel, int addressId);
    }
}
