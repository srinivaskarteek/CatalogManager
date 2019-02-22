﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SE.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SE.Catalog.Repository.DbMap
{
    public class VendorMap : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.URL).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}
