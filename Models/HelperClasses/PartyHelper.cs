using Microsoft.EntityFrameworkCore;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models.Tables;
using System.IO;

namespace PharmacyWebApp.Models.HelperClasses
{
    public class PartyHelper : Party, IPartyHelper
    { 
        readonly PharmacyDB _pharmacyDB;
        public PartyHelper(PharmacyDB pharmacyDB) 
        {
            _pharmacyDB = pharmacyDB;
        }
        public void Add(Party obj)
        {
            _pharmacyDB.Parties.Add(obj);
            _pharmacyDB.SaveChanges();
        }

        public IEnumerable<Party> GetAll(int id)
        {
            return _pharmacyDB.Parties.Where(p => p.Warehouse.Id == id).ToList();
        }

        public void Remove(int id)
        {
            _pharmacyDB.Database.ExecuteSqlRaw($"Delete from Party where id = {id}");
        }

        public void RemoveByIdProduct(int id)
        {
            _pharmacyDB.Database.ExecuteSqlRaw($"Delete from Party where ProductId = {id}");
        }

        public void RemoveByIdWarehouse(int id)
        {
            _pharmacyDB.Database.ExecuteSqlRaw($"Delete from Party where WarehouseId = {id}");
        }
    }
}
