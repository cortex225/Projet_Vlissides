using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class StatutCommande : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_StatutCommande_StatutCommandeId",
                table: "Commandes");

            migrationBuilder.AlterColumn<string>(
                name: "StatutCommandeId",
                table: "Commandes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "ca5d83cd-9f32-4ffc-b0ae-21a596b4cfc9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "06a0a557-93f3-4153-8346-e41cd0f83c99");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "df20ba55-9f30-473a-931d-b6487a1e13b7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ad16c502-af0f-4b62-925a-160ea7718c8b", "916d3328-1607-4522-be70-60b5f3b72a30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "66d78a05-624a-40bc-ba8a-7bab26fdbae8", "df4b26cb-a285-491b-a391-5aa6d0047ae0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1373f53f-108e-40bb-9ef9-2147c0dfb39f", "ef46a94a-ab99-4c56-a19c-57d85c292221" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 10, 15, 14, 36, 41, 952, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_StatutCommande_StatutCommandeId",
                table: "Commandes",
                column: "StatutCommandeId",
                principalTable: "StatutCommande",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_StatutCommande_StatutCommandeId",
                table: "Commandes");

            migrationBuilder.AlterColumn<string>(
                name: "StatutCommandeId",
                table: "Commandes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "343d99a4-cf9f-4103-b106-949f41cf11c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "74edc536-1bd5-4c63-b861-34724c43a14b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8af8c3f1-1c42-448e-995f-87016f191907");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1be39d67-0412-44c4-b06f-a444ca33a717", "3a55c902-73ee-41a6-9c00-3f9cf7c19ba0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "028b12fd-e535-4264-94cd-8240cd2ce6dc", "fac198fa-9016-4b7d-98eb-3dcd8d80bec2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6f922dbe-57c3-4732-ae85-7152483aab53", "1bb18fd2-764b-49fc-a741-f743fc994252" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 10, 4, 14, 45, 28, 183, DateTimeKind.Local).AddTicks(3459));

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_StatutCommande_StatutCommandeId",
                table: "Commandes",
                column: "StatutCommandeId",
                principalTable: "StatutCommande",
                principalColumn: "Id");
        }
    }
}
