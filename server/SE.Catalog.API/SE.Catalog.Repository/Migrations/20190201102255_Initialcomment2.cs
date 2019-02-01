using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SE.Catalog.Repository.Migrations
{
    public partial class Initialcomment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_DeviceFamilies_DeviceFamilyId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_ProductFamilies_ProductFamilyId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Vendors_VendorId",
                table: "Packages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 1, 15, 52, 54, 886, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 1, 15, 47, 24, 945, DateTimeKind.Local));

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                table: "Packages",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductFamilyId",
                table: "Packages",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeviceFamilyId",
                table: "Packages",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DeviceFamilies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DeviceFamilies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_DeviceFamilies_DeviceFamilyId",
                table: "Packages",
                column: "DeviceFamilyId",
                principalTable: "DeviceFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_ProductFamilies_ProductFamilyId",
                table: "Packages",
                column: "ProductFamilyId",
                principalTable: "ProductFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Vendors_VendorId",
                table: "Packages",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_DeviceFamilies_DeviceFamilyId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_ProductFamilies_ProductFamilyId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Vendors_VendorId",
                table: "Packages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 1, 15, 47, 24, 945, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 1, 15, 52, 54, 886, DateTimeKind.Local));

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                table: "Packages",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProductFamilyId",
                table: "Packages",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DeviceFamilyId",
                table: "Packages",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DeviceFamilies",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DeviceFamilies",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_DeviceFamilies_DeviceFamilyId",
                table: "Packages",
                column: "DeviceFamilyId",
                principalTable: "DeviceFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_ProductFamilies_ProductFamilyId",
                table: "Packages",
                column: "ProductFamilyId",
                principalTable: "ProductFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Vendors_VendorId",
                table: "Packages",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
