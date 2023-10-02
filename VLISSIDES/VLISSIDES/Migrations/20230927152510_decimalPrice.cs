using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class decimalPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Prix",
                table: "LivreTypeLivres",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Prix",
                table: "Livres",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "29a31da7-9fd9-482a-a352-1a34f9f8f660");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a0a47bae-65d4-41b4-a4e0-2c7f37ebedb3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "dea02b89-e2ea-4865-9519-aa03351ebc56");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b04622cd-fa73-40ab-807e-a3a72af020cd", "2f92bcc1-7556-402c-9402-86025719668e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e4ec2015-b6fc-4a6e-8324-5467571a59a7", "daf99feb-2887-4160-98c7-4bc90fb30acc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9e680542-d13b-453b-9c5a-d39cbc02f328", "a8dfc137-ee10-4550-8c43-1c2d208788e7" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 9, 27, 11, 25, 10, 375, DateTimeKind.Local).AddTicks(2980));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Prix",
                table: "LivreTypeLivres",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Prix",
                table: "Livres",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "24b126ed-2c28-45a9-973a-3d96af07e30f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "aab353fc-cc87-4569-bafc-4f7624c23315");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ee59798f-83ae-4b2f-8be7-407707681bc4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1440bbff-8661-4cfc-9b51-f9030bbcb018", "93d8f2cf-dc17-4fb3-8d28-29071fbd223f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b124c5ec-7bab-437b-874c-ac6ebe259d91", "46c752bc-e6fc-4f6a-b65f-740a6d889b8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9705df8b-1696-481a-adb0-5f5cccc6fca6", "d15cfe19-94ed-4e2b-8d73-ba2f5056acbf" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 9, 25, 11, 30, 22, 625, DateTimeKind.Local).AddTicks(8445));
        }
    }
}
