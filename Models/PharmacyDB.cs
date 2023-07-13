using Microsoft.EntityFrameworkCore;
using PharmacyWebApp.Models.Tables;
using PharmacyWebApp.Models.Tables.ProductClasses;

namespace PharmacyWebApp.Models
{
    public class PharmacyDB : DbContext
    {
        public PharmacyDB(DbContextOptions<PharmacyDB> options) : base(options)
        {
            
        }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

    }
}
