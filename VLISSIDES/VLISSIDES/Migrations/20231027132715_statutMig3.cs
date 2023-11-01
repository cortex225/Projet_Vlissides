using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class statutMig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_StatutCommande_StatutCommandeId",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "StatutId",
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
                value: "47c3c146-1a2c-48b0-8ec7-b39722a48236");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e5460e13-c637-445c-83e2-5e2a0c2a616b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "089498b4-605b-4f5e-9a6c-4ae2286a1fe1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "82b3c70e-5c8a-4f2b-9620-604239dcf001", "e7afcbd7-d8cb-41b4-82f0-46ea45d09747" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "818ec578-1015-46d5-8aa3-7aaa4e50cbfc", "e77ea4cb-2add-4619-9129-05b2a327b275" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "ee1a3fb9-bd4e-4b7e-938f-a08bc453f311", new DateTime(2023, 10, 27, 9, 27, 14, 348, DateTimeKind.Local).AddTicks(9205), "06918daa-42c5-466c-8c26-94c71cdf614c" });

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

            migrationBuilder.AddColumn<string>(
                name: "StatutId",
                table: "Commandes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "89d85ed6-3c2a-4fe5-8abf-0bc68312ae66");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0041dad0-8e0c-43ff-b2dc-fb6138fc620b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "179633e9-7990-4053-87bb-ef373a00bec6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "00a1a65a-e9dd-4065-bbb0-7bf7dbdaa281", "a6296e15-ff00-4fd2-8cc3-145f0dd8443f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2a4c327f-4b52-4d56-aae7-6855cd490b6c", "897b72e7-e25d-4504-81ea-960d7fe04c49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "e503fc1b-43eb-4140-8191-385c20df6f1c", new DateTime(2023, 10, 27, 9, 22, 41, 320, DateTimeKind.Local).AddTicks(7775), "4fb62727-33ac-4bfa-9bec-882c2fdad2b1" });

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_StatutCommande_StatutCommandeId",
                table: "Commandes",
                column: "StatutCommandeId",
                principalTable: "StatutCommande",
                principalColumn: "Id");
        }
    }
}
