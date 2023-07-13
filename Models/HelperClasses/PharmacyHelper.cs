using Microsoft.EntityFrameworkCore;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models.Tables;
using System.Diagnostics;

namespace PharmacyWebApp.Models.HelperClasses
{
    public class PharmacyHelper : IPharmacyHelper
    {
        readonly PharmacyDB _pharmacyDB;
        readonly IWarehouseHelper _warehouseHelper;
        public PharmacyHelper(PharmacyDB pharmacyDB, IWarehouseHelper warehouseHelper)
        {
            _pharmacyDB = pharmacyDB;
            _warehouseHelper = warehouseHelper;
        }
        public void Add(Pharmacy obj)
        {
            _pharmacyDB.Pharmacies.Add(obj);
            _pharmacyDB.SaveChanges();
        }
        public IEnumerable<Pharmacy> GetAll(int id)
        {
            return _pharmacyDB.Pharmacies.ToList();
        }
        public void Remove(int id)
        {
            _warehouseHelper.RemoveByIdPharmacy(id);
            _pharmacyDB.Database.ExecuteSqlRaw($"Delete from Pharmacy where Id = {id}");
            
        }
    }
}
