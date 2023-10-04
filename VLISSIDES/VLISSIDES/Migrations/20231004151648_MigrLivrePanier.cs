using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class MigrLivrePanier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivrePanier_Paniers_PanierId",
                table: "LivrePanier");

            migrationBuilder.DropForeignKey(
                name: "FK_Paniers_AspNetUsers_UserId",
                table: "Paniers");

            migrationBuilder.DropIndex(
                name: "IX_Paniers_UserId",
                table: "Paniers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Paniers");

            migrationBuilder.DropColumn(
                name: "PanierId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PanierId",
                table: "LivrePanier",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LivrePanier_PanierId",
                table: "LivrePanier",
                newName: "IX_LivrePanier_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "LivrePanier",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_LivrePanier_AspNetUsers_UserId",
                table: "LivrePanier",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivrePanier_AspNetUsers_UserId",
                table: "LivrePanier");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LivrePanier");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "LivrePanier",
                newName: "PanierId");

            migrationBuilder.RenameIndex(
                name: "IX_LivrePanier_UserId",
                table: "LivrePanier",
                newName: "IX_LivrePanier_PanierId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Paniers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PanierId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "0a6453f7-0f6e-4336-b8e5-abdb0a10ddaf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8a208fb9-c3dc-45fb-b0b2-966b6188d4f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ce16bf14-2a8f-40de-b189-3a53d0e4a1c2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3f2f0b6e-addd-4e57-bfbd-d4840dc263d0", "2869b2ac-d8bc-477e-b8c6-457b6d6db4c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "93686af5-e3e6-478d-830a-7c572e243cef", "fe9db49b-3684-4fbd-b173-11117bccf9ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "81090d1c-eb43-4f96-9bb1-6ee88ac90889", "0a37aaa1-def6-49f1-918d-e9deaf1b22ab" });

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
                value: new DateTime(2023, 10, 3, 10, 27, 31, 53, DateTimeKind.Local).AddTicks(7619));

            migrationBuilder.CreateIndex(
                name: "IX_Paniers_UserId",
                table: "Paniers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_LivrePanier_Paniers_PanierId",
                table: "LivrePanier",
                column: "PanierId",
                principalTable: "Paniers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paniers_AspNetUsers_UserId",
                table: "Paniers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
