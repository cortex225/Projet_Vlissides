using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class MigrPromotions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodePromo",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "37b2b2a8-ac3b-4253-a713-5b4e6da85b34");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0f4e8eb7-d6d7-487a-b948-efd52199023d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3582259b-5e9c-4cbc-8b00-84a943dba516");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4b45efeb-e21e-4bd4-9bf4-b57bd39ed0e2", "82e9b8d2-c1b1-4860-9739-06768eb51e85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "69403e05-c522-432a-bb9f-7bca369c297d", "f1b59554-21d2-421f-b3b2-7fe196148dfe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "71c6cb8b-dac6-422c-8b6d-73bfa87c6de4", new DateTime(2023, 11, 9, 9, 36, 55, 752, DateTimeKind.Local).AddTicks(7041), "df738dec-0970-4b8f-9bf0-db480dc0c734" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodePromo",
                table: "Promotions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "95e9b754-e6fd-4ae0-bb06-df8e24bde08a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d3b7514b-dfe5-4835-b361-7046473a6ce0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "1f30ed5e-d3f4-4a08-ac6e-f81946c756ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0f830a77-14ab-4ddb-8c88-b23d797d2adf", "b4b73a2c-61ea-4440-bb69-08e869da2650" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6a28c8a4-f0bf-4cc5-805e-65fd2c148781", "5df1a8b2-92ce-484e-b6fc-8e6484cd3ada" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "40bcb1ac-cc82-427c-a312-9d9c15956331", new DateTime(2023, 11, 9, 8, 22, 17, 359, DateTimeKind.Local).AddTicks(898), "479080a6-bba6-40af-a77c-ed340a445fcb" });
        }
    }
}
