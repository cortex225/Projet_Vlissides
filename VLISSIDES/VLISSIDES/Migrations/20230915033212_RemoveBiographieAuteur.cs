using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class RemoveBiographieAuteur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "db94b45e-0382-43e0-9113-7d8f9ed38b4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "14405cb3-327a-40c8-bded-8b229e8970e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "78f9c01e-d4fa-45fb-98da-c6a48c0f8afe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dd1e18cd-4cf3-45fe-aafd-78ce4bd06472", "045471be-5fcd-4fb3-8bc9-7a25db506f60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5c3f496d-4047-48ca-aac8-677b25329cb9", "ffa97939-91ed-4067-95d2-0dc8c1161a23" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Biographie",
                table: "Auteurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Auteurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "e9386584-0c23-4aa5-93b7-85a564364741");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "3e4356f1-f96f-46fd-b83a-4d2e5834777b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "201947fa-7480-4b3d-9123-1c289b4d81e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5e5f66f7-750c-4a5e-b0a1-e11745c76883", "3f1c8e31-c989-43fa-9888-2cfd6943be27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c4baf886-0afb-47ac-a0de-022d71809ccf", "b2103ed8-c276-499a-937c-ef1506fcbadf" });

            migrationBuilder.UpdateData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "Biographie", "Photo" },
                values: new object[] { "Tony Stack est un auteur de livre de programmation", "" });
        }
    }
}
