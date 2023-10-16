using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrixParArticle",
                table: "LivreCommandes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "f815d7da-f1ed-4096-923e-603e6bc7bceb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "baf09351-7db7-49c8-8d33-427acd9bb5c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e4d13af3-ae79-4dcb-b66f-5e12dcf6cc62");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5dfab986-5fd5-4bf9-af20-73a22e336c31", "2e385199-2cfd-4bc1-b177-23fed4b30d0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fd854ee9-1cca-4b34-b64e-9bd72034b18d", "048dbd8e-842b-4b7b-afe0-8157d75b3f3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "676ed2da-423d-4ff0-9bb8-e9188fe2ad3b", new DateTime(2023, 10, 15, 15, 39, 37, 381, DateTimeKind.Local).AddTicks(2190), "6ddb5fb5-0cdb-499f-b0b4-2139f710122c" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 1",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 10",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 11",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 12",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 13",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 14",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 15",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 16",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 17",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 18",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 19",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 2",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 20",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 21",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 22",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 23",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 24",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 25",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 26",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 27",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 28",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 29",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 3",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 30",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 31",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 32",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 33",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 34",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 35",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 36",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 37",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 38",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 39",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 4",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 40",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 42",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 43",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 44",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 45",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 46",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 48",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 49",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 5",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 50",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 51",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 52",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 6",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 7",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 8",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 9",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 15, 39, 37, 379, DateTimeKind.Local).AddTicks(8370));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixParArticle",
                table: "LivreCommandes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "9263ba4b-0851-4c19-bf07-fb388fd9fe1a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9d48feb2-cf0d-48b4-9b6b-e9365ad7b3fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7629c9a4-c972-47d0-9e0e-b8a5f96dcdd4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "38fadee9-4b9e-40fb-b5b8-2f1f4e173bc1", "ec10ff76-79e9-4944-8af7-347aa3cb5532" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "79782f69-4bed-4070-94f8-bd99b9f636a5", "624f5001-6abf-4ff2-bb7d-f765ce0f4455" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "84f118a7-9712-4cb7-982d-688c04f2311e", new DateTime(2023, 10, 15, 14, 54, 21, 749, DateTimeKind.Local).AddTicks(8500), "de0a590a-c51d-4937-b858-0b028cca15bb" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 1",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 10",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 11",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5590));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 12",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 13",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 14",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 15",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 16",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 17",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 18",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 19",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 2",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 20",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 21",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 22",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 23",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 24",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 25",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 26",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 27",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 28",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 29",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 3",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 30",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5690));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 31",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 32",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 33",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 34",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 35",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 36",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 37",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 38",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 39",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 4",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5540));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 40",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 42",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 43",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 44",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 45",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 46",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 48",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 49",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 5",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 50",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 51",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 52",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5820));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 6",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 7",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 8",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 9",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 54, 21, 733, DateTimeKind.Local).AddTicks(5560));
        }
    }
}
