using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class panierStatut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "StatutCommande",
                columns: new[] { "Id", "Nom" },
                values: new object[] { "0", "Panier" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatutCommande",
                keyColumn: "Id",
                keyValue: "0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "e6d1d7a4-a62a-46b4-8a76-290332af67a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "314dd6c2-7d1f-41f6-823c-7767a9803a90");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ffe71790-fb18-4eac-8bb8-b88c71a983b2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "839dbafe-c086-43e1-b17f-2c7d92643966", "9e18155f-05af-42b4-ac1f-12be129df7d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "51bd390a-dc46-404e-a943-ebbb82d808d0", "40352790-cd6c-4dcc-92b2-8d7abbed6d3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "ef442585-e4ce-46d3-aacb-0717083bdc6e", new DateTime(2023, 10, 15, 14, 49, 36, 756, DateTimeKind.Local).AddTicks(3190), "29b8e7ce-7712-431c-8239-99e8af08528e" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 1",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 10",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 11",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 12",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 13",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 14",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 15",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 16",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 17",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 18",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 19",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 2",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 20",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 21",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 22",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 23",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4800));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 24",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4800));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 25",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4800));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 26",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 27",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 28",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 29",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 3",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 30",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 31",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 32",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 33",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 34",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 35",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 36",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 37",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 38",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 39",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 4",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 40",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 42",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 43",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 44",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 45",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 46",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 48",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 49",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 5",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 50",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 51",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 52",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 6",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 7",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 8",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 9",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 49, 36, 754, DateTimeKind.Local).AddTicks(4760));
        }
    }
}
