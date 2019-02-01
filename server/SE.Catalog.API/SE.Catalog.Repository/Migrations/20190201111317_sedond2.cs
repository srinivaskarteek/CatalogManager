using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SE.Catalog.Repository.Migrations
{
    public partial class sedond2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_DeviceFamilies_DeviceFamilyId1",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_DeviceFamilyId1",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "DeviceFamilyId1",
                table: "Packages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 1, 16, 43, 17, 312, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 1, 16, 39, 39, 790, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 1, 16, 39, 39, 790, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 1, 16, 43, 17, 312, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "DeviceFamilyId1",
                table: "Packages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_DeviceFamilyId1",
                table: "Packages",
                column: "DeviceFamilyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_DeviceFamilies_DeviceFamilyId1",
                table: "Packages",
                column: "DeviceFamilyId1",
                principalTable: "DeviceFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
