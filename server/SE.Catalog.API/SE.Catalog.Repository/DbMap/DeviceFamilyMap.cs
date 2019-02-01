using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SE.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SE.Catalog.Repository.DbMap
{
    public class DeviceFamilyMap : IEntityTypeConfiguration<DeviceFamily>
    {
        public void Configure(EntityTypeBuilder<DeviceFamily> builder)
        {
           builder.Property(a => a.Name).IsRequired();
           builder.Property(a => a.Description).IsRequired();
          // builder.HasMany<Package>().WithOne(b=> b.DeviceFamily);
        }
    }
}
