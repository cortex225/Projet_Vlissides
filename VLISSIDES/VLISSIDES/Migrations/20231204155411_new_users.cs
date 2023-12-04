using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class new_users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "13296ef8-da74-4d00-8b11-fdddf98348b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "accb2fd9-39dc-4f84-ab3b-499dbec92037");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "11aba193-6067-475a-be4a-08035a22d78e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "2eb68eda-8b65-4098-ad83-3ecccb0c956e", "Admin@LaFourmiAilee.com", "ADMIN@LAFOURMIAILEE.COM", "ADMIN", "AQAAAAEAACcQAAAAEOXi3zx88svzJnjrrgIjWezeAP5AV6xLWjbOy+BXluDVgDmMl8898EdbaPXwpHW/eA==", "e25c5014-3f23-4630-9e5d-c8c5af49b04c", "Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "38d51f1f-b06f-4027-8255-0b2826497bc7", "55478378-2981-4952-85cc-f32ecbf053a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "541107a0-2591-43e0-8889-421a226b66f6", new DateTime(2023, 12, 4, 10, 54, 10, 858, DateTimeKind.Local).AddTicks(3090), "26ee9ec9-6e2f-47df-85fd-4df6ecee7e5c" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "CommandeId", "ConcurrencyStamp", "CoverImageUrl", "DateAdhesion", "DateNaissance", "DerniereUtilisationPromoAnniversaire", "Discriminator", "Email", "EmailConfirmed", "IsBanned", "LockoutEnabled", "LockoutEnd", "NoMembre", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "ReservationId", "SecurityStamp", "StripeCustomerId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4e62b674-1202-407d-b014-28c069b271ff", 0, null, null, "00d2318b-5e00-4ae2-bcbc-131126e797f4", null, new DateTime(2023, 12, 4, 10, 54, 10, 864, DateTimeKind.Local).AddTicks(2674), new DateTime(1993, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SFallu@gmail.com", true, false, false, null, "4d845512-fdc4-4e1e-82e5-cd07b4077058", "Fallu", "SFALLU@GMAIL.COM", "SFALLU@GMAIL.COM", "AQAAAAEAACcQAAAAEBGC1jP/z0J0iiEI+ds/PoRkUl20/b0XJs8uux470lTL+TCIBEmGbRenPAMEkXrCNQ==", null, false, "Stephane", null, "b656234e-6e65-4fae-92d0-fbef3010a1db", null, false, "SFallu@gmail.com" },
                    { "5e356b43-70cd-47c1-83ea-a9e7cea94aeb", 0, null, null, "ea7ecefc-ae31-4300-86c8-73fb0378949e", null, new DateTime(2023, 12, 4, 10, 54, 10, 870, DateTimeKind.Local).AddTicks(3055), new DateTime(2002, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SDemers@gmail.com", true, false, false, null, "8521678a-c1c9-4597-b761-e9d37811b4c5", "Demers", "SDEMERS@GMAIL.COM", "SDEMERS@GMAIL.COM", "AQAAAAEAACcQAAAAEN+pbHM3azfRvDM0JZ3oO0c3TNJWbuNacr+gwq1z96TwYGbwjmWPb3v5jWZ2APQacQ==", null, false, "Sylvie", null, "63357b51-ebef-4940-bfc1-c4dc3f357793", null, false, "SDemers@gmail.com" },
                    { "824dab2a-fa73-4f0a-873a-d9d4e8890537", 0, null, null, "7d782401-8be6-4f98-b89c-630e29cb5ea4", null, new DateTime(2023, 12, 4, 10, 54, 10, 876, DateTimeKind.Local).AddTicks(3524), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "jlgouaho@gmail.com", true, false, false, null, "68604ae5-de64-4583-954d-50590863102c", "JEAN-LUC GOUAHO", "JLGOUAHO@GMAIL.COM", "JLGOUAHO@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Deto", null, "7dfec992-ae24-4118-bf9b-946a0b6a4b8f", null, false, "jlgouaho@gmail.com" },
                    { "8f8ee25b-1f6e-4673-ba69-35470d80b471", 0, null, null, "9373be73-31d0-4cec-ad9b-4390accc7c19", null, new DateTime(2023, 12, 4, 10, 54, 10, 876, DateTimeKind.Local).AddTicks(3497), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "julien.landry1800@gmail.com", true, false, false, null, "786e73cb-df33-4104-b9bd-8c00148935e6", "Landry", "JULIEN.LANDRY1800@GMAIL.COM", "JULIEN.LANDRY1800@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Julien", null, "97d937e1-fb43-4638-be05-495f21e051c6", null, false, "julien.landry1800@gmail.com" },
                    { "92161059-8ae9-42eb-953e-17df93e25484", 0, null, null, "95e5de4e-b799-4a51-bf37-22d39a432f5c", null, new DateTime(2023, 12, 4, 10, 54, 10, 858, DateTimeKind.Local).AddTicks(3158), new DateTime(2001, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "MGosselin@gmail.com", true, false, false, null, "2969adbd-1832-46eb-a6cd-5e37780ec2a3", "Gosselin", "MGOSSELIN@GMAIL.COM", "MGOSSELIN@GMAIL.COM", "AQAAAAEAACcQAAAAEM80gjmoEciwE+JxzHnEHRtwNdumPHncQym35IccCyFMcGU1fH5mWKp5e1KNXzU9hA==", null, false, "Marcel", null, "4cacdd04-a591-4d43-b24f-a9d2cf6acfeb", null, false, "MGosselin@gmail.com" },
                    { "ed674c44-baf5-4a16-8573-33459ac1b1b1", 0, null, null, "e78d139a-d95e-425e-b3de-bb08b4f8804c", null, new DateTime(2023, 12, 4, 10, 54, 10, 876, DateTimeKind.Local).AddTicks(3443), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "tonyhuynh0412@gmail.com", true, false, false, null, "1e51277b-d1f5-40a7-82c9-169eecf871ca", "Huynh", "TONYHUYNH0412@GMAIL.COM", "TONYHUYNH0412@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Tony", null, "d058be5f-4909-4454-a590-4b7cec40a5eb", null, false, "tonyhuynh0412@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2023, 12, 4, 10, 54, 10, 878, DateTimeKind.Local).AddTicks(6131), new DateTime(2024, 12, 4, 10, 54, 10, 878, DateTimeKind.Local).AddTicks(6148) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "4e62b674-1202-407d-b014-28c069b271ff" },
                    { "1", "5e356b43-70cd-47c1-83ea-a9e7cea94aeb" },
                    { "1", "824dab2a-fa73-4f0a-873a-d9d4e8890537" },
                    { "1", "8f8ee25b-1f6e-4673-ba69-35470d80b471" },
                    { "1", "92161059-8ae9-42eb-953e-17df93e25484" },
                    { "1", "ed674c44-baf5-4a16-8573-33459ac1b1b1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "4e62b674-1202-407d-b014-28c069b271ff" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "5e356b43-70cd-47c1-83ea-a9e7cea94aeb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "824dab2a-fa73-4f0a-873a-d9d4e8890537" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "8f8ee25b-1f6e-4673-ba69-35470d80b471" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "92161059-8ae9-42eb-953e-17df93e25484" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "ed674c44-baf5-4a16-8573-33459ac1b1b1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e62b674-1202-407d-b014-28c069b271ff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e356b43-70cd-47c1-83ea-a9e7cea94aeb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "824dab2a-fa73-4f0a-873a-d9d4e8890537");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f8ee25b-1f6e-4673-ba69-35470d80b471");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92161059-8ae9-42eb-953e-17df93e25484");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed674c44-baf5-4a16-8573-33459ac1b1b1");

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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "0aef368d-8e0a-46c7-b1b1-1e5b5dadbec7", "admin@admin.com", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", "edb9be11-f703-4a46-a76d-310133733ca3", "admin@admin.com" });

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
    }
}
