using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class StripeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "6c84ccff-9a57-4f13-835d-ea9ce4dcc336");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "eb7361db-e190-4512-8953-34aa1feb150d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f7951ca9-9767-4045-aadc-52d81afc0982");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e7d8726-2cf1-40a1-ba49-d2cdd606d134", "AQAAAAEAACcQAAAAEPxVwXPrz4IHya2PaQqLnm7mAnjr37Bry0FUWU3Ml0peM+/KWNVWGyws/02otrUxWg==", "90aa73cf-ef22-4dc8-8cdf-b0ecb080aab2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5e6f0239-617d-405e-b469-bb495c755675", "436f4497-d40a-48ce-b822-3e429152fa0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "fdbdcc65-53e0-46f4-b3d3-c0365bc287a3", new DateTime(2023, 12, 6, 16, 18, 55, 469, DateTimeKind.Local).AddTicks(5089), "905ce405-e773-43f3-84ef-fc603fccddaa" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "CommandeId", "ConcurrencyStamp", "CoverImageUrl", "DateAdhesion", "DateNaissance", "DerniereUtilisationPromoAnniversaire", "Discriminator", "Email", "EmailConfirmed", "IsBanned", "LockoutEnabled", "LockoutEnd", "NoMembre", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "ReservationId", "SecurityStamp", "StripeCustomerId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d896767-1b1a-4304-bda6-a0f684438480", 0, null, null, "e9075e80-be7a-4426-8b12-3d15793a6f30", null, new DateTime(2023, 12, 6, 16, 18, 55, 469, DateTimeKind.Local).AddTicks(5170), new DateTime(2001, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "MGosselin@gmail.com", true, false, false, null, "5121f6d6-51a1-4c29-af06-4f7220a7b2c3", "Gosselin", "MGOSSELIN@GMAIL.COM", "MGOSSELIN@GMAIL.COM", "AQAAAAEAACcQAAAAEOPKeSDNYuybjzLsbGdRZv1WQ3QxtSjWbYT0cfKVyY1olTb/YFvTy81526+gEMih/g==", null, false, "Marcel", null, "b94cbc1c-1507-4d24-a66d-c308b8d7b8f2", "7", false, "MGosselin@gmail.com" },
                    { "3d2ac65a-13ef-4f7f-ac22-64364d461ace", 0, null, null, "c886459a-4551-4ce5-a333-d74cbd93a5b8", null, new DateTime(2023, 12, 6, 16, 18, 55, 496, DateTimeKind.Local).AddTicks(9268), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "jlgouaho@gmail.com", true, false, false, null, "31236c81-1b27-4c4d-9755-d01c996deba4", "JEAN-LUC GOUAHO", "JLGOUAHO@GMAIL.COM", "JLGOUAHO@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Deto", null, "3265e5da-5a0e-4352-a0e9-33df59360d52", "12", false, "jlgouaho@gmail.com" },
                    { "6b96a610-470f-42f5-b88e-468613a07176", 0, null, null, "d40faaf7-7dbe-436a-af8c-e0820157161b", null, new DateTime(2023, 12, 6, 16, 18, 55, 496, DateTimeKind.Local).AddTicks(3533), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "tonyhuynh0412@gmail.com", true, false, false, null, "280f3b78-8998-48aa-85ca-93a40f6f63e2", "Huynh", "TONYHUYNH0412@GMAIL.COM", "TONYHUYNH0412@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Tony", null, "de6ce93e-6b86-415b-a8cf-44ba1130377c", "10", false, "tonyhuynh0412@gmail.com" },
                    { "709366bb-c6bf-448e-952b-eecc4c11ad75", 0, null, null, "b48b3de9-47df-4fc9-b24c-bd9246017336", null, new DateTime(2023, 12, 6, 16, 18, 55, 481, DateTimeKind.Local).AddTicks(4762), new DateTime(1993, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SFallu@gmail.com", true, false, false, null, "ea1f18f5-74dc-4882-8f38-5c888754b458", "Fallu", "SFALLU@GMAIL.COM", "SFALLU@GMAIL.COM", "AQAAAAEAACcQAAAAEImkMyW82kjGgCczne7v/z7+6uM0GE8aRkN6vyOwolMNKY1zGr6D7TQZ5a1QkkToGQ==", null, false, "Stephane", null, "94b6a0f2-00ca-4288-b058-1f14294f9b21", "8", false, "SFallu@gmail.com" },
                    { "bb2a1a9e-7992-4a6f-9601-ab9961dad654", 0, null, null, "4aae3164-2228-4f80-9409-da2125676a31", null, new DateTime(2023, 12, 6, 16, 18, 55, 488, DateTimeKind.Local).AddTicks(8662), new DateTime(2002, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SDemers@gmail.com", true, false, false, null, "585f4203-cd2a-44b9-afe3-0927345d584e", "Demers", "SDEMERS@GMAIL.COM", "SDEMERS@GMAIL.COM", "AQAAAAEAACcQAAAAEIjhk6IAyxZoZRL4USk/PsHOoVc1Q45wtrJDOR/TzeYVbNfurfQFDFMMrX8hb3VUAQ==", null, false, "Sylvie", null, "288f2d6e-e8d4-4a13-9b62-808cea5e66ec", "9", false, "SDemers@gmail.com" },
                    { "ddf46807-72d9-42e8-8695-0373214ea7c5", 0, null, null, "e5fa9677-44c8-4dd8-b51d-94a8f808bbfa", null, new DateTime(2023, 12, 6, 16, 18, 55, 496, DateTimeKind.Local).AddTicks(7002), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "julien.landry1800@gmail.com", true, false, false, null, "866b8fcd-8f42-4b5f-8ae6-28b6ebe5fabd", "Landry", "JULIEN.LANDRY1800@GMAIL.COM", "JULIEN.LANDRY1800@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Julien", null, "d2e2af78-fab5-4e8f-b261-9f8d183434ae", "11", false, "julien.landry1800@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2023, 12, 6, 16, 18, 55, 500, DateTimeKind.Local).AddTicks(4168), new DateTime(2024, 12, 6, 16, 18, 55, 500, DateTimeKind.Local).AddTicks(4201) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "0d896767-1b1a-4304-bda6-a0f684438480" },
                    { "1", "3d2ac65a-13ef-4f7f-ac22-64364d461ace" },
                    { "1", "6b96a610-470f-42f5-b88e-468613a07176" },
                    { "1", "709366bb-c6bf-448e-952b-eecc4c11ad75" },
                    { "1", "bb2a1a9e-7992-4a6f-9601-ab9961dad654" },
                    { "1", "ddf46807-72d9-42e8-8695-0373214ea7c5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "0d896767-1b1a-4304-bda6-a0f684438480" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "3d2ac65a-13ef-4f7f-ac22-64364d461ace" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "6b96a610-470f-42f5-b88e-468613a07176" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "709366bb-c6bf-448e-952b-eecc4c11ad75" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "bb2a1a9e-7992-4a6f-9601-ab9961dad654" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "ddf46807-72d9-42e8-8695-0373214ea7c5" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d896767-1b1a-4304-bda6-a0f684438480");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d2ac65a-13ef-4f7f-ac22-64364d461ace");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b96a610-470f-42f5-b88e-468613a07176");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "709366bb-c6bf-448e-952b-eecc4c11ad75");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb2a1a9e-7992-4a6f-9601-ab9961dad654");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddf46807-72d9-42e8-8695-0373214ea7c5");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2eb68eda-8b65-4098-ad83-3ecccb0c956e", "AQAAAAEAACcQAAAAEOXi3zx88svzJnjrrgIjWezeAP5AV6xLWjbOy+BXluDVgDmMl8898EdbaPXwpHW/eA==", "e25c5014-3f23-4630-9e5d-c8c5af49b04c" });

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
    }
}
