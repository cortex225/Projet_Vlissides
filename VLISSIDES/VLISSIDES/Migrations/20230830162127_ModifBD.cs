using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class ModifBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Employes_EmployeId",
                table: "Commandes");

            migrationBuilder.DropForeignKey(
                name: "FK_Livres_Auteur_AuteurId",
                table: "Livres");

            migrationBuilder.DropForeignKey(
                name: "FK_Livres_MaisonEditions_MaisonEditionId",
                table: "Livres");

            migrationBuilder.DropIndex(
                name: "IX_Livres_AuteurId",
                table: "Livres");

            migrationBuilder.DropIndex(
                name: "IX_Commandes_EmployeId",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "AnneeEdition",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "Salaire",
                table: "Employes");

            migrationBuilder.DropColumn(
                name: "EmployeId",
                table: "Commandes");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Livres",
                newName: "Couverture");

            migrationBuilder.AlterColumn<string>(
                name: "MaisonEditionId",
                table: "Livres",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AuteurId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAjout",
                table: "Livres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Commentaire",
                table: "Evaluations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AuteurLivre",
                columns: table => new
                {
                    AuteurId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivresId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuteurLivre", x => new { x.AuteurId, x.LivresId });
                    table.ForeignKey(
                        name: "FK_AuteurLivre_Auteur_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Auteur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuteurLivre_Livres_LivresId",
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
                value: "b3a9cb75-f1b3-4449-af90-4de540bc8922");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6296ca22-de29-4858-9794-0bba32c625e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c114d2a4-50b8-4355-9550-1dc59ace886d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "54d72742-3e31-4aeb-bbf7-c0f2af31caff", "59f89033-59ee-46cc-9133-d4080d9ea0d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bc50f26b-4311-467a-8b08-18021e7c8714", "047e907a-121f-40ad-a69e-5c3b4b170439" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d0129dba-0f08-4e7e-b75c-ebac5f6504b1", "15b494ca-a351-469b-97b8-a1baaa077feb" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 8, 30, 12, 21, 27, 645, DateTimeKind.Local).AddTicks(8900));

            migrationBuilder.CreateIndex(
                name: "IX_AuteurLivre_LivresId",
                table: "AuteurLivre",
                column: "LivresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_MaisonEditions_MaisonEditionId",
                table: "Livres",
                column: "MaisonEditionId",
                principalTable: "MaisonEditions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livres_MaisonEditions_MaisonEditionId",
                table: "Livres");

            migrationBuilder.DropTable(
                name: "AuteurLivre");

            migrationBuilder.DropColumn(
                name: "DateAjout",
                table: "Livres");

            migrationBuilder.RenameColumn(
                name: "Couverture",
                table: "Livres",
                newName: "Image");

            migrationBuilder.AlterColumn<string>(
                name: "MaisonEditionId",
                table: "Livres",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuteurId",
                table: "Livres",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AnneeEdition",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Commentaire",
                table: "Evaluations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Salaire",
                table: "Employes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "EmployeId",
                table: "Commandes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "1b4f3dd9-64c2-447a-a0df-cee40569171c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a3433ba9-9917-495b-a843-e4b28e2ba333");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3b27c1d0-9c11-4fc2-b50f-ea4ea5e99e31");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2b818077-23a1-4383-9a35-9c35c698c77a", "642bb2d3-1ecd-4409-9033-7c1208361193" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e59ef3ec-d68d-46cb-b3c4-0254383b2b88", "1df1d194-2551-4ce5-9d19-4727f814bd3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eb617a5f-5265-471b-8aee-f5f8b4b1144a", "cdbe94fb-df5d-43c7-9e39-1da9cce112d7" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 8, 26, 13, 1, 30, 467, DateTimeKind.Local).AddTicks(9640));

            migrationBuilder.CreateIndex(
                name: "IX_Livres_AuteurId",
                table: "Livres",
                column: "AuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_EmployeId",
                table: "Commandes",
                column: "EmployeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Employes_EmployeId",
                table: "Commandes",
                column: "EmployeId",
                principalTable: "Employes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_Auteur_AuteurId",
                table: "Livres",
                column: "AuteurId",
                principalTable: "Auteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_MaisonEditions_MaisonEditionId",
                table: "Livres",
                column: "MaisonEditionId",
                principalTable: "MaisonEditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
