using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class MigQuantiteARetourner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantiteARetourner",
                table: "LivreCommandes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "eae72abc-d9ae-476b-9054-db965596b1b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "565d935d-213f-41ac-90d1-354a9cd8942d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "80f1defb-27d8-442b-ac2d-4766550d133f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "50bf240d-9f23-4ef4-9f2d-5d8121a163b1", "6bb8d952-84de-4bf5-95c1-258504c8938f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9b162e86-89e3-4674-ae3b-23ee8793c191", "ff97d5ff-9b7b-4cfb-bf8c-ef72ea84690d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "94f67ec2-0d0d-402b-9bd7-258f170cb837", new DateTime(2023, 11, 15, 14, 51, 40, 599, DateTimeKind.Local).AddTicks(6027), "9607f67d-729c-4c75-b851-753a370b13e9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantiteARetourner",
                table: "LivreCommandes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "d163f7bd-d143-4e90-873a-ef2a424def80");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "53b3d773-a34c-42f3-941a-0a55172ebe20");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "117e913f-128c-4ac5-a3a0-427265e781db");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a67fa654-5a04-4b33-a247-eaa24d69a5e1", "4e09a1de-6696-4729-a3fc-d7cabbb61d26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7a0fe280-3c3a-4052-b738-fcc3f85aa0ac", "d3d32988-4650-445d-9f32-2d9872d82240" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "bf544708-6b2c-4d07-b734-1b741c98f3df", new DateTime(2023, 11, 13, 10, 6, 10, 823, DateTimeKind.Local).AddTicks(5642), "d07f9ea0-4bb4-4c31-ad7a-51001cc39fdd" });
        }
    }
}
