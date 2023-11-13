using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class reservation_paymentintent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "3580dee9-9110-4e6a-8937-3286faa49518");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4e7e1ef1-11ae-4e62-a4fa-0498c1fae9eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "64a5fced-f377-4d95-9222-ca3fb40ae074");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f68abf35-5d9d-4331-9201-63e5f6140fbd", "3d0279a9-2f32-4685-803d-dc8791e120a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "925afa28-0845-4cc1-95a0-767bf1385388", "ca81c99d-7739-4490-975e-c4a851f5b5bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "45a5bdcb-fc67-48df-a714-aaa498594f56", new DateTime(2023, 11, 13, 8, 32, 38, 393, DateTimeKind.Local).AddTicks(2355), "e86de2e0-fbb7-43c3-81c7-eedfee71f1e9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "Reservations");

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
