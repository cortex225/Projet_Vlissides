using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class NbCommande : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1cc3577d-0bf6-40f1-b616-c899aaba10b4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "630a12a4-2f1b-48f0-9962-92cb14b52864" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "864256e7-58e6-4e0d-b930-59cb013daed4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "8fb2569c-a542-4a03-9933-8431f135d50f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "c46a0013-3c64-4e20-b850-11500033ca48" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "e74f0492-8c65-4ff5-8b9f-0672c3184388" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cc3577d-0bf6-40f1-b616-c899aaba10b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "630a12a4-2f1b-48f0-9962-92cb14b52864");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "864256e7-58e6-4e0d-b930-59cb013daed4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8fb2569c-a542-4a03-9933-8431f135d50f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c46a0013-3c64-4e20-b850-11500033ca48");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e74f0492-8c65-4ff5-8b9f-0672c3184388");

            migrationBuilder.AddColumn<int>(
                name: "NbCommande",
                table: "Commandes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "e0cb292c-70b7-4ed2-9bae-846ca31631f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0d9060a6-bc69-472e-aec0-4743db7b1bf0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "83d29e42-e66a-4a7c-b4b4-3ba68f717b96");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12241e07-1ea4-485a-b6d4-97f957bb50f4", "AQAAAAEAACcQAAAAEMlMZGidhDg8wkvzcWyAy2DtETdmicOZRVaOKCXMSlwafHVVlR/4bpxqSIHgCEHHSg==", "6fdf68e2-04e6-4da9-aa7d-a2f8f3745d32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eb869a3e-1460-4490-8876-d122e96c39cc", "e64c6668-41c6-4350-b0fe-d61ac6e50414" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "585c61e9-2c29-4ea1-889d-e4529dd5ab51", new DateTime(2023, 12, 6, 20, 29, 45, 612, DateTimeKind.Local).AddTicks(9300), "976f935a-a910-444f-b9fc-0a4f2b7e9a35" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "CommandeId", "ConcurrencyStamp", "CoverImageUrl", "DateAdhesion", "DateNaissance", "DerniereUtilisationPromoAnniversaire", "Discriminator", "Email", "EmailConfirmed", "IsBanned", "LockoutEnabled", "LockoutEnd", "NoMembre", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "ReservationId", "SecurityStamp", "StripeCustomerId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2d0dcc51-82ae-4520-8039-e029f5b30b80", 0, null, null, "e0022dae-a2c2-49d3-ac18-00f69678fb2d", null, new DateTime(2023, 12, 6, 20, 29, 46, 113, DateTimeKind.Local).AddTicks(9100), new DateTime(2002, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SDemers@gmail.com", true, false, false, null, "1cf74b38-0bc3-4341-90e7-b0aae719f05f", "Demers", "SDEMERS@GMAIL.COM", "SDEMERS@GMAIL.COM", "AQAAAAEAACcQAAAAEPUrv9z3JBLvqas8Dlf1RfIFeSQ9OSXc1CCFNFo/cZXlYBhmK6qJCaE5m/AEmwZw+g==", null, false, "Sylvie", null, "a6008d4a-5caf-42f6-82ad-9f23dae1d64e", "cus_P8o1crvRVUNv3r", false, "SDemers@gmail.com" },
                    { "5dcb31b2-d156-45a9-9296-02982f6807c0", 0, null, null, "64dc521c-54d0-4b87-bd93-a79d43d3e4d8", null, new DateTime(2023, 12, 6, 20, 29, 46, 398, DateTimeKind.Local).AddTicks(750), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "tonyhuynh0412@gmail.com", true, false, false, null, "cb2c6550-4bed-4df2-8b42-99c14cbffec4", "Huynh", "TONYHUYNH0412@GMAIL.COM", "TONYHUYNH0412@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Tony", null, "55d04af8-7cce-4e40-89de-d3355980f735", "cus_P8o1tIZm2kd7Wu", false, "tonyhuynh0412@gmail.com" },
                    { "7240b266-2f25-49b5-908a-eb8793c41dfc", 0, null, null, "a1ea7b63-5465-403e-8dde-f6a5d8fea884", null, new DateTime(2023, 12, 6, 20, 29, 46, 972, DateTimeKind.Local).AddTicks(6390), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "jlgouaho@gmail.com", true, false, false, null, "53eb4989-82b8-4acc-85f8-f293dec292da", "JEAN-LUC GOUAHO", "JLGOUAHO@GMAIL.COM", "JLGOUAHO@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Deto", null, "cff3068b-a93c-4b8b-acb4-7e643f801a05", "cus_P8o1FtkBziP38o", false, "jlgouaho@gmail.com" },
                    { "766ffdf7-7cea-4e82-a971-65db624e2562", 0, null, null, "1449c731-fbda-44a6-b087-b36d9e8640ad", null, new DateTime(2023, 12, 6, 20, 29, 46, 721, DateTimeKind.Local).AddTicks(7770), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "julien.landry1800@gmail.com", true, false, false, null, "3cbc6703-db91-49f0-a9f6-fe2a0ef2f2df", "Landry", "JULIEN.LANDRY1800@GMAIL.COM", "JULIEN.LANDRY1800@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Julien", null, "bad572d5-df9f-49b4-840e-95da4370e713", "cus_P8o1BoE2SiNZ9K", false, "julien.landry1800@gmail.com" },
                    { "de34a710-ff6e-4bcd-a724-f4a3365e37d0", 0, null, null, "44c51ff8-fade-4ccc-a354-edf49c88b318", null, new DateTime(2023, 12, 6, 20, 29, 45, 848, DateTimeKind.Local).AddTicks(9380), new DateTime(1993, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SFallu@gmail.com", true, false, false, null, "a19b1e4f-2c4c-4c0c-a044-c01ba0796162", "Fallu", "SFALLU@GMAIL.COM", "SFALLU@GMAIL.COM", "AQAAAAEAACcQAAAAEPQ+3BzLaS+aoXIEadyFmGB0lKAPKIJIK9t6eg+idxlErqmODtVZOAsFT/PfGwolZA==", null, false, "Stephane", null, "61b075f8-c93e-4a04-ba9b-7ce75b591717", "cus_P8o1HjbZkomGHe", false, "SFallu@gmail.com" },
                    { "e378bca4-54ad-40f4-b04e-1ddd0f02e259", 0, null, null, "3cbb189f-377e-48f8-8f0d-55e56fd63710", null, new DateTime(2023, 12, 6, 20, 29, 45, 612, DateTimeKind.Local).AddTicks(9370), new DateTime(2001, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "MGosselin@gmail.com", true, false, false, null, "c95db8aa-6b2e-4c53-b5e2-017cc58deb74", "Gosselin", "MGOSSELIN@GMAIL.COM", "MGOSSELIN@GMAIL.COM", "AQAAAAEAACcQAAAAEF2nfD6h6Om7hpYnB31Y3+X9tfG2NHWeRKO5fu6ZWJjotyk9rPS2RuvPOFssFIKBGg==", null, false, "Marcel", null, "16e094cb-90b0-433c-964e-ced1939d7f5d", "cus_P8o1nRzwtvg5o1", false, "MGosselin@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2023, 12, 6, 20, 29, 47, 244, DateTimeKind.Local).AddTicks(4510), new DateTime(2024, 12, 6, 20, 29, 47, 244, DateTimeKind.Local).AddTicks(4640) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "2d0dcc51-82ae-4520-8039-e029f5b30b80" },
                    { "1", "5dcb31b2-d156-45a9-9296-02982f6807c0" },
                    { "1", "7240b266-2f25-49b5-908a-eb8793c41dfc" },
                    { "1", "766ffdf7-7cea-4e82-a971-65db624e2562" },
                    { "1", "de34a710-ff6e-4bcd-a724-f4a3365e37d0" },
                    { "1", "e378bca4-54ad-40f4-b04e-1ddd0f02e259" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "2d0dcc51-82ae-4520-8039-e029f5b30b80" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "5dcb31b2-d156-45a9-9296-02982f6807c0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "7240b266-2f25-49b5-908a-eb8793c41dfc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "766ffdf7-7cea-4e82-a971-65db624e2562" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "de34a710-ff6e-4bcd-a724-f4a3365e37d0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "e378bca4-54ad-40f4-b04e-1ddd0f02e259" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d0dcc51-82ae-4520-8039-e029f5b30b80");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5dcb31b2-d156-45a9-9296-02982f6807c0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7240b266-2f25-49b5-908a-eb8793c41dfc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "766ffdf7-7cea-4e82-a971-65db624e2562");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "de34a710-ff6e-4bcd-a724-f4a3365e37d0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e378bca4-54ad-40f4-b04e-1ddd0f02e259");

            migrationBuilder.DropColumn(
                name: "NbCommande",
                table: "Commandes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "110cb6d3-0b4a-4ff6-b8b6-e6dedd983598");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "3021d7ce-ad34-400f-8d36-259707b75658");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7e363143-d17f-4ee7-b56e-b8c44c7a430a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1d41154-228b-45cf-aa6f-e1cff6731c57", "AQAAAAEAACcQAAAAEArmaxuP2j3GApIrP3Wd6eEoEu4qUPeHIzwT5yu3YYvYhNWf/QV7GzbbJ2x5YmkURw==", "e3bcb8bd-2d2c-49ff-be19-21162db81d5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "08658480-40d2-4f1a-86ad-8b88580d801a", "ffd56fe5-e7c4-4859-af11-53c6c6e9e004" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "952d981a-9e7f-40d6-a839-13f9fc633d45", new DateTime(2023, 12, 6, 17, 10, 13, 909, DateTimeKind.Local).AddTicks(9524), "e9c61617-e753-4003-9839-2583c919b43e" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "CommandeId", "ConcurrencyStamp", "CoverImageUrl", "DateAdhesion", "DateNaissance", "DerniereUtilisationPromoAnniversaire", "Discriminator", "Email", "EmailConfirmed", "IsBanned", "LockoutEnabled", "LockoutEnd", "NoMembre", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "ReservationId", "SecurityStamp", "StripeCustomerId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1cc3577d-0bf6-40f1-b616-c899aaba10b4", 0, null, null, "db7b3e9c-1e5c-48d5-9a2d-835e6bff5591", null, new DateTime(2023, 12, 6, 17, 10, 13, 909, DateTimeKind.Local).AddTicks(9598), new DateTime(2001, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "MGosselin@gmail.com", true, false, false, null, "812d8ca1-16f7-424f-b2dd-f291b4d3cacf", "Gosselin", "MGOSSELIN@GMAIL.COM", "MGOSSELIN@GMAIL.COM", "AQAAAAEAACcQAAAAEB21x2Sh38TgcRSlUPs3RXI+cc7d8m6g+tDNDHgVzklfn2QsONshFVqJAWizWZHOXA==", null, false, "Marcel", null, "279680b1-2880-49d6-b2a5-afd3c8918b3f", "cus_P8knZ1kGW0sz3H", false, "MGosselin@gmail.com" },
                    { "630a12a4-2f1b-48f0-9962-92cb14b52864", 0, null, null, "11dd8c99-f85c-46fc-87e4-347994a00cab", null, new DateTime(2023, 12, 6, 17, 10, 15, 20, DateTimeKind.Local).AddTicks(4767), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "julien.landry1800@gmail.com", true, false, false, null, "aabc24df-25c4-4eed-9ec0-3b00d08e4ef5", "Landry", "JULIEN.LANDRY1800@GMAIL.COM", "JULIEN.LANDRY1800@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Julien", null, "ffd09dc2-d3c1-4400-9147-33cc5b4f14e4", "cus_P8knvna8W2zmbt", false, "julien.landry1800@gmail.com" },
                    { "864256e7-58e6-4e0d-b930-59cb013daed4", 0, null, null, "932edc7c-2fb1-40b5-9b05-03397e62037a", null, new DateTime(2023, 12, 6, 17, 10, 14, 744, DateTimeKind.Local).AddTicks(1451), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "tonyhuynh0412@gmail.com", true, false, false, null, "88c8ebe3-4950-47ac-86ba-078f4665dbe7", "Huynh", "TONYHUYNH0412@GMAIL.COM", "TONYHUYNH0412@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Tony", null, "9c98a089-17b0-45d7-8d06-369c376c425c", "cus_P8knhUwfzckmBX", false, "tonyhuynh0412@gmail.com" },
                    { "8fb2569c-a542-4a03-9933-8431f135d50f", 0, null, null, "842876f8-eed7-4c2f-a26e-85260a18e8d6", null, new DateTime(2023, 12, 6, 17, 10, 15, 301, DateTimeKind.Local).AddTicks(4577), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "jlgouaho@gmail.com", true, false, false, null, "e60d8c30-c55d-4f18-866c-82aa6e2a5bb9", "JEAN-LUC GOUAHO", "JLGOUAHO@GMAIL.COM", "JLGOUAHO@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Deto", null, "b20f7db2-832a-42a4-b106-e581637121e0", "cus_P8knXLFm8XLzyv", false, "jlgouaho@gmail.com" },
                    { "c46a0013-3c64-4e20-b850-11500033ca48", 0, null, null, "b7abd779-bd2b-4f9c-b5ad-59e8354eb577", null, new DateTime(2023, 12, 6, 17, 10, 14, 469, DateTimeKind.Local).AddTicks(3062), new DateTime(2002, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SDemers@gmail.com", true, false, false, null, "840a0751-eb47-422b-9de2-e7a09835947b", "Demers", "SDEMERS@GMAIL.COM", "SDEMERS@GMAIL.COM", "AQAAAAEAACcQAAAAEJDaJIqws1VmbIOvRfVYqthTRY6ZJF/4rM6Pls/z++v/0jLlTtqWlWDEypZZRKGc7w==", null, false, "Sylvie", null, "b35c3def-6569-49a6-bd2e-c88ba67e62be", "cus_P8kn4syNS9uDRE", false, "SDemers@gmail.com" },
                    { "e74f0492-8c65-4ff5-8b9f-0672c3184388", 0, null, null, "e72e1414-2aa5-4c81-8b59-48b43b68c9d0", null, new DateTime(2023, 12, 6, 17, 10, 14, 177, DateTimeKind.Local).AddTicks(624), new DateTime(1993, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SFallu@gmail.com", true, false, false, null, "dac0f285-cd07-4f21-a716-231ba49aabf6", "Fallu", "SFALLU@GMAIL.COM", "SFALLU@GMAIL.COM", "AQAAAAEAACcQAAAAEE3A6mxzhnQthl+1YkF3q5nIE4afFRFlKJUyQQtyYuEbEUCDbc7eQzVpgMKPAuIfnA==", null, false, "Stephane", null, "24b412cf-1751-4f9b-9542-fb3438af71e8", "cus_P8knyK9oBalz9v", false, "SFallu@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2023, 12, 6, 17, 10, 15, 565, DateTimeKind.Local).AddTicks(1036), new DateTime(2024, 12, 6, 17, 10, 15, 565, DateTimeKind.Local).AddTicks(1138) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1cc3577d-0bf6-40f1-b616-c899aaba10b4" },
                    { "1", "630a12a4-2f1b-48f0-9962-92cb14b52864" },
                    { "1", "864256e7-58e6-4e0d-b930-59cb013daed4" },
                    { "1", "8fb2569c-a542-4a03-9933-8431f135d50f" },
                    { "1", "c46a0013-3c64-4e20-b850-11500033ca48" },
                    { "1", "e74f0492-8c65-4ff5-8b9f-0672c3184388" }
                });
        }
    }
}
