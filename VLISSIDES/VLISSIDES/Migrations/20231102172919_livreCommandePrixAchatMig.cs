using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class livreCommandePrixAchatMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Commentaire",
                table: "Evaluations");

            migrationBuilder.AddColumn<double>(
                name: "PrixAchat",
                table: "LivreCommandes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "cf9f33c6-249e-46c8-96ec-5a33a63e1425");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7afa5a6c-9b42-4c08-93b5-3f431d272f6b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e1cde01a-d9e2-427b-9ed3-f3ad22793849");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4e02a892-9de9-422d-893a-9073f8179847", "d25cdff5-2584-4a46-b3a8-e4272c7227b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fd37f12e-a7b1-440b-99ad-8d4cb8bacc52", "abce17f6-b016-4363-991c-d54d1f0e7211" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "cce32a23-1677-4769-b16a-4236f4716d6f", new DateTime(2023, 11, 2, 13, 29, 18, 581, DateTimeKind.Local).AddTicks(2094), "d2909b13-0006-4560-abb0-fa9c5abb7c13" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixAchat",
                table: "LivreCommandes");

            migrationBuilder.AddColumn<string>(
                name: "Commentaire",
                table: "Evaluations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "8790a61e-b7b2-477f-b285-60f04659c010");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1f7a99e3-d183-44ca-8068-d41ef2708f2d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "04e9b305-3fca-400f-ae3b-3bf146fdefd6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6b75ec80-e88f-4e92-b6f1-11c10fda91b7", "6fa5d831-bf5a-4268-8ee8-f66fe7808359" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4cfb72b4-3f1b-4a34-bdef-845b7c0f8eb4", "7bc15b22-81b6-4557-82b7-89080dc007f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "23889b21-b548-4f52-98e7-346ece87235f", new DateTime(2023, 10, 22, 15, 2, 35, 383, DateTimeKind.Local).AddTicks(8970), "019a9ff0-2d5e-4be0-bd1d-f49a3e4ce381" });
        }
    }
}
