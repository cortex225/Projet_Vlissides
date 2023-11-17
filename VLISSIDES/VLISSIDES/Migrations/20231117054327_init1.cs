using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrixAprèsPromotion",
                table: "LivrePanier",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixOriginal",
                table: "LivrePanier",
                type: "decimal(18,2)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixAprèsPromotion",
                table: "LivrePanier");

            migrationBuilder.DropColumn(
                name: "PrixOriginal",
                table: "LivrePanier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "1bd83253-6fab-45b7-9feb-50d9ad8a2e98");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "34ac6120-ff3f-4369-a999-7661cd9dd564");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ca63b6f4-7936-4120-91e6-12121af29231");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bc0ce511-cc30-4821-88bf-cd44a740a749", "fb5bc974-3082-4c02-9f6c-4382752e84cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f0324bf2-c39f-498b-859b-689881d00131", "4866d605-7f24-4ddf-9891-166e4ceab091" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "2328f4c0-86ca-4b75-8e2c-a0f3b3c41bae", new DateTime(2023, 11, 16, 0, 4, 23, 942, DateTimeKind.Local).AddTicks(630), "7287e6fb-13c7-42d8-9499-094cef42009c" });
        }
    }
}
