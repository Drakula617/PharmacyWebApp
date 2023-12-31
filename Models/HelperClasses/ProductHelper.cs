﻿using PharmacyWebApp.Models.Tables;
using PharmacyWebApp.Interfaces;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace PharmacyWebApp.Models.HelperClasses
{
    public class ProductHelper: IProductHelper
    {
        readonly PharmacyDB _pharmacyDB;
        readonly IPartyHelper _partyHelper;
        public ProductHelper(PharmacyDB pharmacyDB, IPartyHelper partyHelper) 
        {
            _pharmacyDB = pharmacyDB;
            _partyHelper = partyHelper;
        }

        public Product Add(Product obj)
        {
            Product newporoduct = _pharmacyDB.Products.Add(obj).Entity;
            _pharmacyDB.SaveChanges();
            return newporoduct;
        }

        public IEnumerable<Product> GetAll(int id)
        {
            return _pharmacyDB.Products.ToList();
        }

        public void Remove(int id)
        {
            _partyHelper.RemoveByIdProduct(id);
            _pharmacyDB.Database.ExecuteSqlRaw($"Delete from Product where id = {id}");
            
        }


    }
}
