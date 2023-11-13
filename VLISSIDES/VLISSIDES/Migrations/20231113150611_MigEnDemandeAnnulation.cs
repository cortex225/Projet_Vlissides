using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class MigEnDemandeAnnulation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnDemandeAnnulation",
                table: "Commandes",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnDemandeAnnulation",
                table: "Commandes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "fee82787-6685-4c49-bb31-05800ae1ab33");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c78d0566-26a8-4f18-b00c-d7febe64d175");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "21fcd0a0-9cd6-40a7-acc0-33cdbf1fbf07");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a38e0402-1052-4a5a-aef3-e0c024871a8b", "3e4aad9d-da26-4c1e-9f5f-64d24598e5f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e284d692-1e23-4370-a4f3-7320bf7f05a7", "ceb1934d-c7ad-4c81-920e-e36b29c85650" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "a6eba6b3-2d2b-4d30-9f9a-8c66c418c921", new DateTime(2023, 11, 10, 9, 54, 34, 498, DateTimeKind.Local).AddTicks(4280), "e07e434e-be16-45b3-a67d-516e914b8b1e" });
        }
    }
}
