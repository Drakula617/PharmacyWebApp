﻿using Microsoft.EntityFrameworkCore;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Models.HelperClasses
{
    public class WarehouseHelper : Warehouse, IWarehouseHelper
    {
        readonly PharmacyDB _pharmacyDB;
        readonly IPartyHelper _partyHelper;
        public WarehouseHelper(PharmacyDB pharmacyDB, IPartyHelper partyHelper)
        {
            _pharmacyDB = pharmacyDB;
            _partyHelper = partyHelper;
        }
        public Warehouse Add(Warehouse obj)
        {
            obj.Pharmacy = _pharmacyDB.Pharmacies.Find(obj.Pharmacy.Id);
            var addwarehouse = _pharmacyDB.Warehouses.Add(obj);
            _pharmacyDB.SaveChanges();
            return addwarehouse.Entity;
        }
        public IEnumerable<Warehouse> GetAll(int id)
        {
            return _pharmacyDB.Warehouses.Where(c => c.Pharmacy.Id == id);
        }

        public void Remove(int id)
        {
            _partyHelper.RemoveByIdWarehouse(id);
            _pharmacyDB.Database.ExecuteSqlRaw($"Delete from Warehouse where Id ={id}");
        }

        public void RemoveByIdPharmacy(int id)
        {
            _pharmacyDB.Database.ExecuteSqlRaw($"Delete from Warehouse where PharmacyId ={id}");
        }
    }
}
