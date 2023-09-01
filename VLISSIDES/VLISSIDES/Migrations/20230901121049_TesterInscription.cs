using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class TesterInscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "688e0be9-161f-47b3-b6ab-515c1bd72773");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2bb0aa9a-7eb9-481d-8501-f21f050572f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0b888447-f4d1-48b9-9063-4598f36c2e24");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ce1e4bd0-b0fa-476c-8b1f-f059fa387f1e", "76a79ce7-22e0-4018-ac56-5d93d9543755" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c7564d60-efb3-4f2e-b32a-b914cffb52d1", "35152dd0-3bef-487c-b349-746075d94a11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6e71678e-6b7e-4af9-95de-711fb770cb93", "add15497-45a2-4014-9b51-9416949c8bdf" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 9, 1, 8, 10, 47, 754, DateTimeKind.Local).AddTicks(5296));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "5a76dfec-25b5-4a4a-84eb-2a3246c5a673");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c6456878-d47d-4535-8572-5a0890ef2bd3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "39c92b12-fae2-457a-8edb-c76ef0fd30df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d525c988-3917-4c92-9443-b290807eba5e", "8fd3d71e-cab2-4683-9a67-ed8eadef5796" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ffc44b67-755d-44e0-a1a3-8ad9a96702ae", "c1fbc4bb-a7d7-4bb1-8ace-a9a4c6f6d369" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "14a6857b-2e2e-44d4-8604-053a1759d08e", "ab27bb01-ab31-4092-beb5-0061045e61f5" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 8, 31, 14, 32, 8, 53, DateTimeKind.Local).AddTicks(4300));
        }
    }
}
