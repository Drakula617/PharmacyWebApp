using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Interfaces
{
    public interface IProductHelper
    {
        public void Remove();
        public void Add(out Product newProduct);
    }
}
