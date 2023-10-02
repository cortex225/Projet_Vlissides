using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class auteursBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Auteurs_AuteurId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Livres_LivresId",
                table: "AuteurLivre");

            migrationBuilder.DropTable(
                name: "CategorieLivre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuteurLivre",
                table: "AuteurLivre");

            migrationBuilder.RenameTable(
                name: "AuteurLivre",
                newName: "LivreAuteur");

            migrationBuilder.RenameColumn(
                name: "AuteurId",
                table: "LivreAuteur",
                newName: "AuteursId");

            migrationBuilder.RenameIndex(
                name: "IX_AuteurLivre_LivresId",
                table: "LivreAuteur",
                newName: "IX_LivreAuteur_LivresId");

            migrationBuilder.AlterColumn<string>(
                name: "CategorieId",
                table: "Livres",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivreAuteur",
                table: "LivreAuteur",
                columns: new[] { "AuteursId", "LivresId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "3999dfe4-2b05-4186-a1b6-10604e44c8b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "09b874ec-7959-4468-88f7-187c4320fb4f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "94304716-a4af-413c-97ca-040f33f64241");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0786ebab-a314-40d6-bea1-e18cdaae3ae6", "4d96bff5-8549-4c08-a6da-2b51fc703c34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6ae2292e-6234-446b-b278-b3f5ffa38b91", "3d9c0db6-aed9-4b68-b44b-9ef9b4a00cf1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e8bb73a4-80e7-49f4-a6d3-e9e1ec979f3e", "79922543-0eb1-4a66-b128-876e4496b53a" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 10, 2, 14, 55, 31, 550, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.CreateIndex(
                name: "IX_Livres_CategorieId",
                table: "Livres",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_LivreAuteur_Auteurs_AuteursId",
                table: "LivreAuteur",
                column: "AuteursId",
                principalTable: "Auteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LivreAuteur_Livres_LivresId",
                table: "LivreAuteur",
                column: "LivresId",
                principalTable: "Livres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_Categories_CategorieId",
                table: "Livres",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivreAuteur_Auteurs_AuteursId",
                table: "LivreAuteur");

            migrationBuilder.DropForeignKey(
                name: "FK_LivreAuteur_Livres_LivresId",
                table: "LivreAuteur");

            migrationBuilder.DropForeignKey(
                name: "FK_Livres_Categories_CategorieId",
                table: "Livres");

            migrationBuilder.DropIndex(
                name: "IX_Livres_CategorieId",
                table: "Livres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LivreAuteur",
                table: "LivreAuteur");

            migrationBuilder.RenameTable(
                name: "LivreAuteur",
                newName: "AuteurLivre");

            migrationBuilder.RenameColumn(
                name: "AuteursId",
                table: "AuteurLivre",
                newName: "AuteurId");

            migrationBuilder.RenameIndex(
                name: "IX_LivreAuteur_LivresId",
                table: "AuteurLivre",
                newName: "IX_AuteurLivre_LivresId");

            migrationBuilder.AlterColumn<string>(
                name: "CategorieId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuteurLivre",
                table: "AuteurLivre",
                columns: new[] { "AuteurId", "LivresId" });

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
                value: "a1bdff04-dbaa-4432-8015-187baaf12932");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "147c263a-0875-498a-b161-38fb26ec870e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "22af6d31-247b-467b-9a50-79f4057db226");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "13f670cc-aca0-414b-a2d6-304867c7470d", "68d89d93-099f-43bf-a5fe-12c4452d96bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "04c0c606-5e0a-4df2-acc1-07a77a66e8bb", "1bbfe1d8-1b91-49cb-9e99-413f48280320" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e6cd738d-940e-4435-9cff-0e3859bfbf6f", "447dc6ce-45fd-4e75-9e1b-d1cc882813a2" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 9, 27, 12, 4, 53, 400, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.CreateIndex(
                name: "IX_CategorieLivre_LivresId",
                table: "CategorieLivre",
                column: "LivresId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Auteurs_AuteurId",
                table: "AuteurLivre",
                column: "AuteurId",
                principalTable: "Auteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Livres_LivresId",
                table: "AuteurLivre",
                column: "LivresId",
                principalTable: "Livres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
