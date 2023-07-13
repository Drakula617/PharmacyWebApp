using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Interfaces
{
    public interface IWarehouseHelper: IHelper<Warehouse>
    {

        /// <summary>
        /// Удаление складов по Id аптеки
        /// </summary>
        /// <param name="id"></param>
        void RemoveByIdPharmacy(int id);
    }
}
