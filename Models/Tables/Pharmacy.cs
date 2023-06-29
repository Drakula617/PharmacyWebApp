﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using PharmacyWebApp.Models.Tables.ProductClasses;

namespace PharmacyWebApp.Models.Tables
{
    [Table("Pharmacy")]
    public class Pharmacy
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        [JsonIgnore]
        public virtual ICollection<Warehouse> Warehouses { get; set; }

        [NotMapped]
        public List<ProductsInPharmacy> ProductsInPharmacies
        {
            get
            {
                return Warehouses.SelectMany(c => c.ProductsInWarehouses)
                .GroupBy(c => c.Product)
                .Select(cc => new ProductsInPharmacy()
                { Product = cc.Key, CountProducts = cc.Sum(ccc => ccc.CountProducts) }).ToList();
            }
        }
    }
}
