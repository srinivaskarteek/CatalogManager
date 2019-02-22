using Microsoft.EntityFrameworkCore;
using SE.Catalog.Models;
using SE.Catalog.Repository.DbMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace SE.Catalog.Repository
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<DeviceFamily> DeviceFamilies { get; set; }
        public DbSet<ProductFamily> ProductFamilies { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<PackageComment> PackageComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeviceFamilyMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PackageMap());
            
            modelBuilder.ApplyConfiguration(new ProductFamilyMap());
            modelBuilder.ApplyConfiguration(new PackageCommentMap());
            modelBuilder.ApplyConfiguration(new VendorMap());

            //modelBuilder.Entity<Package>().HasOne(d=>d.DeviceFamily).WithMany(p=>p.)
        }
    }
}
