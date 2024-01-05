using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.DTOs.ViewModels.ControlAccess;

namespace E_Commerce.Domain.ControlAccess.Infos.Interfaces
{
    public interface IInfoFactory
    {
        Info Create(CreateUpdateInfoViewModel infoViewModel, CreateUpdateAddressViewModel address);
        Info UpdateInfo(Info info, CreateUpdateInfoViewModel infoViewModel);
        Address UpdateAddress(Address address, CreateUpdateAddressViewModel addressViewModel);
    }
}
