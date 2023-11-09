using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class Ajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NbPlacesReservees",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "NbPlacesReservees",
                table: "Evenements",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "e1ba557f-7410-45ec-ac29-e595bdf9d2f8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "968c646f-c021-44a9-a6b1-5168b25f5307");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5b1fa0c4-6bbb-436b-b9cd-306357e792d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fb9c5c2e-a962-47e7-ba0e-7b3e8d84a0d2", "2de45550-1097-4392-a560-705312a6da4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4066192d-1031-4f46-94fd-d7953e3b5f90", "28c99f91-749b-4afb-b55c-02ad1a545e0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "cf8a18e0-f483-41cc-b66d-0424570cdd51", new DateTime(2023, 11, 8, 16, 22, 5, 505, DateTimeKind.Local).AddTicks(1160), "12b89601-536b-489d-b98e-e04a4cbb8c46" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NbPlacesReservees",
                table: "Evenements");

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
    }
}
