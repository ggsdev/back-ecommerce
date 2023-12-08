using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.DTOs.ViewModels.Infos;

namespace E_Commerce.Domain.ControlAccess.Infos.Interfaces
{
    public interface IInfoFactory
    {
        Info Create(CreateUpdateInfoViewModel infoViewModel, CreateUpdateAddressViewModel address);
        void UpdateInfo(Info info, CreateUpdateInfoViewModel infoViewModel);
        void UpdateAddress(Address address, CreateUpdateAddressViewModel addressViewModel);
    }
}
