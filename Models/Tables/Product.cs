
//using Newtonsoft.Json;
//using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PharmacyWebApp.Models.Tables
{
    [Table("Product")]
    public class Product:BaseModel
    {


        [JsonIgnore]
        public virtual ICollection<Party> Parties { get; set; }


    }
}
