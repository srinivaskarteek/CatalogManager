using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SE.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SE.Catalog.Repository.DbMap
{
    public class ProductFamilyMap : IEntityTypeConfiguration<ProductFamily>
    {
        public void Configure(EntityTypeBuilder<ProductFamily> builder)
        {
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Description).IsRequired();
        }
    }
}
