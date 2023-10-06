using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class QuantiteNullPanier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantite",
                table: "LivrePanier",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "LivrePanier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeLivreId",
                table: "LivrePanier",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "2ece0b19-536e-481e-a420-04f2888cdac1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "828ab35e-6a89-4953-8c2e-e6fe89445aa4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "bddead3b-fcca-485b-a526-22e45ada1795");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "149cd4e8-6c1a-4879-9c9e-5da41ecea977", "c7b9b36f-afaf-46f8-bdf6-b2666fa048b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7cf0f5ee-b6fe-4aa2-9205-3999c7e42d0a", "c7526b57-346f-4fb7-9d52-aed0a742c0c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "67696d99-d41c-49fd-81de-f5e9d92eb53c", "bafd1d7c-d048-4715-a222-527cef55c832" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 10, 6, 9, 55, 57, 507, DateTimeKind.Local).AddTicks(3640));

            migrationBuilder.CreateIndex(
                name: "IX_LivrePanier_TypeLivreId",
                table: "LivrePanier",
                column: "TypeLivreId");

            migrationBuilder.AddForeignKey(
                name: "FK_LivrePanier_TypeLivres_TypeLivreId",
                table: "LivrePanier",
                column: "TypeLivreId",
                principalTable: "TypeLivres",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivrePanier_TypeLivres_TypeLivreId",
                table: "LivrePanier");

            migrationBuilder.DropIndex(
                name: "IX_LivrePanier_TypeLivreId",
                table: "LivrePanier");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "LivrePanier");

            migrationBuilder.DropColumn(
                name: "TypeLivreId",
                table: "LivrePanier");

            migrationBuilder.AlterColumn<int>(
                name: "Quantite",
                table: "LivrePanier",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "2c423e42-1070-45c2-9bc4-e90dad478104");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9519bbae-d45a-4852-8aa3-a4ebc4254587");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "13410292-b8ee-4b23-9fde-a0c77a8790a5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a8b83384-03a6-4829-a134-b7ff71e06dca", "9abde0ac-99b3-4124-8422-dacd11ae4092" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bbc6a194-349e-41ad-aac6-bd9077f66f01", "6f688265-0d70-4775-ac7c-9452eedfb17c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7c6427c3-b270-4084-a071-b52171a3b888", "b36e15c9-85b9-4fe3-9c22-c8504a7beaf9" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 10, 4, 11, 16, 45, 846, DateTimeKind.Local).AddTicks(2852));
        }
    }
}
