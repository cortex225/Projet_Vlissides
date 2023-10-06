using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class NoApartementAdresse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoApartement",
                table: "Adresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "9a80840e-b304-41b8-b5e6-9c8a1f45bba3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2d07c354-a53d-4e0e-8b5c-a536ed1ad72c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "78c5daef-95f7-413b-a13d-24c20dee2091");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b9e25615-a907-437d-8276-3016d35d9e55", "eed4807e-006d-4d24-9be7-ee2b561bafac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8792c120-b5a4-4ecd-8467-55b4b9e94ad1", "e709eb6f-29ad-424f-bc99-c574ecd5d286" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "b7ee83f7-272a-4af0-a80a-80078350f030", new DateTime(2023, 10, 5, 13, 23, 25, 660, DateTimeKind.Local).AddTicks(6636), "ec9edba0-7bf3-43e4-9cbd-28f25d9692c9" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 1",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 10",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3307));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 11",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3316));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 12",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3319));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 13",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3323));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 14",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3327));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 15",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3331));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 16",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 17",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3338));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 18",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3343));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 19",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3346));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 2",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 20",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3350));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 21",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 22",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3358));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 23",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 24",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3366));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 25",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 26",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 27",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 28",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3421));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 29",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 3",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 30",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 31",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3456));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 32",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3461));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 33",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3465));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 34",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 35",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 36",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3479));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 37",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 38",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 39",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3493));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 4",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 40",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 42",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 43",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3507));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 44",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 45",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 46",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3521));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 48",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3526));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 49",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3531));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 5",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3288));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 50",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 51",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 52",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3545));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 6",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3292));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 7",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 8",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3299));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 9",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 13, 23, 23, 962, DateTimeKind.Local).AddTicks(3303));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoApartement",
                table: "Adresses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "32580db4-fe50-4271-acb3-1ab25577f343");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f6ce6f6e-f38a-4f20-89c3-fbc5dce97c18");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4620bdae-1f4f-48b1-9dc4-2181e69be021");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c5aef00a-7526-4223-b395-afc397862e02", "128b2f2d-a705-45cd-a373-968b5ccc6c1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5c349bde-d69e-49b4-a1ee-8015270c3dac", "2afbb670-ed16-4e83-a7ce-e168908f0f48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "7f2d36c8-73ea-49a5-976b-a0155eacb011", new DateTime(2023, 10, 5, 11, 24, 10, 86, DateTimeKind.Local).AddTicks(1131), "f2536d25-a9e1-4643-9cf6-b2afd7f588f9" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 1",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 10",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 11",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2814));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 12",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2817));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 13",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2821));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 14",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 15",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2827));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 16",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 17",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2833));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 18",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 19",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2841));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 2",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 20",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2844));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 21",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 22",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 23",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 24",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 25",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2861));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 26",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 27",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 28",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2874));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 29",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2878));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 3",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 30",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 31",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2906));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 32",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 33",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2945));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 34",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2950));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 35",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2954));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 36",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 37",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2962));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 38",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2966));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 39",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2970));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 4",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 40",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2974));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 42",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 43",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2982));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 44",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 45",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 46",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 48",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 49",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 5",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 50",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 51",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(3044));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 52",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 6",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 7",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 8",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 9",
                column: "DateAjout",
                value: new DateTime(2023, 10, 5, 11, 24, 8, 445, DateTimeKind.Local).AddTicks(2797));
        }
    }
}
