﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SE.Catalog.Repository;

namespace SE.Catalog.Repository.Migrations
{
    [DbContext(typeof(CatalogContext))]
    partial class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SE.Catalog.Models.DeviceFamily", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("DeviceFamilies");
                });

            modelBuilder.Entity("SE.Catalog.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlobURL")
                        .IsRequired();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("DeviceFamilyId");

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<string>("HWVersion")
                        .IsRequired();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OwnerId");

                    b.Property<int>("ProductFamilyId");

                    b.Property<string>("ProductId")
                        .IsRequired();

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<string>("ProfileType")
                        .IsRequired();

                    b.Property<string>("SWVersion")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<DateTime>("UploadDate");

                    b.Property<int>("VendorId");

                    b.HasKey("Id");

                    b.HasIndex("DeviceFamilyId");

                    b.HasIndex("ProductFamilyId");

                    b.HasIndex("VendorId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("SE.Catalog.Models.PackageComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .IsRequired();

                    b.Property<int?>("PackageId");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageComments");
                });

            modelBuilder.Entity("SE.Catalog.Models.ProductFamily", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ProductFamilies");
                });

            modelBuilder.Entity("SE.Catalog.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 2, 8, 9, 49, 18, 961, DateTimeKind.Local));

                    b.Property<string>("Email");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, CreatedOn = new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), Email = "admin1@gmail.com", IsActive = true, LastModified = new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), Name = "Admin1", Password = "admin", Role = 0 },
                        new { Id = 2, CreatedOn = new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), Email = "vendor1@gmail.com", IsActive = true, LastModified = new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), Name = "Vendor1", Password = "vendor", Role = 1 },
                        new { Id = 3, CreatedOn = new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), Email = "lob1@gmail.com", IsActive = true, LastModified = new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), Name = "Lob1", Password = "lob", Role = 2 }
                    );
                });

            modelBuilder.Entity("SE.Catalog.Models.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("URL")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("SE.Catalog.Models.Package", b =>
                {
                    b.HasOne("SE.Catalog.Models.DeviceFamily", "DeviceFamily")
                        .WithMany()
                        .HasForeignKey("DeviceFamilyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SE.Catalog.Models.ProductFamily", "ProductFamily")
                        .WithMany()
                        .HasForeignKey("ProductFamilyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SE.Catalog.Models.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SE.Catalog.Models.PackageComment", b =>
                {
                    b.HasOne("SE.Catalog.Models.Package")
                        .WithMany("Comments")
                        .HasForeignKey("PackageId");
                });
#pragma warning restore 612, 618
        }
    }
}
