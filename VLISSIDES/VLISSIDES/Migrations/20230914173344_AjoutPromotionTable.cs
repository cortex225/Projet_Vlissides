using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class AjoutPromotionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PromotionId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rabais = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LivreId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

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
                value: "1c67c141-c716-4311-9874-4f5987bcb5a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2f7d9903-780c-48fd-aa9e-f7748ef51cd9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "eff70cff-436b-4157-8535-38d41d882feb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fd57dae5-02eb-4ea4-b76f-ba7d4f85214a", "c7107399-c5aa-4869-b037-6a459139cc13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9a338a2f-caf3-47b8-9977-0eefa3cac7ee", "9b1791f2-2360-4e86-b5fc-10f4e06a17ef" });

            migrationBuilder.CreateIndex(
                name: "IX_LivrePromotions_PromotionsId",
                table: "LivrePromotions",
                column: "PromotionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivrePromotions");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "Livres");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "0d57c48d-b7e5-4739-bd77-a342d9d48cf8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d8f6d50f-0f61-4abf-8942-d64fd72ac4bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a8b5843c-856b-4fec-a911-e3dc0f340ef2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d3bb7dda-000d-46c2-90ac-4eac42fd33e4", "c5ae5bf8-4a7b-4ca2-aab0-ee990119d557" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "528933e3-213c-462f-9869-a3f15cb84072", "74330c46-14ab-4b16-8128-fb802e46a1d7" });
        }
    }
}
