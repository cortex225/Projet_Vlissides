using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class NullableCommandePromo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "1112374f-5d74-4290-a149-606b328505e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "edda9b03-f34f-46bf-b368-4b653f9cd78e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0dd0b576-7e2b-4493-8ba5-766ac84b0d0c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0aef368d-8e0a-46c7-b1b1-1e5b5dadbec7", "edb9be11-f703-4a46-a76d-310133733ca3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dd4ffea7-3c2e-4516-ae68-e5e3e6a6a57b", "820cc7ee-8def-4a6a-a177-97f03a7ea20a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "b849293e-c7be-4779-b194-705a534eebe1", new DateTime(2023, 12, 1, 8, 4, 31, 412, DateTimeKind.Local).AddTicks(690), "fff61986-5e5c-45a7-beb8-957ce626b409" });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2023, 12, 1, 8, 4, 31, 413, DateTimeKind.Local).AddTicks(6100), new DateTime(2024, 12, 1, 8, 4, 31, 413, DateTimeKind.Local).AddTicks(6110) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
