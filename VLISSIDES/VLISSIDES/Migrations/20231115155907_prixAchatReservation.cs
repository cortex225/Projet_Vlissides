using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class prixAchatReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "prixAchat",
                table: "Reservations",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "b7f87a8e-6916-44d0-a937-e7c9a76a0278");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c22ed457-e496-4f5a-b6f5-a760072d840e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "85473b71-b45c-42b4-af8d-bb2975eaad02");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fa11982a-635f-4812-aba7-3749b7fe833b", "e30d4f1d-e4fd-45f5-a6b4-73874b45842b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e1ecf811-1c35-4fd5-9739-cbd6eed79eb1", "0d7b29d3-59a0-42bd-931c-f095cf50178f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "250367df-b775-4efb-9539-29e66229212f", new DateTime(2023, 11, 15, 10, 59, 7, 72, DateTimeKind.Local).AddTicks(7231), "39a45146-2e10-45b9-85a4-904376fedcee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prixAchat",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "61e01548-ac5f-4b09-bbf2-6067a5c2940a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8b223b66-49ba-4a28-b99a-c051323d458f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "68b722b8-e971-4d00-9767-839ccaa13d68");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1b3bcb62-a541-4539-9b94-21c45df7bc5a", "f3b36801-ad43-48a1-bea0-e6faad5da25b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ab939232-ef0c-4009-bcaa-147a78db6ba5", "93685a48-362d-4ec0-8eaa-c830749ce64e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "10505aa8-6095-414a-b936-f9799e4d0a77", new DateTime(2023, 11, 15, 10, 15, 6, 689, DateTimeKind.Local).AddTicks(3827), "87893acb-b428-4b06-a51d-d57986edd608" });
        }
    }
}
