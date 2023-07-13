using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Interfaces
{
    public interface IPartyHelper: IHelper<Party>
    {
        void RemoveByIdProduct(int id);
        void RemoveByIdWarehouse(int id);
    }
}
