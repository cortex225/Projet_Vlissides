using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class AjoutAuteurDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Auteur_AuteurId",
                table: "AuteurLivre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auteur",
                table: "Auteur");

            migrationBuilder.RenameTable(
                name: "Auteur",
                newName: "Auteurs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auteurs",
                table: "Auteurs",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "46e87127-b2d0-46c8-b8b3-28d3ed2d5daf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ffd11bcd-42e0-41ad-ab60-9005c783c6e2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ce129d51-5a99-4659-bea1-9932e3a39ebd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "672ad12c-3d24-4db3-aac7-4269076afa7f", "3f380f74-c16c-41c8-bcf2-f66f2372058e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0f2f1080-8afd-4aae-a5e5-46b8954c9cd7", "a34c425e-eea1-4699-83fb-8fa45bd762c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "03031aa5-2b5c-4a7f-ae46-7e2c13e77ba7", "d80aae08-6a2f-4f43-8b83-3204c3fd821d" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 9, 6, 10, 21, 27, 950, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Auteurs_AuteurId",
                table: "AuteurLivre",
                column: "AuteurId",
                principalTable: "Auteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Auteurs_AuteurId",
                table: "AuteurLivre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auteurs",
                table: "Auteurs");

            migrationBuilder.RenameTable(
                name: "Auteurs",
                newName: "Auteur");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auteur",
                table: "Auteur",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Auteur_AuteurId",
                table: "AuteurLivre",
                column: "AuteurId",
                principalTable: "Auteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
