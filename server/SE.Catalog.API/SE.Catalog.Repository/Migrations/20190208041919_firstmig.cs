using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SE.Catalog.Repository.Migrations
{
    public partial class firstmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceFamilies",
                columns: table => new
                {
                    LastModified = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductFamilies",
                columns: table => new
                {
                    LastModified = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    LastModified = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 2, 8, 9, 49, 18, 961, DateTimeKind.Local)),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    LastModified = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    URL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    LastModified = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    HWVersion = table.Column<string>(nullable: false),
                    DeviceFamilyId = table.Column<int>(nullable: false),
                    ProductFamilyId = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    ProfileType = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    UploadDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<string>(nullable: false),
                    SWVersion = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    BlobURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_DeviceFamilies_DeviceFamilyId",
                        column: x => x.DeviceFamilyId,
                        principalTable: "DeviceFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_ProductFamilies_ProductFamilyId",
                        column: x => x.ProductFamilyId,
                        principalTable: "ProductFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: false),
                    PackageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageComments_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "IsActive", "LastModified", "Name", "Password", "Role" },
                values: new object[] { 1, new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), "admin1@gmail.com", true, new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), "Admin1", "admin", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "IsActive", "LastModified", "Name", "Password", "Role" },
                values: new object[] { 2, new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), "vendor1@gmail.com", true, new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), "Vendor1", "vendor", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "IsActive", "LastModified", "Name", "Password", "Role" },
                values: new object[] { 3, new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), "lob1@gmail.com", true, new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), "Lob1", "lob", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_PackageComments_PackageId",
                table: "PackageComments",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_DeviceFamilyId",
                table: "Packages",
                column: "DeviceFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ProductFamilyId",
                table: "Packages",
                column: "ProductFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_VendorId",
                table: "Packages",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageComments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "DeviceFamilies");

            migrationBuilder.DropTable(
                name: "ProductFamilies");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
