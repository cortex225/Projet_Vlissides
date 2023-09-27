using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class livre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Auteurs_AuteurId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Livres_LivreId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "LangueLivre");

            migrationBuilder.DropTable(
                name: "LivreTypeLivre");

            migrationBuilder.DropIndex(
                name: "IX_Categories_LivreId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AuteurId",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "EvaluationId",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "LivreId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "AuteurId",
                table: "AuteurLivre",
                newName: "AuteursId");

            migrationBuilder.AlterColumn<string>(
                name: "TypeLivreId",
                table: "Livres",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LangueId",
                table: "Livres",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CategorieLivre",
                columns: table => new
                {
                    CategoriesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivresId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieLivre", x => new { x.CategoriesId, x.LivresId });
                    table.ForeignKey(
                        name: "FK_CategorieLivre_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieLivre_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "6a497f02-c308-49d4-b87f-fc1a31550885");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d90a19ad-7a61-43ca-bed1-adb9ee244fc9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e59eb724-6f87-42af-b9a3-bd2c53f96783");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ecf24450-2ba0-41ee-90b5-c41dae18e93e", "19305552-b9a3-4713-b453-e0b67497831c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e68a9614-6c74-468c-b85d-afa67dcd8bff", "6f4ba369-1d6d-4584-8e25-a089d79995b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b5672468-2349-44d8-9e92-4622f02aad3a", "3d5b76c0-044e-489c-849a-5356ee854100" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 9, 27, 1, 58, 35, 457, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.CreateIndex(
                name: "IX_Livres_LangueId",
                table: "Livres",
                column: "LangueId");

            migrationBuilder.CreateIndex(
                name: "IX_Livres_TypeLivreId",
                table: "Livres",
                column: "TypeLivreId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieLivre_LivresId",
                table: "CategorieLivre",
                column: "LivresId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Auteurs_AuteursId",
                table: "AuteurLivre",
                column: "AuteursId",
                principalTable: "Auteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_Langues_LangueId",
                table: "Livres",
                column: "LangueId",
                principalTable: "Langues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_TypeLivres_TypeLivreId",
                table: "Livres",
                column: "TypeLivreId",
                principalTable: "TypeLivres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Auteurs_AuteursId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_Livres_Langues_LangueId",
                table: "Livres");

            migrationBuilder.DropForeignKey(
                name: "FK_Livres_TypeLivres_TypeLivreId",
                table: "Livres");

            migrationBuilder.DropTable(
                name: "CategorieLivre");

            migrationBuilder.DropIndex(
                name: "IX_Livres_LangueId",
                table: "Livres");

            migrationBuilder.DropIndex(
                name: "IX_Livres_TypeLivreId",
                table: "Livres");

            migrationBuilder.RenameColumn(
                name: "AuteursId",
                table: "AuteurLivre",
                newName: "AuteurId");

            migrationBuilder.AlterColumn<string>(
                name: "TypeLivreId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LangueId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AuteurId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategorieId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EvaluationId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PromotionId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LivreId",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LangueLivre",
                columns: table => new
                {
                    LanguesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivresId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangueLivre", x => new { x.LanguesId, x.LivresId });
                    table.ForeignKey(
                        name: "FK_LangueLivre_Langues_LanguesId",
                        column: x => x.LanguesId,
                        principalTable: "Langues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LangueLivre_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivreTypeLivre",
                columns: table => new
                {
                    LivresId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypesLivreId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivreTypeLivre", x => new { x.LivresId, x.TypesLivreId });
                    table.ForeignKey(
                        name: "FK_LivreTypeLivre_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivreTypeLivre_TypeLivres_TypesLivreId",
                        column: x => x.TypesLivreId,
                        principalTable: "TypeLivres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "1425afc6-d689-4c1b-b6c6-e4eec13b9a30");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f1734582-e509-4b17-97c1-7a83de6c56f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "328b76fe-c601-4167-9511-0eacffab3982");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b9dce7d3-dda5-4cf5-8ca9-4707e581442c", "589cf1d4-b639-4952-8787-29481bb66771" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c1009391-3126-49f3-8938-ae3203a3593d", "c9231fed-e9e5-4c33-b0f4-99d17e0d2acd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ad6808e9-efb3-4362-a20f-95ee30b80640", "c8136eff-853d-4f56-82f7-a3f9b46019a8" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 9, 27, 0, 13, 17, 252, DateTimeKind.Local).AddTicks(7310));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LivreId",
                table: "Categories",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_LangueLivre_LivresId",
                table: "LangueLivre",
                column: "LivresId");

            migrationBuilder.CreateIndex(
                name: "IX_LivreTypeLivre_TypesLivreId",
                table: "LivreTypeLivre",
                column: "TypesLivreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Auteurs_AuteurId",
                table: "AuteurLivre",
                column: "AuteurId",
                principalTable: "Auteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Livres_LivreId",
                table: "Categories",
                column: "LivreId",
                principalTable: "Livres",
                principalColumn: "Id");
        }
    }
}
