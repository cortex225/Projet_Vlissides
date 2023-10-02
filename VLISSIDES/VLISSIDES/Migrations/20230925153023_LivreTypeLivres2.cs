using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class LivreTypeLivres2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Prix",
                table: "LivreTypeLivres",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "24b126ed-2c28-45a9-973a-3d96af07e30f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "aab353fc-cc87-4569-bafc-4f7624c23315");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ee59798f-83ae-4b2f-8be7-407707681bc4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1440bbff-8661-4cfc-9b51-f9030bbcb018", "93d8f2cf-dc17-4fb3-8d28-29071fbd223f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b124c5ec-7bab-437b-874c-ac6ebe259d91", "46c752bc-e6fc-4f6a-b65f-740a6d889b8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9705df8b-1696-481a-adb0-5f5cccc6fca6", "d15cfe19-94ed-4e2b-8d73-ba2f5056acbf" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 9, 25, 11, 30, 22, 625, DateTimeKind.Local).AddTicks(8445));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Prix",
                table: "LivreTypeLivres",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "d659b77b-c1d8-4063-86e5-bbb18a4891e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "eeb4aef4-7114-4313-a1c3-d703ad000d93");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9abf0d25-e64b-452d-a7a5-a36df918cab3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fe9204e6-52ae-4371-b433-ab92c0ec878e", "4fa6358d-9256-4ca5-94fe-95700c2a76d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bf500b87-af28-4705-b2bb-eeaea6fb44c2", "499b76ed-5dd9-477e-b078-ad13bda3eff4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e29cac18-a0d1-485d-b172-eb3742ca2ea9", "d98706f8-1198-456a-9906-0f53baf43d1e" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 9, 25, 11, 21, 43, 738, DateTimeKind.Local).AddTicks(8683));
        }
    }
}
