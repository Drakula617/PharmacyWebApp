using PharmacyWebApp.Models.Tables;
using PharmacyWebApp.Interfaces;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace PharmacyWebApp.Models.HelperClasses
{
    public class ProductHelper: IProductHelper
    {
        readonly PharmacyDB _pharmacyDB;
        readonly Product _product;
        public ProductHelper(PharmacyDB pharmacyDB, Product product) 
        {
            _pharmacyDB = pharmacyDB;
            _product = product;
        }

        void IProductHelper.Add(out Product newProduct)
        {
            newProduct = _pharmacyDB.Products.Add(_product).Entity;
            _pharmacyDB.Products.Add(_product);
            _pharmacyDB.SaveChanges();
        }

        void IProductHelper.Remove()
        {
            foreach (Party party in _product.Parties)
            {
                IPartyHelper partyhelper = new PartyHelper(_pharmacyDB, party);
                partyhelper.Remove();
                
            }
            _pharmacyDB.Products.Remove(_product);
            _pharmacyDB.SaveChanges();
        }
    }
}
