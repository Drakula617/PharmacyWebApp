using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Interfaces
{
    public interface IPharmacyHelper
    {
        public void Add(out Pharmacy newpharmacy);
        public void Remove();
    }
}
