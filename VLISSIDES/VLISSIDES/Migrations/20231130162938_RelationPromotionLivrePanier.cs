using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class RelationPromotionLivrePanier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LivrePanierId",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PromotionId",
                table: "LivrePanier",
                type: "nvarchar(450)",
                nullable: true);

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
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2023, 11, 30, 11, 29, 38, 501, DateTimeKind.Local).AddTicks(2410), new DateTime(2024, 11, 30, 11, 29, 38, 501, DateTimeKind.Local).AddTicks(2470) });

            migrationBuilder.CreateIndex(
                name: "IX_LivrePanier_PromotionId",
                table: "LivrePanier",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_LivrePanier_Promotions_PromotionId",
                table: "LivrePanier",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivrePanier_Promotions_PromotionId",
                table: "LivrePanier");

            migrationBuilder.DropIndex(
                name: "IX_LivrePanier_PromotionId",
                table: "LivrePanier");

            migrationBuilder.DropColumn(
                name: "LivrePanierId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "LivrePanier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "2e419bf4-ffec-437a-ade9-264af6bfed41");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a803bb35-136a-4e14-ad03-7380e4f5da43");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9ff35e18-45f7-47f3-b659-59c852b6e32c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8c2e7aad-62a9-4df3-8112-6ad9b7c42cde", "f89df563-f120-4e79-a8e5-50605e155df6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "07095933-63e5-49e3-a3e8-6c533bb5f6f0", "c7cc055a-0dca-44ac-ab99-5cd8cda1853d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "bfcde329-01aa-46e5-b115-6d10ff6abc20", new DateTime(2023, 11, 30, 10, 37, 15, 842, DateTimeKind.Local).AddTicks(7810), "17c86f52-26cf-4e71-8092-57398ce13a5b" });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2023, 11, 30, 10, 37, 15, 845, DateTimeKind.Local).AddTicks(5930), new DateTime(2024, 11, 30, 10, 37, 15, 845, DateTimeKind.Local).AddTicks(5950) });
        }
    }
}
