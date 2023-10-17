using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class CoverProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "c3b33c06-0ff4-4f10-9242-fd3bf729e989");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6fa32b3f-09a9-4f10-a09d-de40d7587126");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7d99ad11-389d-4e72-a168-0b7617296273");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "17912874-4b30-4083-a8d4-9e231bb1040b", "3ca11f2f-ffc0-472e-8f64-1e6f473fb97d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9724a9a7-76e5-4635-b27b-bb5dadc16011", "d2a96d67-19a8-4ba7-99d1-a218dc6ebf94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "08789319-b7d5-4edb-9f5c-ee23c87c2381", new DateTime(2023, 10, 16, 13, 2, 22, 974, DateTimeKind.Local).AddTicks(1260), "5909de22-aa9e-4950-bf73-e8fe80da1fcb" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 1",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 10",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 11",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 12",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 13",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 14",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 15",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 16",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 17",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 18",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 19",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 2",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 20",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 21",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 22",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 23",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 24",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 25",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 26",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 27",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 28",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 29",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 3",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 30",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 31",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 32",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 33",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 34",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 35",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 36",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 37",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 38",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 39",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 4",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 40",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 42",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 43",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 44",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 45",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 46",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 48",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 49",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 5",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 50",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 51",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 52",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5320));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 6",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 7",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 8",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 9",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5170));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "3c1ca803-5cef-4808-ba2e-08b8efc9c2ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8752349b-72dd-4ac0-998c-c3f62a91cff0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8ff18391-6526-4585-b426-197610a95c81");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff913b5c-9cb7-45eb-8a51-f23867da8ddc", "ba01cac6-9991-4933-b31e-ea674c382741" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d81bebff-d7e8-4797-9e2c-81e2fd80a6f5", "2b2cd452-5680-417f-8368-8be5e5bae944" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "d610191a-172e-46f7-9c6a-82bf2e68bb5b", new DateTime(2023, 10, 15, 14, 3, 51, 764, DateTimeKind.Local).AddTicks(4968), "b393d520-5a3a-442e-9d5b-c24f473af263" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 1",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 10",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2774));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 11",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 12",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 13",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 14",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2792));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 15",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 16",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 17",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 18",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 19",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 2",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2737));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 20",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2823));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 21",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2828));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 22",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2833));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 23",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 24",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2842));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 25",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 26",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 27",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 28",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2862));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 29",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2866));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 3",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2744));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 30",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2871));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 31",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 32",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2881));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 33",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 34",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2895));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 35",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2902));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 36",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 37",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 38",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2918));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 39",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2923));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 4",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2748));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 40",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2928));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 42",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2934));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 43",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2939));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 44",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2945));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 45",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2950));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 46",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2956));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 48",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2961));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 49",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2967));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 5",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2752));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 50",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2972));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 51",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 52",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2983));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 6",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2757));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 7",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 8",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 9",
                column: "DateAjout",
                value: new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2769));
        }
    }
}
