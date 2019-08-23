using InventoryMS.DAL.Entity;
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
    }
}
