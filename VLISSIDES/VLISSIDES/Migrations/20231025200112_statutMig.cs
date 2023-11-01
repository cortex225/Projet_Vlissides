using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class statutMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatutId",
                table: "Commandes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "2cc8ea71-1300-46c4-8886-cb76a5699b35");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a4034e86-bed3-442a-9e2b-4c42f839043e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e691f32e-20fd-4bee-b5e1-0aa478a8c7ac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "544bf693-0a2e-43e5-a49b-649e34274654", "26f204d2-e830-4cab-9713-b06499fa9183" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aa5132b8-639f-4942-ba7e-12242330241e", "9f2f015c-4007-4f2a-ad45-ec5d388b2abd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "01862e6f-94bf-4450-aee2-ed07482e063f", new DateTime(2023, 10, 25, 16, 1, 11, 811, DateTimeKind.Local).AddTicks(4603), "19c8e0d6-1bb7-4eee-8827-38fc2686284b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatutId",
                table: "Commandes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "728f9176-8f48-4eac-89c2-8c8f250c27b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c49f435b-3fa1-4225-84a1-5a66e78313f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7bbe98e3-6c60-4957-95af-86b15d2c256e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a50bbdb6-b04a-4688-94a5-add07ef1ca89", "7f816b22-1a1e-4367-8925-577b22b3173f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f3c27b90-c8c2-490c-a76c-c8771cd88be5", "d4121991-a7d5-4178-8f4d-e33a02d65c42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "9052c028-6832-4fbb-8f5e-d3791f1caf28", new DateTime(2023, 10, 20, 15, 38, 5, 303, DateTimeKind.Local).AddTicks(5060), "88dad382-e8c0-4922-a2d6-68bcb1a46908" });
        }
    }
}
