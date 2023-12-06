using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class TypeLivreCommande : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "LivreCommandes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeLivreId",
                table: "LivreCommandes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "8b13bae8-3f22-4343-9083-9c23d74cb5d7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "773bd310-5f70-4823-b386-6b53c4a8badf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e966d85e-2532-4a88-857f-c265d991c6ea");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a55f7f76-e9d7-40ee-b807-50992b331169", "AQAAAAEAACcQAAAAEMpEBSTl15U//hf+DKCuPnaINu8KjRLgmYKGNNpp78BR5gP4ciDNsjpTr1inBIrPiA==", "15578ce9-dfb8-4040-9459-70076218c322" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7ba01924-03d2-47ab-85a5-b49266d019f8", "420239f9-7033-40a7-99b9-2e31111eb489" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "7e624beb-8611-419c-bef9-db8c28c82012", new DateTime(2023, 12, 6, 15, 15, 27, 705, DateTimeKind.Local).AddTicks(580), "736702d1-e5d4-47b9-8b74-1b3f82647076" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "CommandeId", "ConcurrencyStamp", "CoverImageUrl", "DateAdhesion", "DateNaissance", "DerniereUtilisationPromoAnniversaire", "Discriminator", "Email", "EmailConfirmed", "IsBanned", "LockoutEnabled", "LockoutEnd", "NoMembre", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "ReservationId", "SecurityStamp", "StripeCustomerId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4db55fbc-1611-4f05-bcec-f39482704508", 0, null, null, "0e877831-c8ae-4618-ad57-0d0c533bcfbd", null, new DateTime(2023, 12, 6, 15, 15, 27, 709, DateTimeKind.Local).AddTicks(5660), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "tonyhuynh0412@gmail.com", true, false, false, null, "fb3b6b04-bdb3-4eb8-9e87-d306ff8f69d1", "Huynh", "TONYHUYNH0412@GMAIL.COM", "TONYHUYNH0412@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Tony", null, "d52f8108-bf87-4e96-8962-c2f9dd669ee7", null, false, "tonyhuynh0412@gmail.com" },
                    { "65e73fdb-3448-4f87-be89-930bb9c57705", 0, null, null, "7316ebd2-900f-42ef-966a-8603acdfe6f8", null, new DateTime(2023, 12, 6, 15, 15, 27, 709, DateTimeKind.Local).AddTicks(5720), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "jlgouaho@gmail.com", true, false, false, null, "60516431-ee0a-4017-93da-7ff470b3544b", "JEAN-LUC GOUAHO", "JLGOUAHO@GMAIL.COM", "JLGOUAHO@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Deto", null, "c45c7d3f-4631-4f90-9fd5-612cead9f4fb", null, false, "jlgouaho@gmail.com" },
                    { "75635bb6-aa9f-427e-afbd-529c49ec1340", 0, null, null, "d1c346cd-daa3-4c86-8f75-14f1891a511d", null, new DateTime(2023, 12, 6, 15, 15, 27, 708, DateTimeKind.Local).AddTicks(460), new DateTime(2002, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SDemers@gmail.com", true, false, false, null, "6298032d-0cc8-44ea-b762-422a2d7e4f2e", "Demers", "SDEMERS@GMAIL.COM", "SDEMERS@GMAIL.COM", "AQAAAAEAACcQAAAAEHyW3e2YqdB4xJvBgoD9v/YvqoaY9NRFwNaNpsBAjjaiBVuph8tLOe44rFCOZL2XNQ==", null, false, "Sylvie", null, "2c814f5c-f941-4669-a519-2c46770d973c", null, false, "SDemers@gmail.com" },
                    { "76573289-e8e4-4eba-9ad7-8100f93f2683", 0, null, null, "10317fd1-51ae-420f-9055-cd72a2b96d49", null, new DateTime(2023, 12, 6, 15, 15, 27, 706, DateTimeKind.Local).AddTicks(5620), new DateTime(1993, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SFallu@gmail.com", true, false, false, null, "98ba0b5b-6c08-4470-b86b-f6c2d8299949", "Fallu", "SFALLU@GMAIL.COM", "SFALLU@GMAIL.COM", "AQAAAAEAACcQAAAAEBF3p8XTDnJZ+x3KUZDKWEfdUQlTP0xBQe/V11WX7nEOhFZLLpAONHLLwKlou3IObw==", null, false, "Stephane", null, "caffad6b-1bf9-493f-93b1-fafe6ebf99ea", null, false, "SFallu@gmail.com" },
                    { "87e4ba6c-6b3f-43bb-a62c-8ceb03b2d1f9", 0, null, null, "aded9778-f039-408d-9cb5-9c940dcf5ee4", null, new DateTime(2023, 12, 6, 15, 15, 27, 705, DateTimeKind.Local).AddTicks(650), new DateTime(2001, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "MGosselin@gmail.com", true, false, false, null, "03a39bc6-19d9-4775-ab57-734e0b899135", "Gosselin", "MGOSSELIN@GMAIL.COM", "MGOSSELIN@GMAIL.COM", "AQAAAAEAACcQAAAAEMmv/ljkeJG9VEtdxlIGoskGDLqhEpREigsQooXNUwkBTR247wuirPzFmS9NTsWIgA==", null, false, "Marcel", null, "24133bdb-a706-4942-a7fa-f108370cf570", null, false, "MGosselin@gmail.com" },
                    { "c32ebd5c-ff9d-4a89-b78d-ec339a02d3a5", 0, null, null, "e4e94e12-a5bf-4053-978f-1bc2b1f66124", null, new DateTime(2023, 12, 6, 15, 15, 27, 709, DateTimeKind.Local).AddTicks(5690), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "julien.landry1800@gmail.com", true, false, false, null, "4ef1a43d-faca-4c75-ab78-163ccab517b0", "Landry", "JULIEN.LANDRY1800@GMAIL.COM", "JULIEN.LANDRY1800@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Julien", null, "62e024bf-4923-4ce5-b129-32028a6e7fb7", null, false, "julien.landry1800@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2023, 12, 6, 15, 15, 27, 710, DateTimeKind.Local).AddTicks(7600), new DateTime(2024, 12, 6, 15, 15, 27, 710, DateTimeKind.Local).AddTicks(7610) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "4db55fbc-1611-4f05-bcec-f39482704508" },
                    { "1", "65e73fdb-3448-4f87-be89-930bb9c57705" },
                    { "1", "75635bb6-aa9f-427e-afbd-529c49ec1340" },
                    { "1", "76573289-e8e4-4eba-9ad7-8100f93f2683" },
                    { "1", "87e4ba6c-6b3f-43bb-a62c-8ceb03b2d1f9" },
                    { "1", "c32ebd5c-ff9d-4a89-b78d-ec339a02d3a5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivreCommandes_TypeLivreId",
                table: "LivreCommandes",
                column: "TypeLivreId");

            migrationBuilder.AddForeignKey(
                name: "FK_LivreCommandes_TypeLivres_TypeLivreId",
                table: "LivreCommandes",
                column: "TypeLivreId",
                principalTable: "TypeLivres",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivreCommandes_TypeLivres_TypeLivreId",
                table: "LivreCommandes");

            migrationBuilder.DropIndex(
                name: "IX_LivreCommandes_TypeLivreId",
                table: "LivreCommandes");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "4db55fbc-1611-4f05-bcec-f39482704508" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "65e73fdb-3448-4f87-be89-930bb9c57705" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "75635bb6-aa9f-427e-afbd-529c49ec1340" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "76573289-e8e4-4eba-9ad7-8100f93f2683" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "87e4ba6c-6b3f-43bb-a62c-8ceb03b2d1f9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "c32ebd5c-ff9d-4a89-b78d-ec339a02d3a5" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4db55fbc-1611-4f05-bcec-f39482704508");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65e73fdb-3448-4f87-be89-930bb9c57705");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75635bb6-aa9f-427e-afbd-529c49ec1340");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76573289-e8e4-4eba-9ad7-8100f93f2683");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87e4ba6c-6b3f-43bb-a62c-8ceb03b2d1f9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c32ebd5c-ff9d-4a89-b78d-ec339a02d3a5");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "LivreCommandes");

            migrationBuilder.DropColumn(
                name: "TypeLivreId",
                table: "LivreCommandes");

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
