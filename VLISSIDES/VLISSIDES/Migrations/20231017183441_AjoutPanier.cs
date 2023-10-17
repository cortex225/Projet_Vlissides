using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class AjoutPanier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_AspNetUsers_UtilisateurLivraisonId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_AspNetUsers_UtilisateurPrincipalId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Adresses_AdresseId",
                table: "Commandes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateNaissance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NoApartement",
                table: "Adresses");

            migrationBuilder.RenameTable(
                name: "Adresses",
                newName: "Adresse");

            migrationBuilder.RenameIndex(
                name: "IX_Adresses_UtilisateurPrincipalId",
                table: "Adresse",
                newName: "IX_Adresse_UtilisateurPrincipalId");

            migrationBuilder.RenameIndex(
                name: "IX_Adresses_UtilisateurLivraisonId",
                table: "Adresse",
                newName: "IX_Adresse_UtilisateurLivraisonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresse",
                table: "Adresse",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LivrePanier",
                columns: table => new
                {
                    LivreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeLivreId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantite = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrePanier", x => new { x.LivreId, x.UserId });
                    table.ForeignKey(
                        name: "FK_LivrePanier_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LivrePanier_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivrePanier_TypeLivres_TypeLivreId",
                        column: x => x.TypeLivreId,
                        principalTable: "TypeLivres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Paniers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paniers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "dcb8c60f-2ead-4ab3-873f-9d0dce851c08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "50b71378-7e39-493b-9d05-392bf408551d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e0a055e6-11ff-46bc-932d-95de2563e6e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ddd6486c-6cc2-43fc-baa3-62b970718634", "35f907ae-6528-469c-950d-0e1345c6c90c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "56114952-b54b-431a-8e50-108c4373cb17", "c9b9d054-7529-49d7-819f-332629e0c7a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "95445dd1-73b1-47ff-bf2d-5e8e4a12464e", new DateTime(2023, 10, 17, 14, 34, 40, 368, DateTimeKind.Local).AddTicks(5144), "a7eeec32-2cfd-44d7-83fa-72f060291080" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 1",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 10",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9366));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 11",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 12",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9376));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 13",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 14",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9385));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 15",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9389));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 16",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 17",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 18",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 19",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9417));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 2",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 20",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 21",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9426));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 22",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 23",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 24",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 25",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 26",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 27",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 28",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 29",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 3",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 30",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 31",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 32",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 33",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 34",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 35",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 36",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 37",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 38",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 39",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9526));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 4",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 40",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9535));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 42",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 43",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 44",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 45",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 46",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9564));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 48",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 49",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 5",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 50",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9582));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 51",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 52",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 6",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 7",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 8",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 9",
                column: "DateAjout",
                value: new DateTime(2023, 10, 17, 14, 34, 40, 353, DateTimeKind.Local).AddTicks(9358));

            migrationBuilder.CreateIndex(
                name: "IX_LivrePanier_TypeLivreId",
                table: "LivrePanier",
                column: "TypeLivreId");

            migrationBuilder.CreateIndex(
                name: "IX_LivrePanier_UserId",
                table: "LivrePanier",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresse_AspNetUsers_UtilisateurLivraisonId",
                table: "Adresse",
                column: "UtilisateurLivraisonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresse_AspNetUsers_UtilisateurPrincipalId",
                table: "Adresse",
                column: "UtilisateurPrincipalId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Adresse_AdresseId",
                table: "Commandes",
                column: "AdresseId",
                principalTable: "Adresse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresse_AspNetUsers_UtilisateurLivraisonId",
                table: "Adresse");

            migrationBuilder.DropForeignKey(
                name: "FK_Adresse_AspNetUsers_UtilisateurPrincipalId",
                table: "Adresse");

            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Adresse_AdresseId",
                table: "Commandes");

            migrationBuilder.DropTable(
                name: "LivrePanier");

            migrationBuilder.DropTable(
                name: "Paniers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresse",
                table: "Adresse");

            migrationBuilder.RenameTable(
                name: "Adresse",
                newName: "Adresses");

            migrationBuilder.RenameIndex(
                name: "IX_Adresse_UtilisateurPrincipalId",
                table: "Adresses",
                newName: "IX_Adresses_UtilisateurPrincipalId");

            migrationBuilder.RenameIndex(
                name: "IX_Adresse_UtilisateurLivraisonId",
                table: "Adresses",
                newName: "IX_Adresses_UtilisateurLivraisonId");

            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateNaissance",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoApartement",
                table: "Adresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "c3b33c06-0ff4-4f10-9242-fd3bf729e989");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6fa32b3f-09a9-4f10-a09d-de40d7587126");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7d99ad11-389d-4e72-a168-0b7617296273");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "17912874-4b30-4083-a8d4-9e231bb1040b", "3ca11f2f-ffc0-472e-8f64-1e6f473fb97d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9724a9a7-76e5-4635-b27b-bb5dadc16011", "d2a96d67-19a8-4ba7-99d1-a218dc6ebf94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "08789319-b7d5-4edb-9f5c-ee23c87c2381", new DateTime(2023, 10, 16, 13, 2, 22, 974, DateTimeKind.Local).AddTicks(1260), "5909de22-aa9e-4950-bf73-e8fe80da1fcb" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 1",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 10",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 11",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 12",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 13",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 14",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 15",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 16",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 17",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 18",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 19",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 2",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 20",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 21",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 22",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 23",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 24",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 25",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 26",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 27",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 28",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 29",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 3",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 30",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 31",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 32",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 33",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 34",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 35",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 36",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 37",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 38",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 39",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 4",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 40",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 42",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 43",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 44",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 45",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 46",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 48",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 49",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 5",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 50",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 51",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 52",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5320));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 6",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 7",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 8",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 9",
                column: "DateAjout",
                value: new DateTime(2023, 10, 16, 13, 2, 22, 972, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_AspNetUsers_UtilisateurLivraisonId",
                table: "Adresses",
                column: "UtilisateurLivraisonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_AspNetUsers_UtilisateurPrincipalId",
                table: "Adresses",
                column: "UtilisateurPrincipalId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Adresses_AdresseId",
                table: "Commandes",
                column: "AdresseId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
