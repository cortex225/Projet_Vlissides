using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class TypeLivreDataChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "82593ae3-36e9-4585-81fc-8a04bdbafa31");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0969f299-b942-4b68-a9a4-1600b3b5f451");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "eb640049-f402-4118-b8b7-c7ae4fd40d0e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ecfb1aba-6b32-45e3-869a-91c779f5c867", "8a33d9cf-eee3-4d85-9d67-3d54c11ca325" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7afcfce1-2b11-4e26-ac75-2f4ff0dc7c0a", "e5fce35a-bdb3-4213-8440-514349bb9620" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "66d7da6d-e585-4cbb-9257-fe98083b5107", new DateTime(2023, 10, 18, 10, 0, 0, 960, DateTimeKind.Local).AddTicks(784), "a9652cb4-671a-4625-b959-d6c9bde8cdbb" });

            migrationBuilder.UpdateData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "1",
                column: "Nom",
                value: "Papier");

            migrationBuilder.UpdateData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "2",
                column: "Nom",
                value: "Numérique");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "25d62c45-6d87-41fa-b9a1-c1a6b861a6ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "598b5aa3-45f6-4bd3-a3b4-2df50a24dbbc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2245a312-f4ad-4957-b3e6-8cd090178d36");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "114fc03d-0e58-428a-86a1-15be3e23a2f4", "9ea9c72b-22ea-462d-8935-529e57f1e42a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f453ecc6-4d41-44fd-8228-62836a2d6185", "20780df8-25d0-4d2d-8a91-c0d5c322b4f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "851a8572-502c-466e-ac02-646c9c75eaaa", new DateTime(2023, 10, 18, 6, 34, 52, 435, DateTimeKind.Local).AddTicks(2320), "9c1536b7-fcee-4cc4-9148-02bc9a713680" });

            migrationBuilder.UpdateData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "1",
                column: "Nom",
                value: "Numérique");

            migrationBuilder.UpdateData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "2",
                column: "Nom",
                value: "Papier");
        }
    }
}
