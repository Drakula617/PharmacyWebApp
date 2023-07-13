using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models.Tables;
using System.Diagnostics;

namespace PharmacyWebApp.Models.HelperClasses
{
    public class PharmacyHelper: IPharmacyHelper
    {
        readonly PharmacyDB _pharmacyDB;
        readonly Pharmacy _pharmacy;
        public PharmacyHelper(PharmacyDB pharmacyDB, Pharmacy pharmacy)
        {
            _pharmacyDB = pharmacyDB;
            _pharmacy = pharmacy;
        }
        void IPharmacyHelper.Add(out Pharmacy newpharmacy)
        {
            newpharmacy = _pharmacyDB.Pharmacies.Add(_pharmacy).Entity;
            _pharmacyDB.SaveChanges();
        }

        void IPharmacyHelper.Remove()
        {
            foreach (Warehouse warehouse in _pharmacy.Warehouses)
            {
                IWarehouseHelper warehouseHelper = new WarehouseHelper(_pharmacyDB, warehouse);
                warehouseHelper.Remove();
            }
            _pharmacyDB.Pharmacies.Remove(_pharmacy);
            _pharmacyDB.SaveChanges();
        }
    }
}
