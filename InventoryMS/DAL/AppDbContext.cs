using InventoryMS.DAL.Entity;
using InventoryMS.DAL.SqlModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
     
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
      

        public DbSet<Country> Countries { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Thana> Thanas { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStockDetails> ProductStockDetails { get; set; }
        public DbSet<PersonnelInfo> PersonnelInfo { get; set; }

        public DbSet<ProductSales> ProductSales { get; set; }

        public DbSet<ProductStock> ProductStock { get; set; }

        public DbQuery<ProductDetailsForStock> ProductDetailsForStock { get; set; }
    }
}
