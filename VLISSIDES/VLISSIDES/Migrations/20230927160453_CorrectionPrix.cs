using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
    public partial class SousCategorieEtlivre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
========
    public partial class CorrectionPrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Livres");

>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                value: "fd6a4eb6-bc19-42bd-8fa2-1496336275f7");
========
                value: "a1bdff04-dbaa-4432-8015-187baaf12932");
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                value: "f9b32fba-751e-4f34-a7e8-10fa664a0902");
========
                value: "147c263a-0875-498a-b161-38fb26ec870e");
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                value: "bdd77309-0c31-4439-b819-bc585b387c83");
========
                value: "22af6d31-247b-467b-9a50-79f4057db226");
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                values: new object[] { "8fb0918b-b21e-4cd8-83ef-1c92f8cb886e", "87d621fd-66ad-4c96-bfd5-ea8490dee9b8" });
========
                values: new object[] { "13f670cc-aca0-414b-a2d6-304867c7470d", "68d89d93-099f-43bf-a5fe-12c4452d96bc" });
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                values: new object[] { "418ec111-7366-40a3-88ae-89ddfbffc593", "bf943785-a0a1-4e28-a766-7fe6042851c7" });
========
                values: new object[] { "04c0c606-5e0a-4df2-acc1-07a77a66e8bb", "1bbfe1d8-1b91-49cb-9e99-413f48280320" });
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                values: new object[] { "fef3b071-0ea9-4f3c-90f4-ee9a98733036", "1eae0cb9-f3f5-4c86-9f05-e918ecf8744d" });
========
                values: new object[] { "e6cd738d-940e-4435-9cff-0e3859bfbf6f", "447dc6ce-45fd-4e75-9e1b-d1cc882813a2" });
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                value: new DateTime(2023, 9, 27, 2, 43, 44, 992, DateTimeKind.Local).AddTicks(4069));
========
                value: new DateTime(2023, 9, 27, 12, 4, 53, 400, DateTimeKind.Local).AddTicks(7740));
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
========
            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "Livres",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                value: "6a497f02-c308-49d4-b87f-fc1a31550885");
========
                value: "29a31da7-9fd9-482a-a352-1a34f9f8f660");
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                value: "d90a19ad-7a61-43ca-bed1-adb9ee244fc9");
========
                value: "a0a47bae-65d4-41b4-a4e0-2c7f37ebedb3");
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                value: "e59eb724-6f87-42af-b9a3-bd2c53f96783");
========
                value: "dea02b89-e2ea-4865-9519-aa03351ebc56");
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                values: new object[] { "ecf24450-2ba0-41ee-90b5-c41dae18e93e", "19305552-b9a3-4713-b453-e0b67497831c" });
========
                values: new object[] { "b04622cd-fa73-40ab-807e-a3a72af020cd", "2f92bcc1-7556-402c-9402-86025719668e" });
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                values: new object[] { "e68a9614-6c74-468c-b85d-afa67dcd8bff", "6f4ba369-1d6d-4584-8e25-a089d79995b6" });
========
                values: new object[] { "e4ec2015-b6fc-4a6e-8324-5467571a59a7", "daf99feb-2887-4160-98c7-4bc90fb30acc" });
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                values: new object[] { "b5672468-2349-44d8-9e92-4622f02aad3a", "3d5b76c0-044e-489c-849a-5356ee854100" });
========
                values: new object[] { "9e680542-d13b-453b-9c5a-d39cbc02f328", "a8dfc137-ee10-4550-8c43-1c2d208788e7" });
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs

            migrationBuilder.UpdateData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2",
                column: "DateAdhesion",
<<<<<<<< HEAD:VLISSIDES/VLISSIDES/Migrations/20230927064345_SousCategorieEtlivre.cs
                value: new DateTime(2023, 9, 27, 1, 58, 35, 457, DateTimeKind.Local).AddTicks(9348));
========
                value: new DateTime(2023, 9, 27, 11, 25, 10, 375, DateTimeKind.Local).AddTicks(2980));
>>>>>>>> Dev:VLISSIDES/VLISSIDES/Migrations/20230927160453_CorrectionPrix.cs
        }
    }
}
