using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Interfaces
{
    public interface IPartyHelper
    {
        public void Remove();
        public void Add(out Party newParty);
    }
}
