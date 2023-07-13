using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models.Tables;
using System.IO;

namespace PharmacyWebApp.Models.HelperClasses
{
    public class PartyHelper : Party, IPartyHelper
    {
        readonly PharmacyDB _pharmacyDB;
        readonly Party _party;
        public PartyHelper(PharmacyDB pharmacyDB, Party party) 
        {
            _pharmacyDB = pharmacyDB;
            _party = party;
        }

        void IPartyHelper.Add(out Party newParty)
        {
            newParty = _party;
            newParty.Warehouse = _pharmacyDB.Warehouses.Find(_party.Warehouse.Id);
            newParty.Product = _pharmacyDB.Products.Find(_party.Product.Id);
            _pharmacyDB.Parties.Add(newParty);
            _pharmacyDB.SaveChanges();
        }

        void IPartyHelper.Remove()
        {
           _pharmacyDB.Parties.Remove(_party);
           _pharmacyDB.SaveChanges();
        }
    }
}
