using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class FixBirthday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "4e3defef-fd63-46d9-adbc-cac978fceaf8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "06d824f0-0a23-4a77-bc02-cffb88753c20");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "33a0afee-5087-4a53-a4c9-db7b7ee16030");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3974ae47-29eb-4c59-9bbe-b299510d15f7", "67608d1f-1540-4c7a-a504-0539ccc87d38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3a6b48e2-4594-468c-aeb2-5a3305386b56", "1f67e694-322a-4474-bcf0-32cfc5e5a478" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "1a8abc18-9339-4068-83ad-a9b813e8fca1", new DateTime(2023, 11, 30, 15, 31, 56, 146, DateTimeKind.Local).AddTicks(5310), "cfa88946-1d29-45cd-82ab-39521a5b0d4d" });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "DateDebut", "DateFin", "TypePromotion" },
                values: new object[] { new DateTime(2023, 11, 30, 15, 31, 56, 147, DateTimeKind.Local).AddTicks(7020), new DateTime(2024, 11, 30, 15, 31, 56, 147, DateTimeKind.Local).AddTicks(7030), "pourcentage" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "f81533a3-b69c-49d3-b346-9320a1c6e7d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "801d5334-f115-43c5-bbc4-8832afa1e69d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0ef975aa-dbb4-45d1-a4f6-f40633fd4ccf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "803a2707-3465-40e2-9935-a5fc7d8d1ddb", "04e93855-1d0f-4eb9-a094-0975a7eaf28f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aa9c2c47-646b-4118-9ad7-d2b2ba3b5010", "6e1cb422-970b-4d25-8157-c2ea91c36384" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "99126b45-caac-4253-bed5-633fb9d18468", new DateTime(2023, 11, 30, 11, 29, 38, 494, DateTimeKind.Local).AddTicks(9530), "2a2bf02c-72f5-4777-8feb-9bc63d91f84a" });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "DateDebut", "DateFin", "TypePromotion" },
                values: new object[] { new DateTime(2023, 11, 30, 11, 29, 38, 501, DateTimeKind.Local).AddTicks(2410), new DateTime(2024, 11, 30, 11, 29, 38, 501, DateTimeKind.Local).AddTicks(2470), "Pourcentage" });
        }
    }
}
