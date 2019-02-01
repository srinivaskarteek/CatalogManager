using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SE.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SE.Catalog.Repository.DbMap
{
    public class PackageMap : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.BlobURL).IsRequired();
            builder.Property(a => a.FileName).IsRequired();
            builder.Property(a => a.HWVersion).IsRequired();
            builder.Property(a => a.OwnerId).IsRequired();
            builder.Property(a => a.ProductId).IsRequired();
            builder.Property(a => a.ProductName).IsRequired();
            builder.Property(a => a.ProfileType).IsRequired();
            builder.Property(a => a.SWVersion).IsRequired();
            builder.Property(a => a.Status).IsRequired();


        }
    }
}
