using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Models.HelperClasses
{
    public class WarehouseHelper : Warehouse, IWarehouseHelper
    {
        readonly PharmacyDB _pharmacyDB;
        readonly Warehouse _warehouse;
        public WarehouseHelper(PharmacyDB pharmacyDB, Warehouse warehouse)
        {
            _pharmacyDB = pharmacyDB;
            _warehouse = warehouse;
        }

        void IWarehouseHelper.Add(out Warehouse newWarehouse)
        {
            newWarehouse = _warehouse;
            newWarehouse.Pharmacy = _pharmacyDB.Pharmacies.Find(_warehouse.Pharmacy.Id);
            _pharmacyDB.Warehouses.Add(newWarehouse);
            _pharmacyDB.SaveChanges();
        }

        void IWarehouseHelper.Remove()
        {
            foreach (Party party in _warehouse.Parties)
            {
                IPartyHelper partyhelper = new PartyHelper(_pharmacyDB, party);
                partyhelper.Remove();
            }
            _pharmacyDB.Warehouses.Remove(_warehouse);
            _pharmacyDB.SaveChanges();
        }
    }
}
