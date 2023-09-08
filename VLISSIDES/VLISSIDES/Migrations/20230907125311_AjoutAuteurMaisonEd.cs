using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class AjoutAuteurMaisonEd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "0cc339c6-0e30-4db3-84af-26795643ba91");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b8aa1097-251b-4a96-a09e-bc95b40dd4bb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "36a20982-3a17-4a7b-adfc-076b90c0041d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5717dd26-e40b-416e-8e38-f14253537a9c", "9adf9d3e-444d-4194-a54f-85010ee671d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6e8e7708-3c77-468f-8d03-79274bc8ed98", "af02afa4-63a8-4a07-9c8f-5ccc99808271" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6941b50d-162c-472f-a9f1-ebbc2fa73e42", "4857af84-8c94-4938-aa7b-9ffac5755415" });

            migrationBuilder.InsertData(
                table: "Auteur",
                columns: new[] { "Id", "Biographie", "Nom", "Photo", "Prenom" },
                values: new object[] { "0", "Tony Stack est un auteur de livre de programmation", "Tony", "", "Stack" });

            migrationBuilder.InsertData(
                table: "MaisonEditions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { "0", "Maison d'édition par défaut" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 9, 7, 8, 53, 11, 321, DateTimeKind.Local).AddTicks(9460));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Auteur",
                keyColumn: "Id",
                keyValue: "0");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "c56a9b28-a528-4b2c-9b47-9f1e7d8945d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "955dc9c6-6992-4e7b-82b2-bc9f1062ecbd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "6738b73f-496b-42eb-a8a9-efb1ef2d959b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5cfbffb0-aa14-44cb-ae87-83f32fa6ae92", "f0859f7b-77ac-45af-bea7-f05d5fc3c254" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "160f58c1-39cc-4b4b-ad9a-18fec33b2d2f", "78dfdf2b-512a-4dc9-829e-b23415784679" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8c75bfad-0a5c-4a9d-bc9d-2c4d53136cf5", "6bcf3a84-2deb-4180-aa17-f56c66a33d2d" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 9, 1, 9, 32, 41, 711, DateTimeKind.Local).AddTicks(280));
        }
    }
}
