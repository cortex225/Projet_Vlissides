using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class statutMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "89d85ed6-3c2a-4fe5-8abf-0bc68312ae66");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0041dad0-8e0c-43ff-b2dc-fb6138fc620b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "179633e9-7990-4053-87bb-ef373a00bec6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "00a1a65a-e9dd-4065-bbb0-7bf7dbdaa281", "a6296e15-ff00-4fd2-8cc3-145f0dd8443f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2a4c327f-4b52-4d56-aae7-6855cd490b6c", "897b72e7-e25d-4504-81ea-960d7fe04c49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "e503fc1b-43eb-4140-8191-385c20df6f1c", new DateTime(2023, 10, 27, 9, 22, 41, 320, DateTimeKind.Local).AddTicks(7775), "4fb62727-33ac-4bfa-9bec-882c2fdad2b1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
