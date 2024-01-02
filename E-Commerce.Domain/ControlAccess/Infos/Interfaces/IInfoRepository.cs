using E_Commerce.Shared;
using E_Commerce.Domain.ControlAccess.Infos.Entities;

namespace E_Commerce.Domain.ControlAccess.Infos.Interfaces
{
    public interface IInfoRepository : IBaseRepository<Info>
    {
        Task<bool> AnyByEmailOrCellphone(string email, string cellphone, long? id = null);

        Task<Address?> GetAddressById(long addressId);
    }
}
