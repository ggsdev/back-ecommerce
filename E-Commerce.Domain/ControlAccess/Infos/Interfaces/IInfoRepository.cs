using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Shared;

namespace E_Commerce.Domain.ControlAccess.Infos.Interfaces
{
    public interface IInfoRepository : IBaseRepository<Info>
    {
        Task<bool> AnyByEmailOrCellphone(string email, string cellphone, int? id = null);

        Task<Address?> GetAddressById(int addressId);
    }
}
