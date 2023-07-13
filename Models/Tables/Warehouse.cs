using PharmacyWebApp.Models.Tables.ProductClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PharmacyWebApp.Models.Tables
{
    [Table("Warehouse")]
    public class Warehouse:BaseModel
    {

        public virtual Pharmacy Pharmacy { get; set; }
        [JsonIgnore]
        public virtual ICollection<Party> Parties { get; set; }

        [NotMapped]
        [JsonIgnore]
        public List<ProductsInWarehouse> ProductsInWarehouses 
        {
            get
            {
                if(Parties != null)
                return Parties.GroupBy(c => c.Product)
                    .Select(v => new ProductsInWarehouse {  Product = v.Key, CountProducts = v.Sum(s => s.CountProducts) })
                    .ToList();
                else
                    return new List<ProductsInWarehouse>();
            }
        }
    }
}
