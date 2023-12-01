using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class QuantiteReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantite",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "f5b472ec-6ca7-4d88-b1ec-3d913f2bca7a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0b32e8ed-bb3e-4399-a6fb-e2d3ada7b875");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4513676b-c2d9-4768-a242-17fbd0cd5c6c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4605452d-0935-469f-be2c-606fe0decc56", "ad4f4d4c-30fa-489a-84ba-a0f0d4044111" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6b6f1375-58ec-4017-a7ff-d92d999e750d", "365f4fb1-fc9c-4efa-be57-7a0a26936c4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "d235d337-d682-44e6-babf-f8d13bd895f7", new DateTime(2023, 11, 30, 22, 17, 53, 963, DateTimeKind.Local).AddTicks(1980), "729824db-26d0-44f8-b86e-add377414172" });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2023, 11, 30, 22, 17, 53, 964, DateTimeKind.Local).AddTicks(4590), new DateTime(2024, 11, 30, 22, 17, 53, 964, DateTimeKind.Local).AddTicks(4600) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantite",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "4e3defef-fd63-46d9-adbc-cac978fceaf8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "06d824f0-0a23-4a77-bc02-cffb88753c20");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "33a0afee-5087-4a53-a4c9-db7b7ee16030");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3974ae47-29eb-4c59-9bbe-b299510d15f7", "67608d1f-1540-4c7a-a504-0539ccc87d38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3a6b48e2-4594-468c-aeb2-5a3305386b56", "1f67e694-322a-4474-bcf0-32cfc5e5a478" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "1a8abc18-9339-4068-83ad-a9b813e8fca1", new DateTime(2023, 11, 30, 15, 31, 56, 146, DateTimeKind.Local).AddTicks(5310), "cfa88946-1d29-45cd-82ab-39521a5b0d4d" });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2023, 11, 30, 15, 31, 56, 147, DateTimeKind.Local).AddTicks(7020), new DateTime(2024, 11, 30, 15, 31, 56, 147, DateTimeKind.Local).AddTicks(7030) });
        }
    }
}
