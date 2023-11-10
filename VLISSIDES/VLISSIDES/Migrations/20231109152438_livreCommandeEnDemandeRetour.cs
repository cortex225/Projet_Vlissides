using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class livreCommandeEnDemandeRetour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnDemandeRetourner",
                table: "LivreCommandes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "82b265e4-c74a-4c15-9951-cbf92eb8b6f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "279ab972-c230-4ff5-84d8-f55efeec2f38");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "eaa8aaa6-7eed-4403-b314-f90996b4b5f8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "ce9d44d0-9a63-4b69-8a07-1516e3a503cd", "vlissides2023@gmail.com", "VLISSIDES2023@GMAIL.COM", "VLISSIDES2023@GMAIL.COM", "d3bd6d47-3646-403b-a79a-a5b3768006d2", "admin1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b1522328-b755-496c-a8b7-290431f366d0", "b20039b9-25a7-4fb0-a26b-15cd387d45b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "4d93c29d-afb9-4bf7-b5a4-76f013cd887f", new DateTime(2023, 11, 9, 10, 24, 37, 397, DateTimeKind.Local).AddTicks(4633), "524159c8-2eca-4304-a9ae-c04dcc785969" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnDemandeRetourner",
                table: "LivreCommandes");

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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "4e02a892-9de9-422d-893a-9073f8179847", "admin@admin.com", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "d25cdff5-2584-4a46-b3a8-e4272c7227b2", "admin@admin.com" });

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
