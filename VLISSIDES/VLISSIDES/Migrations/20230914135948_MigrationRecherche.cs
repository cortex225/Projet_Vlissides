using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class MigrationRecherche : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "32e874c7-3550-4a64-ad5d-0991e23f0049");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "62027613-3add-4a82-8816-c26b91d0aa1c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f96e9178-4f8e-4121-ba10-58127e4c7aa4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a3440082-404b-4860-9ee9-8299b71a13ec", "3445367d-e2f5-4776-8fb8-5c87f6a3623c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c6959c5a-4ca1-4db0-b93e-ddf66cba4d14", "f13f5058-8d0c-47d4-86a2-9dcb4978744f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "c67845d3-8ee3-4674-a131-b8f8b62a0496");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "52c06941-650c-4944-8605-f2a4a375f81f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ba9b522e-e73a-4d07-bb1b-693d1f4aaacd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "14a49074-dd8d-4aab-991f-4892481b8287", "fb529e7a-e6cf-41ca-8cca-687109816421" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "90d38bb4-d6f9-4ae8-83aa-ae6b71894fc6", "ff9a9db9-218b-44c3-936a-494c93c817ea" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdresseLivraisonId", "AdressePrincipaleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, null, "", "68efeb05-6978-437e-bb38-130f34ae6823", "membre@membre.com", true, false, null, "MEMBRE", "MEMBRE@MEMBRE.COM", "MEMBRE@MEMBRE.COM", null, null, false, "Membre", "6339cfbb-98c9-4659-ad7f-afa7beeab313", false, "membre@membre.com" });

            migrationBuilder.InsertData(
                table: "Membres",
                columns: new[] { "Id", "CommandeId", "DateAdhesion", "NoMembre", "ReservationId" },
                values: new object[] { "2", null, new DateTime(2023, 9, 8, 10, 5, 8, 969, DateTimeKind.Local).AddTicks(1513), "123456", null });
        }
    }
}
