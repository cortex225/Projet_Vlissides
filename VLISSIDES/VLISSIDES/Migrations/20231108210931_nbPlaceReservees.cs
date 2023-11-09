using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class nbPlaceReservees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NbPlacesReservees",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "e81c93e7-e1b1-40c4-9785-f6dbd9f41455");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4c14b20b-80f2-40d2-b9ee-370c588c089c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "89966c8b-c627-4035-8b2f-394a30dc598c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2694b97e-bd04-4005-8e62-4a58ac9f564c", "a72099df-8882-47bd-9c32-f85620cac1f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9a288d4c-3aa1-4faf-b995-8d0ba09e56ec", "897b608d-8b1d-4d23-95e7-bd59c468ba31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "16030e3f-f7a0-4b4b-a361-7e6d834558bd", new DateTime(2023, 11, 8, 16, 9, 31, 363, DateTimeKind.Local).AddTicks(3150), "e176f896-c359-43c3-9373-cca8d962f9ff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NbPlacesReservees",
                table: "Reservations");

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
    }
}
