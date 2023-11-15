using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class enDemandeAnnuler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnDemandeAnnuler",
                table: "Reservations",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "61e01548-ac5f-4b09-bbf2-6067a5c2940a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8b223b66-49ba-4a28-b99a-c051323d458f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "68b722b8-e971-4d00-9767-839ccaa13d68");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1b3bcb62-a541-4539-9b94-21c45df7bc5a", "f3b36801-ad43-48a1-bea0-e6faad5da25b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ab939232-ef0c-4009-bcaa-147a78db6ba5", "93685a48-362d-4ec0-8eaa-c830749ce64e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "10505aa8-6095-414a-b936-f9799e4d0a77", new DateTime(2023, 11, 15, 10, 15, 6, 689, DateTimeKind.Local).AddTicks(3827), "87893acb-b428-4b06-a51d-d57986edd608" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnDemandeAnnuler",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "755b4b61-a26c-4010-a427-eddd0fb37515");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0fe42b1f-094e-4d52-9bfd-0aeb90acc490");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "6eebdfcc-dafb-4b08-a855-71230b771277");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c35f299e-d2c0-467f-930a-20962ec3489e", "267e7fae-fc08-4033-af97-9293d8854f9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c8a9b3a6-061d-4876-804c-4cf866736980", "5e01e12e-8361-42b6-b47c-6a93982e8595" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "8eedae22-cada-49f4-ac07-dafa7476ee48", new DateTime(2023, 11, 13, 10, 30, 28, 254, DateTimeKind.Local).AddTicks(3199), "194f047d-b014-43fe-b024-40dc3836328c" });
        }
    }
}
