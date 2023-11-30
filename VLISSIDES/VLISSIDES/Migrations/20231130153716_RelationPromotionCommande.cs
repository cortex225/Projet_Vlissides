using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class RelationPromotionCommande : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommandeId",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PromotionId",
                table: "Commandes",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_PromotionId",
                table: "Commandes",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Promotions_PromotionId",
                table: "Commandes",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Promotions_PromotionId",
                table: "Commandes");

            migrationBuilder.DropIndex(
                name: "IX_Commandes_PromotionId",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "CommandeId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "Commandes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "d3c226ae-10dd-4f6f-8c20-95140ed60fe6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "429e1a6f-0c08-4fbc-8a54-3c3553b294d7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "6ab9fc4c-cd6c-49a4-acdb-35e27ff35adc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "86c68ce5-cb81-47ce-b804-2ce75c949048", "00058e9b-4bd6-40d7-b594-699bf663de43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fa63a65d-e08d-4da8-89f5-37f692164899", "cad1cab7-7925-490d-b59a-3557cd109fa5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "2f5a7310-f260-4f47-8e9d-60c0bee67c05", new DateTime(2023, 11, 23, 19, 0, 53, 715, DateTimeKind.Local).AddTicks(5211), "2848ea5f-87a0-41b4-9ac3-d24e6ebe3b2d" });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2023, 11, 23, 19, 0, 53, 717, DateTimeKind.Local).AddTicks(8539), new DateTime(2024, 11, 23, 19, 0, 53, 717, DateTimeKind.Local).AddTicks(8575) });
        }
    }
}
