using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrixAprèsPromotion",
                table: "LivrePanier",
                newName: "PrixApresPromotion");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "fd74c9b5-a01f-4e8e-a989-f9a5bab61216");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1b23953d-18f8-4a26-9c94-8b2ee91cbc08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "1d7036b5-91c1-46a6-be09-750c9ccfcf0b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d2d3c918-a265-449d-8e1a-c4b5ddfd5c67", "d15e5d37-d494-48f0-a3bf-381293342fe8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5af580c0-f54e-41e4-a2c3-a2ffadd48530", "33ad2cd3-2377-4a0e-a40f-40133a58f6b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "e1043f8e-1cfe-48f4-b547-38643e67a6c4", new DateTime(2023, 11, 17, 1, 1, 55, 385, DateTimeKind.Local).AddTicks(8980), "d9525e43-93d5-4d6a-8b0a-f027da4722b5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrixApresPromotion",
                table: "LivrePanier",
                newName: "PrixAprèsPromotion");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "d874b010-6787-4d1a-adeb-58a90c041094");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "be2e0621-8ed1-4fd0-9f96-be900dab980b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5547e746-ba3b-4f66-858f-e7bb1d40af81");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b65184f3-fce0-4908-8a9d-bc82798c5660", "214885c9-160b-418f-96d8-8aaf14b5cd16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3e0a063e-4c6e-4cff-bf71-b2c1c4e14c06", "2a679ff9-8f01-4bd9-a0a0-3d56f267228a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "1e6291d3-51a3-4713-bd84-6a3a59a8ca21", new DateTime(2023, 11, 17, 0, 43, 27, 441, DateTimeKind.Local).AddTicks(6900), "3b9cd218-1d46-4ecc-97a8-94d9f1672146" });
        }
    }
}
