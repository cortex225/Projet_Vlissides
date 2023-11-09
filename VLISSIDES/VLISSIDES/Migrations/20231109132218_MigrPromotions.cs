using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class MigrPromotions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivrePromotions");

            migrationBuilder.DropColumn(
                name: "Rabais",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "LivreId",
                table: "Promotions",
                newName: "TypePromotion");

            migrationBuilder.AddColumn<string>(
                name: "AuteurId",
                table: "Promotions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategorieId",
                table: "Promotions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LivresAcheter",
                table: "Promotions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LivresGratuits",
                table: "Promotions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaisonEditionId",
                table: "Promotions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PourcentageRabais",
                table: "Promotions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "95e9b754-e6fd-4ae0-bb06-df8e24bde08a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d3b7514b-dfe5-4835-b361-7046473a6ce0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "1f30ed5e-d3f4-4a08-ac6e-f81946c756ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0f830a77-14ab-4ddb-8c88-b23d797d2adf", "b4b73a2c-61ea-4440-bb69-08e869da2650" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6a28c8a4-f0bf-4cc5-805e-65fd2c148781", "5df1a8b2-92ce-484e-b6fc-8e6484cd3ada" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "40bcb1ac-cc82-427c-a312-9d9c15956331", new DateTime(2023, 11, 9, 8, 22, 17, 359, DateTimeKind.Local).AddTicks(898), "479080a6-bba6-40af-a77c-ed340a445fcb" });

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_AuteurId",
                table: "Promotions",
                column: "AuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_CategorieId",
                table: "Promotions",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_MaisonEditionId",
                table: "Promotions",
                column: "MaisonEditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Auteurs_AuteurId",
                table: "Promotions",
                column: "AuteurId",
                principalTable: "Auteurs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Categories_CategorieId",
                table: "Promotions",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_MaisonEditions_MaisonEditionId",
                table: "Promotions",
                column: "MaisonEditionId",
                principalTable: "MaisonEditions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Auteurs_AuteurId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Categories_CategorieId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_MaisonEditions_MaisonEditionId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_AuteurId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_CategorieId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_MaisonEditionId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "AuteurId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "LivresAcheter",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "LivresGratuits",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "MaisonEditionId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "PourcentageRabais",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "TypePromotion",
                table: "Promotions",
                newName: "LivreId");

            migrationBuilder.AddColumn<decimal>(
                name: "Rabais",
                table: "Promotions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "LivrePromotions",
                columns: table => new
                {
                    LivresId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PromotionsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrePromotions", x => new { x.LivresId, x.PromotionsId });
                    table.ForeignKey(
                        name: "FK_LivrePromotions_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivrePromotions_Promotions_PromotionsId",
                        column: x => x.PromotionsId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "cf9f33c6-249e-46c8-96ec-5a33a63e1425");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7afa5a6c-9b42-4c08-93b5-3f431d272f6b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e1cde01a-d9e2-427b-9ed3-f3ad22793849");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4e02a892-9de9-422d-893a-9073f8179847", "d25cdff5-2584-4a46-b3a8-e4272c7227b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fd37f12e-a7b1-440b-99ad-8d4cb8bacc52", "abce17f6-b016-4363-991c-d54d1f0e7211" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "cce32a23-1677-4769-b16a-4236f4716d6f", new DateTime(2023, 11, 2, 13, 29, 18, 581, DateTimeKind.Local).AddTicks(2094), "d2909b13-0006-4560-abb0-fa9c5abb7c13" });

            migrationBuilder.CreateIndex(
                name: "IX_LivrePromotions_PromotionsId",
                table: "LivrePromotions",
                column: "PromotionsId");
        }
    }
}
