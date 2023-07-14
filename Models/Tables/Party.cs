using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyWebApp.Models.Tables
{
    [Table("Party")]
    public class Party
    {
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public int CountProducts { get; set; }
    }
}
