using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SE.Catalog.Models;
using System;

namespace SE.Catalog.Repository.Seeding
{
    public class UserData
    {
        public static void Seed(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.HasData(new User
            {
                Id = 1,
                CreatedOn = DateTime.Today,
                Email = "admin1@gmail.com",
                IsActive = true,
                LastModified = DateTime.Today,
                Name = "Admin1",
                Password = "admin",
                Role = Roles.Admin
            });
            modelBuilder.HasData(new User
            {
                Id = 2,
                CreatedOn = DateTime.Today,
                Email = "vendor1@gmail.com",
                IsActive = true,
                LastModified = DateTime.Today,
                Name = "Vendor1",
                Password = "vendor",
                Role = Roles.Vendor
            });
            modelBuilder.HasData(new User
            {
                Id = 3,
                CreatedOn = DateTime.Today,
                Email = "lob1@gmail.com",
                IsActive = true,
                LastModified = DateTime.Today,
                Name = "Lob1",
                Password = "lob",
                Role = Roles.Lob
            });
        }
    }
}
