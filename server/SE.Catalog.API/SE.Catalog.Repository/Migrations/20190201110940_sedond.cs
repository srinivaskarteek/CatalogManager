using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SE.Catalog.Repository.Migrations
{
    public partial class sedond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 1, 16, 39, 39, 790, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 1, 15, 52, 54, 886, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 1, 15, 52, 54, 886, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 1, 16, 39, 39, 790, DateTimeKind.Local));
        }
    }
}
