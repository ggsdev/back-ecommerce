using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.DTOs.ViewModels;

namespace E_Commerce.Domain.ControlAccess.Infos.Interfaces
{
    internal interface IInfoService
    {
        Task<Info> Create(InfoViewModel infoViewModel, Address address);
    }
}
