using InventoryApplication.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.DataCon
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<SaleDetail> SaleDetails { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<ShopPhoto> ShopPhotos { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<UserPhoto> UserPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductSupplier>()
                    .HasKey(x => new {x.ProductID,x.SupplierID });
            base.OnModelCreating(builder);
        }

    }
}
