using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class NewConfigDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LangueLivre");

            migrationBuilder.DropTable(
                name: "LivreTypeLivre");

            migrationBuilder.DropColumn(
                name: "NbExemplaires",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Livres");

            migrationBuilder.CreateTable(
                name: "LangueLivres",
                columns: table => new
                {
                    LangueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NbExemplaires = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangueLivres", x => new { x.LivreId, x.LangueId });
                    table.ForeignKey(
                        name: "FK_LangueLivres_Langues_LangueId",
                        column: x => x.LangueId,
                        principalTable: "Langues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LangueLivres_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivreTypeLivres",
                columns: table => new
                {
                    LivreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeLivreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivreTypeLivres", x => new { x.LivreId, x.TypeLivreId });
                    table.ForeignKey(
                        name: "FK_LivreTypeLivres_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivreTypeLivres_TypeLivres_TypeLivreId",
                        column: x => x.TypeLivreId,
                        principalTable: "TypeLivres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "77a9b9d3-79fe-499d-b5c2-68113d2cf48c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "67135e1a-0607-49ef-824c-c6129ae82fec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3044469d-3a83-4d72-8614-8d3c09445c67");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bab55943-43a3-44f4-91f8-f7ed12eb9eb6", "7b8e03bd-6b96-4010-9069-53692350707f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f42bfad6-4dda-47d2-ad74-077b4d788057", "1d2481f9-042d-42fc-80f1-f35c8e8d0500" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1df38215-7767-45e7-a776-e1e5613abf90", "43212926-18a7-45e4-877a-8214f41f07a1" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 9, 18, 14, 49, 11, 467, DateTimeKind.Local).AddTicks(7580));

            migrationBuilder.CreateIndex(
                name: "IX_LangueLivres_LangueId",
                table: "LangueLivres",
                column: "LangueId");

            migrationBuilder.CreateIndex(
                name: "IX_LivreTypeLivres_TypeLivreId",
                table: "LivreTypeLivres",
                column: "TypeLivreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LangueLivres");

            migrationBuilder.DropTable(
                name: "LivreTypeLivres");

            migrationBuilder.AddColumn<int>(
                name: "NbExemplaires",
                table: "Livres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Prix",
                table: "Livres",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
                value: "5dd03105-c527-4c7f-87a8-5e3ef720ee33");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a8b88f93-bb2a-4fa8-b96d-11d5edb42516");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f7e6effa-aeee-4127-9961-7fe9a2ae07ff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "95beb176-3120-4cd2-905c-a13d50ad8796", "0c9a3844-0ef8-4be2-89cf-72020b8e551d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "727cdc69-c1e2-4dfb-bf63-af01dd7229ea", "2481c91d-7dde-4eb1-8b8a-031d3b0a1f8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ef28c495-d52d-4486-bc53-b3f59c05d6ac", "fa5bb8a4-c791-4a46-862c-eedd27074973" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 9, 15, 10, 21, 19, 969, DateTimeKind.Local).AddTicks(6578));

            migrationBuilder.CreateIndex(
                name: "IX_LangueLivre_LivresId",
                table: "LangueLivre",
                column: "LivresId");

            migrationBuilder.CreateIndex(
                name: "IX_LivreTypeLivre_TypesLivreId",
                table: "LivreTypeLivre",
                column: "TypesLivreId");
        }
    }
}
