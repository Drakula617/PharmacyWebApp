using Microsoft.EntityFrameworkCore;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models.Tables;
using System.Diagnostics;
using System.Web.Http;

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
        public Pharmacy Add(Pharmacy obj)
        {
            Pharmacy newpharmacy = _pharmacyDB.Pharmacies.Add(obj).Entity;
            _pharmacyDB.SaveChanges();
            return newpharmacy;
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
