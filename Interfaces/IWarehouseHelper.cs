using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Interfaces
{
    public interface IWarehouseHelper
    {
        public void Add(out Warehouse newWarehouse);
        public void Remove();
    }
}
