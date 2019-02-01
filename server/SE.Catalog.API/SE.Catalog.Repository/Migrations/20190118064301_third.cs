using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SE.Catalog.Repository.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "IsActive", "LastModified", "Name", "Password", "Role" },
                values: new object[] { 1, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Local), "admin1@gmail.com", true, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Local), "Admin1", "admin", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "IsActive", "LastModified", "Name", "Password", "Role" },
                values: new object[] { 2, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Local), "vendor1@gmail.com", true, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Local), "Vendor1", "vendor", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "IsActive", "LastModified", "Name", "Password", "Role" },
                values: new object[] { 3, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Local), "lob1@gmail.com", true, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Local), "Lob1", "lob", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
