using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using E_Commerce.DTOs.ViewModels.Infos;

namespace E_Commerce.Domain.ControlAccess.Infos.Factories
{
    internal class InfoFactory : IInfoFactory
    {
        public Info Create(CreateUpdateInfoViewModel infoViewModel, CreateUpdateAddressViewModel addressViewModel)
        {
            var createdAddress = new Address
            {
                City = addressViewModel.City,
                Number = addressViewModel.Number,
                State = addressViewModel.State,
                Street = addressViewModel.Street,
                ZipCode = addressViewModel.ZipCode,
                Complement = addressViewModel.Complement,
                Reference = addressViewModel.Reference
            };

            return new Info
            {
                Address = createdAddress,
                Cellphone = infoViewModel.Cellphone,
                Email = infoViewModel.Email,
            };
        }

        public void UpdateAddress(Address address, CreateUpdateAddressViewModel addressViewModel)
        {
            address.Street = addressViewModel.Street;
            address.Number = addressViewModel.Number;
            address.Complement = addressViewModel.Complement;
            address.City = addressViewModel.City;
            address.State = addressViewModel.State;
            address.ZipCode = addressViewModel.ZipCode;
            address.Reference = addressViewModel.Reference;
        }

        public void UpdateInfo(Info info, CreateUpdateInfoViewModel infoViewModel)
        {
            info.Cellphone = infoViewModel.Cellphone;
            info.Email = infoViewModel.Email;
        }
    }
}
