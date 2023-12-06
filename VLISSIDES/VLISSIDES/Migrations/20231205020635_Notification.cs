using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class Notification : Migration
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

            migrationBuilder.CreateTable(
                name: "DemandesNotifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivreId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MembreId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationEnvoyee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandesNotifications", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "cfbf5b98-a7f6-48ae-83d9-13f2230f92d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "5e0d02a6-922b-432b-aa81-67ad041204d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e7f42044-2521-46b7-afab-5e6c4a74d94e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "272482d4-553a-4096-ac2c-1e54acbb3bfd", "AQAAAAEAACcQAAAAEAo7PhWeLZZ2tKCnY5yIAxNHCHU7WWV3GEooTEC26GHK5SuZABBCyY9bcIAAFlKfrg==", "c54fb1af-ebd2-4b85-b48d-1c0004d4c68a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "09561c45-2f9d-47f0-8b75-5c1975dc4f7f", "911f26db-3561-4127-85ac-3d17e4301a1e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "4e9d092b-e82f-4c4f-893c-46506370b474", new DateTime(2023, 12, 4, 21, 6, 35, 102, DateTimeKind.Local).AddTicks(7000), "437cef99-f30d-4545-aeeb-b755d2341e39" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "CommandeId", "ConcurrencyStamp", "CoverImageUrl", "DateAdhesion", "DateNaissance", "DerniereUtilisationPromoAnniversaire", "Discriminator", "Email", "EmailConfirmed", "IsBanned", "LockoutEnabled", "LockoutEnd", "NoMembre", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "ReservationId", "SecurityStamp", "StripeCustomerId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "07b5ee0b-0c88-4ebe-a33f-f0cd29bf5fdd", 0, null, null, "bd457a03-9927-4999-9ff7-0116f28c9fcd", null, new DateTime(2023, 12, 4, 21, 6, 35, 102, DateTimeKind.Local).AddTicks(7110), new DateTime(2001, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "MGosselin@gmail.com", true, false, false, null, "3dfbd47f-68bd-4139-99d7-9a0c6bfe48ad", "Gosselin", "MGOSSELIN@GMAIL.COM", "MGOSSELIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPPEjWQ/0w6VsaZkrmvgWx352N9mp5cKY9pJXGUNvrdxokXpYLDUQ5ohxmXXmweXUw==", null, false, "Marcel", null, "30afd22e-1068-4f40-bde0-79d4ac88602a", null, false, "MGosselin@gmail.com" },
                    { "47b32c19-94c4-45de-b0a7-6db92f7afe32", 0, null, null, "c0717dbd-f0c0-4aa1-be6a-464773b841a9", null, new DateTime(2023, 12, 4, 21, 6, 35, 110, DateTimeKind.Local).AddTicks(420), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "tonyhuynh0412@gmail.com", true, false, false, null, "af6ff0cc-93c3-4515-a67f-819618362f4a", "Huynh", "TONYHUYNH0412@GMAIL.COM", "TONYHUYNH0412@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Tony", null, "d1043fdd-fd6d-4112-8a73-dbfc3d6e7948", null, false, "tonyhuynh0412@gmail.com" },
                    { "76770f55-e7fd-4e77-9761-fa049460dbf1", 0, null, null, "e52be1f6-8c75-4497-aba7-dd2001d268e7", null, new DateTime(2023, 12, 4, 21, 6, 35, 110, DateTimeKind.Local).AddTicks(560), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "jlgouaho@gmail.com", true, false, false, null, "6e8e9ab3-78fb-409d-ba9a-cc04b78c6ade", "JEAN-LUC GOUAHO", "JLGOUAHO@GMAIL.COM", "JLGOUAHO@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Deto", null, "0cf076f2-f85b-4711-9566-ff299f7833cf", null, false, "jlgouaho@gmail.com" },
                    { "a55b5478-6aea-4dec-b77d-340f9fdebf04", 0, null, null, "45e6f856-ac8f-460d-91cd-290a1460b617", null, new DateTime(2023, 12, 4, 21, 6, 35, 110, DateTimeKind.Local).AddTicks(530), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "julien.landry1800@gmail.com", true, false, false, null, "ce09b99f-a836-4a42-b4de-139d8e124f13", "Landry", "JULIEN.LANDRY1800@GMAIL.COM", "JULIEN.LANDRY1800@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Julien", null, "0986d456-e240-405d-9c2d-e4522b3fbe50", null, false, "julien.landry1800@gmail.com" },
                    { "afdb3e81-d39e-4727-972f-73cd8a28c63d", 0, null, null, "629e1d12-12ab-4272-b43f-fd28755cff11", null, new DateTime(2023, 12, 4, 21, 6, 35, 104, DateTimeKind.Local).AddTicks(3450), new DateTime(1993, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SFallu@gmail.com", true, false, false, null, "deb908d9-a48a-4f6a-b195-b4b725fe38e4", "Fallu", "SFALLU@GMAIL.COM", "SFALLU@GMAIL.COM", "AQAAAAEAACcQAAAAEEzZm/gA15nKZPmfAOfviRGO1TvwGlW8u2SDz4KiTgL6pCE3jbJEBfuncfWdGXubPA==", null, false, "Stephane", null, "ea179d20-c4b8-42ef-8af0-c16221e6677a", null, false, "SFallu@gmail.com" },
                    { "e905ba63-97cf-4d3e-8fa7-184714ce6dc4", 0, null, null, "57cfc9a7-a00d-475b-8940-bb29c3ab7d77", null, new DateTime(2023, 12, 4, 21, 6, 35, 106, DateTimeKind.Local).AddTicks(1570), new DateTime(2002, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SDemers@gmail.com", true, false, false, null, "751a2db2-ae98-497b-bf88-689947f78237", "Demers", "SDEMERS@GMAIL.COM", "SDEMERS@GMAIL.COM", "AQAAAAEAACcQAAAAEOj4TDlAtRIzaCool+nupDTIHZjeBzWK25+L1m4OvQ66sB0MXhXgt9u2mKfUZe5pYQ==", null, false, "Sylvie", null, "fa4d4516-3f21-4d81-943d-0a4f349e5cbe", null, false, "SDemers@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2023, 12, 4, 21, 6, 35, 111, DateTimeKind.Local).AddTicks(9450), new DateTime(2024, 12, 4, 21, 6, 35, 111, DateTimeKind.Local).AddTicks(9470) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "07b5ee0b-0c88-4ebe-a33f-f0cd29bf5fdd" },
                    { "1", "47b32c19-94c4-45de-b0a7-6db92f7afe32" },
                    { "1", "76770f55-e7fd-4e77-9761-fa049460dbf1" },
                    { "1", "a55b5478-6aea-4dec-b77d-340f9fdebf04" },
                    { "1", "afdb3e81-d39e-4727-972f-73cd8a28c63d" },
                    { "1", "e905ba63-97cf-4d3e-8fa7-184714ce6dc4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandesNotifications");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "07b5ee0b-0c88-4ebe-a33f-f0cd29bf5fdd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "47b32c19-94c4-45de-b0a7-6db92f7afe32" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "76770f55-e7fd-4e77-9761-fa049460dbf1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "a55b5478-6aea-4dec-b77d-340f9fdebf04" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "afdb3e81-d39e-4727-972f-73cd8a28c63d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "e905ba63-97cf-4d3e-8fa7-184714ce6dc4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "07b5ee0b-0c88-4ebe-a33f-f0cd29bf5fdd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47b32c19-94c4-45de-b0a7-6db92f7afe32");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76770f55-e7fd-4e77-9761-fa049460dbf1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a55b5478-6aea-4dec-b77d-340f9fdebf04");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afdb3e81-d39e-4727-972f-73cd8a28c63d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e905ba63-97cf-4d3e-8fa7-184714ce6dc4");

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
