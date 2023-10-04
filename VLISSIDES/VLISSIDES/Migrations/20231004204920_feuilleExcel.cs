using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class feuilleExcel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_AspNetUsers_UtilisateurLivraisonId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_AspNetUsers_UtilisateurPrincipalId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Membres_MembreId",
                table: "Commandes");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Membres_MembreId",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Favoris_Membres_MembreId",
                table: "Favoris");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Membres_MembreId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "AuteurLivre");

            migrationBuilder.DropTable(
                name: "CategorieLivre");

            migrationBuilder.DropTable(
                name: "Employes");

            migrationBuilder.DropTable(
                name: "LangueLivre");

            migrationBuilder.DropTable(
                name: "Membres");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_UtilisateurLivraisonId",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_UtilisateurPrincipalId",
                table: "Adresses");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DropColumn(
                name: "AuteurId",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "EvaluationId",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "TypeLivreId",
                table: "Livres");

            migrationBuilder.RenameColumn(
                name: "AdresseLivraisonId",
                table: "AspNetUsers",
                newName: "ReservationId");

            migrationBuilder.AddColumn<double>(
                name: "Prix",
                table: "TypeLivres",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "LangueId",
                table: "Livres",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AdressePrincipaleId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommandeId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdhesion",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NoEmploye",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoMembre",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UtilisateurPrincipalId",
                table: "Adresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UtilisateurLivraisonId",
                table: "Adresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Adresses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LivreAuteurs",
                columns: table => new
                {
                    LivreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuteurId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivreAuteurs", x => new { x.LivreId, x.AuteurId });
                    table.ForeignKey(
                        name: "FK_LivreAuteurs_Auteurs_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Auteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivreAuteurs_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivreCategories",
                columns: table => new
                {
                    LivreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategorieId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivreCategories", x => new { x.LivreId, x.CategorieId });
                    table.ForeignKey(
                        name: "FK_LivreCategories_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivreCategories_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "706f1b7e-4122-480f-a45b-9c5768959648");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ebb08d38-75dd-4034-a6db-c47b5ee9ffd3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a47224ef-08f8-4154-b0a1-895dd5d82cb3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0", 0, null, "cd7c15a9-4d9e-4757-9aa8-2ef34fd9f29d", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Admin", "de3729eb-68b8-49b7-bb7b-3675b8d7c711", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NoEmploye", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "", "d094ebfd-565f-4725-8ccf-a235ee584ae3", "Employe", "employe@employe.com", true, false, null, "007", "EMPLOYE", "EMPLOYE@EMPLOYE.COM", "EMPLOYE@EMPLOYE.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Employe", "e26736a3-d203-4d6d-bf87-065ab4ea1ced", false, "employe@employe.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "CommandeId", "ConcurrencyStamp", "DateAdhesion", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NoMembre", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "ReservationId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "", null, "a8f7e6d7-5fe6-4012-bd5b-f0629e0061ff", new DateTime(2023, 10, 4, 16, 49, 19, 965, DateTimeKind.Local).AddTicks(8048), "Membre", "membre@membre.com", true, false, null, "123456", "MEMBRE", "MEMBRE@MEMBRE.COM", "MEMBRE@MEMBRE.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Membre", null, "f3f6f01d-ad72-44d4-a852-1c16a0146b3f", false, "membre@membre.com" });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "Id", "NomAuteur" },
                values: new object[,]
                {
                    { "Excel 1", "Antoine de Saint-Exupéry" },
                    { "Excel 10", "René Barjavel" },
                    { "Excel 11", "Giuseppe Tomasi di Lampedusa" },
                    { "Excel 12", "Bernard Werber" },
                    { "Excel 13", "Herman Melville" },
                    { "Excel 14", "Fiodor Dostoïevski" },
                    { "Excel 15", "Mikhaïl Boulgakov" },
                    { "Excel 16", "Patrick Süskind" },
                    { "Excel 17", "Joseph Kessel" },
                    { "Excel 18", "Albert Camus" },
                    { "Excel 19", "Donna Tartt" },
                    { "Excel 2", "J.K. Rowling" },
                    { "Excel 20", "Anne Frank" },
                    { "Excel 22", "Homère" },
                    { "Excel 23", "Ernest Hemingway" },
                    { "Excel 24", "Helen Fielding" },
                    { "Excel 25", "Aldous Huxley" },
                    { "Excel 26", "Paulo Coelho" },
                    { "Excel 27", "Oscar Wilde" },
                    { "Excel 28", "Alexandre Dumas" },
                    { "Excel 3", "George Orwell" },
                    { "Excel 31", "Khaled Hosseini" },
                    { "Excel 32", "Alain-Fournier" },
                    { "Excel 33", "Kurt Cobain" },
                    { "Excel 34", "Charles Baudelaire" },
                    { "Excel 35", "Francis Ponge" },
                    { "Excel 36", "Frères Grimm" },
                    { "Excel 37", "Charles Perrault" },
                    { "Excel 38", "Hans Christian Andersen" },
                    { "Excel 39", "Anonyme (contes populaires)" },
                    { "Excel 4", "J.R.R. Tolkien" },
                    { "Excel 40", "Pierre Gripari" },
                    { "Excel 42", "Catherine Gueguen" },
                    { "Excel 43", "Pierre Rabhi" },
                    { "Excel 44", "Audrey Akoun et Isabelle Pailleau" },
                    { "Excel 45", "Anne Bérubé & Geneviève Racine" }
                });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "Id", "NomAuteur" },
                values: new object[,]
                {
                    { "Excel 46", "Audrey Zucchi" },
                    { "Excel 48", "René Goscinny" },
                    { "Excel 49", "Hergé" },
                    { "Excel 5", "Umberto Eco" },
                    { "Excel 50", "Art Spiegelman" },
                    { "Excel 51", "Marjane Satrapi" },
                    { "Excel 52", "Alan Moore" },
                    { "Excel 6", "Jane Austen" },
                    { "Excel 7", "Boris Vian" },
                    { "Excel 8", "Victor Hugo" },
                    { "Excel 9", "Stendhal" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "15",
                column: "Nom",
                value: "Histoire");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "31",
                column: "Nom",
                value: "Sport");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom", "ParentId" },
                values: new object[,]
                {
                    { "Excel 34", "", "Poésie", null },
                    { "Excel 42", "", "Pédagogie", null },
                    { "Excel 43", "", "Maternité", null },
                    { "Excel 48", "", "BD", null },
                    { "Sous-Catégorie 11-1", "", "Flore", "11" },
                    { "Sous-Catégorie 12-1", "", "Voyage", "12" },
                    { "Sous-Catégorie 13-1", "", "Économie", "13" },
                    { "Sous-Catégorie 13-2", "", "droit", "13" },
                    { "Sous-Catégorie 15-1", "", "Politique", "15" },
                    { "Sous-Catégorie 20-1", "", "Famille", "20" },
                    { "Sous-Catégorie 21-1", "", "Théâtre", "21" },
                    { "Sous-Catégorie 21-2", "", "Essais", "21" },
                    { "Sous-Catégorie 22-1", "", "Santé", "22" },
                    { "Sous-Catégorie 23-1", "", "Ésotérisme", "23" },
                    { "Sous-Catégorie 31-1", "", "Loisirs", "31" },
                    { "Sous-Catégorie 7-1", "", "Vin", "7" },
                    { "Sous-Catégorie 9-1", "", "Langues", "9" },
                    { "Sous-Catégorie 9-2", "", "Éducation", "9" }
                });

            migrationBuilder.InsertData(
                table: "MaisonEditions",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { "Excel 1", "Gallimard" },
                    { "Excel 10", "Folio" },
                    { "Excel 11", "Gallimard" },
                    { "Excel 12", "Albin Michel" },
                    { "Excel 13", "Penguin Classics" },
                    { "Excel 14", "Le Livre de Poche" },
                    { "Excel 15", "Le Livre de Poche" },
                    { "Excel 16", "Pocket" },
                    { "Excel 17", "Gallimard" },
                    { "Excel 18", "Gallimard" },
                    { "Excel 19", "Plume de Paon" }
                });

            migrationBuilder.InsertData(
                table: "MaisonEditions",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { "Excel 2", "Gallimard Jeunesse" },
                    { "Excel 20", "Le Livre de Poche" },
                    { "Excel 21", "Folio" },
                    { "Excel 22", "Flammarion" },
                    { "Excel 23", "Folio" },
                    { "Excel 24", "Belfond" },
                    { "Excel 25", "Pocket" },
                    { "Excel 26", "Flammarion" },
                    { "Excel 27", "Livre de Poche Classiques" },
                    { "Excel 28", "Le Livre de Poche" },
                    { "Excel 29", "Christian Bourgois Éditeur" },
                    { "Excel 3", "Secker and Warburg" },
                    { "Excel 30", "Le Livre de Poche" },
                    { "Excel 31", "Belfond" },
                    { "Excel 32", "Le Livre de Poche" },
                    { "Excel 33", "Camion Blanc" },
                    { "Excel 34", "Le Livre de Poche" },
                    { "Excel 35", "Gallimard" },
                    { "Excel 36", "Gallimard" },
                    { "Excel 37", "Le Livre de Poche" },
                    { "Excel 38", "Flammarion" },
                    { "Excel 39", "Le Livre de Poche" },
                    { "Excel 4", "Christian Bourgois Éditeur" },
                    { "Excel 40", "Folio Junior" },
                    { "Excel 42", "Les Arènes" },
                    { "Excel 43", "Actes Sud" },
                    { "Excel 44", "Eyrolles" },
                    { "Excel 45", "Nathan" },
                    { "Excel 46", "Eyrolles" },
                    { "Excel 48", "Hachette" },
                    { "Excel 49", "Casterman" },
                    { "Excel 5", "Grasset" },
                    { "Excel 50", "Flammarion" },
                    { "Excel 51", "L'Association" },
                    { "Excel 52", "DC Comics" },
                    { "Excel 6", "Penguin Classics" },
                    { "Excel 7", "Gallimard" },
                    { "Excel 8", "Penguin Classics" },
                    { "Excel 9", "Le Livre de Poche" }
                });

            migrationBuilder.InsertData(
                table: "TypeLivres",
                columns: new[] { "Id", "Nom", "Prix" },
                values: new object[,]
                {
                    { "Numérique Excel 10", "Numérique", 22.0 },
                    { "Numérique Excel 12", "Numérique", 20.0 },
                    { "Numérique Excel 13", "Numérique", 18.0 }
                });

            migrationBuilder.InsertData(
                table: "TypeLivres",
                columns: new[] { "Id", "Nom", "Prix" },
                values: new object[,]
                {
                    { "Numérique Excel 15", "Numérique", 22.0 },
                    { "Numérique Excel 16", "Numérique", 14.0 },
                    { "Numérique Excel 2", "Numérique", 30.0 },
                    { "Numérique Excel 22", "Numérique", 31.5 },
                    { "Numérique Excel 23", "Numérique", 24.75 },
                    { "Numérique Excel 24", "Numérique", 15.0 },
                    { "Numérique Excel 25", "Numérique", 20.0 },
                    { "Numérique Excel 29", "Numérique", 32.0 },
                    { "Numérique Excel 36", "Numérique", 24.0 },
                    { "Numérique Excel 37", "Numérique", 28.0 },
                    { "Numérique Excel 38", "Numérique", 20.0 },
                    { "Numérique Excel 39", "Numérique", 22.0 },
                    { "Numérique Excel 4", "Numérique", 27.0 },
                    { "Numérique Excel 40", "Numérique", 12.0 },
                    { "Numérique Excel 42", "Numérique", 50.0 },
                    { "Numérique Excel 43", "Numérique", 21.0 },
                    { "Numérique Excel 44", "Numérique", 48.0 },
                    { "Numérique Excel 45", "Numérique", 30.0 },
                    { "Numérique Excel 46", "Numérique", 25.0 },
                    { "Papier Excel 1", "Papier", 22.25 },
                    { "Papier Excel 10", "Papier", 32.0 },
                    { "Papier Excel 11", "Papier", 28.0 },
                    { "Papier Excel 12", "Papier", 26.0 },
                    { "Papier Excel 13", "Papier", 22.0 },
                    { "Papier Excel 14", "Papier", 13.0 },
                    { "Papier Excel 15", "Papier", 24.0 },
                    { "Papier Excel 16", "Papier", 18.0 },
                    { "Papier Excel 17", "Papier", 30.0 },
                    { "Papier Excel 18", "Papier", 18.0 },
                    { "Papier Excel 19", "Papier", 25.0 },
                    { "Papier Excel 2", "Papier", 32.75 },
                    { "Papier Excel 20", "Papier", 19.75 },
                    { "Papier Excel 21", "Papier", 22.0 },
                    { "Papier Excel 22", "Papier", 31.5 },
                    { "Papier Excel 23", "Papier", 24.75 },
                    { "Papier Excel 24", "Papier", 18.25 },
                    { "Papier Excel 25", "Papier", 26.0 },
                    { "Papier Excel 26", "Papier", 18.0 },
                    { "Papier Excel 27", "Papier", 21.0 },
                    { "Papier Excel 28", "Papier", 17.0 },
                    { "Papier Excel 29", "Papier", 36.0 },
                    { "Papier Excel 3", "Papier", 18.0 }
                });

            migrationBuilder.InsertData(
                table: "TypeLivres",
                columns: new[] { "Id", "Nom", "Prix" },
                values: new object[,]
                {
                    { "Papier Excel 30", "Papier", 15.0 },
                    { "Papier Excel 31", "Papier", 16.0 },
                    { "Papier Excel 32", "Papier", 21.0 },
                    { "Papier Excel 33", "Papier", 22.0 },
                    { "Papier Excel 34", "Papier", 19.5 },
                    { "Papier Excel 35", "Papier", 24.0 },
                    { "Papier Excel 36", "Papier", 32.0 },
                    { "Papier Excel 37", "Papier", 36.0 },
                    { "Papier Excel 38", "Papier", 28.0 },
                    { "Papier Excel 39", "Papier", 29.0 },
                    { "Papier Excel 4", "Papier", 29.0 },
                    { "Papier Excel 40", "Papier", 18.0 },
                    { "Papier Excel 42", "Papier", 64.0 },
                    { "Papier Excel 43", "Papier", 21.0 },
                    { "Papier Excel 44", "Papier", 50.0 },
                    { "Papier Excel 45", "Papier", 36.0 },
                    { "Papier Excel 46", "Papier", 25.0 },
                    { "Papier Excel 48", "Papier", 28.0 },
                    { "Papier Excel 49", "Papier", 26.0 },
                    { "Papier Excel 5", "Papier", 19.5 },
                    { "Papier Excel 50", "Papier", 24.0 },
                    { "Papier Excel 51", "Papier", 32.0 },
                    { "Papier Excel 52", "Papier", 31.0 },
                    { "Papier Excel 6", "Papier", 18.75 },
                    { "Papier Excel 7", "Papier", 15.0 },
                    { "Papier Excel 8", "Papier", 21.25 },
                    { "Papier Excel 9", "Papier", 9.75 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom", "ParentId" },
                values: new object[] { "Sous-Catégorie Excel 43-1", "", "Famille", "Excel 43" });

            migrationBuilder.CreateIndex(
                name: "IX_Livres_LangueId",
                table: "Livres",
                column: "LangueId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdressePrincipaleId",
                table: "AspNetUsers",
                column: "AdressePrincipaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_ApplicationUserId",
                table: "Adresses",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LivreAuteurs_AuteurId",
                table: "LivreAuteurs",
                column: "AuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_LivreCategories_CategorieId",
                table: "LivreCategories",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_AspNetUsers_ApplicationUserId",
                table: "Adresses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Adresses_AdressePrincipaleId",
                table: "AspNetUsers",
                column: "AdressePrincipaleId",
                principalTable: "Adresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_AspNetUsers_MembreId",
                table: "Commandes",
                column: "MembreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_AspNetUsers_MembreId",
                table: "Evaluations",
                column: "MembreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favoris_AspNetUsers_MembreId",
                table: "Favoris",
                column: "MembreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_Langues_LangueId",
                table: "Livres",
                column: "LangueId",
                principalTable: "Langues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_MembreId",
                table: "Reservations",
                column: "MembreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_AspNetUsers_ApplicationUserId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Adresses_AdressePrincipaleId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_AspNetUsers_MembreId",
                table: "Commandes");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_AspNetUsers_MembreId",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Favoris_AspNetUsers_MembreId",
                table: "Favoris");

            migrationBuilder.DropForeignKey(
                name: "FK_Livres_Langues_LangueId",
                table: "Livres");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_MembreId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "LivreAuteurs");

            migrationBuilder.DropTable(
                name: "LivreCategories");

            migrationBuilder.DropIndex(
                name: "IX_Livres_LangueId",
                table: "Livres");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AdressePrincipaleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_ApplicationUserId",
                table: "Adresses");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 1");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 10");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 11");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 12");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 13");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 14");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 15");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 16");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 17");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 18");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 19");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 2");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 20");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 22");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 23");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 24");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 25");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 26");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 27");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 28");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 3");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 31");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 32");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 33");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 34");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 35");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 36");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 37");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 38");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 39");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 4");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 40");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 42");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 43");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 44");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 45");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 46");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 48");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 49");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 5");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 50");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 51");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 52");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 6");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 7");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 8");

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: "Excel 9");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Excel 34");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Excel 42");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Excel 48");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 11-1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 12-1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 13-1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 13-2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 15-1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 20-1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 21-1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 21-2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 22-1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 23-1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 31-1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 7-1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 9-1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie 9-2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Sous-Catégorie Excel 43-1");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 1");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 10");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 11");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 12");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 13");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 14");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 15");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 16");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 17");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 18");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 19");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 2");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 20");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 21");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 22");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 23");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 24");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 25");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 26");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 27");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 28");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 29");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 3");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 30");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 31");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 32");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 33");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 34");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 35");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 36");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 37");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 38");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 39");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 4");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 40");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 42");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 43");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 44");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 45");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 46");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 48");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 49");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 5");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 50");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 51");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 52");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 6");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 7");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 8");

            migrationBuilder.DeleteData(
                table: "MaisonEditions",
                keyColumn: "Id",
                keyValue: "Excel 9");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 10");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 12");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 13");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 15");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 16");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 2");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 22");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 23");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 24");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 25");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 29");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 36");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 37");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 38");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 39");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 4");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 40");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 42");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 43");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 44");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 45");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Numérique Excel 46");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 1");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 10");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 11");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 12");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 13");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 14");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 15");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 16");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 17");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 18");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 19");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 2");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 20");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 21");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 22");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 23");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 24");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 25");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 26");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 27");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 28");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 29");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 3");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 30");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 31");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 32");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 33");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 34");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 35");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 36");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 37");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 38");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 39");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 4");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 40");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 42");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 43");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 44");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 45");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 46");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 48");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 49");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 5");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 50");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 51");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 52");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 6");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 7");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 8");

            migrationBuilder.DeleteData(
                table: "TypeLivres",
                keyColumn: "Id",
                keyValue: "Papier Excel 9");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Excel 43");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "TypeLivres");

            migrationBuilder.DropColumn(
                name: "CommandeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateAdhesion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NoEmploye",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NoMembre",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Adresses");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "AspNetUsers",
                newName: "AdresseLivraisonId");

            migrationBuilder.AlterColumn<string>(
                name: "LangueId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuteurId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategorieId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EvaluationId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PromotionId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeLivreId",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdressePrincipaleId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UtilisateurPrincipalId",
                table: "Adresses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UtilisateurLivraisonId",
                table: "Adresses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AuteurLivre",
                columns: table => new
                {
                    AuteurId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivresId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuteurLivre", x => new { x.AuteurId, x.LivresId });
                    table.ForeignKey(
                        name: "FK_AuteurLivre_Auteurs_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Auteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuteurLivre_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategorieLivre",
                columns: table => new
                {
                    CategoriesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivresId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieLivre", x => new { x.CategoriesId, x.LivresId });
                    table.ForeignKey(
                        name: "FK_CategorieLivre_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieLivre_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NoEmploye = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employes_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LangueLivre",
                columns: table => new
                {
                    LanguesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivresId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangueLivre", x => new { x.LanguesId, x.LivresId });
                    table.ForeignKey(
                        name: "FK_LangueLivre_Langues_LanguesId",
                        column: x => x.LanguesId,
                        principalTable: "Langues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LangueLivre_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommandeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdhesion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoMembre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membres_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "a1bdff04-dbaa-4432-8015-187baaf12932");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "147c263a-0875-498a-b161-38fb26ec870e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "22af6d31-247b-467b-9a50-79f4057db226");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "13f670cc-aca0-414b-a2d6-304867c7470d", "68d89d93-099f-43bf-a5fe-12c4452d96bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "04c0c606-5e0a-4df2-acc1-07a77a66e8bb", "1bbfe1d8-1b91-49cb-9e99-413f48280320" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e6cd738d-940e-4435-9cff-0e3859bfbf6f", "447dc6ce-45fd-4e75-9e1b-d1cc882813a2" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "15",
                column: "Nom",
                value: "Histoire - Politique");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "31",
                column: "Nom",
                value: "Sport - Loisirs");

            migrationBuilder.InsertData(
                table: "Employes",
                columns: new[] { "Id", "NoEmploye" },
                values: new object[] { "1", "007" });

            migrationBuilder.InsertData(
                table: "Membres",
                columns: new[] { "Id", "DateAdhesion", "NoMembre" },
                values: new object[] { "2", new DateTime(2023, 9, 27, 12, 4, 53, 400, DateTimeKind.Local).AddTicks(7740), "123456" });

            migrationBuilder.InsertData(
                table: "TypeLivres",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { "1", "Neuf" },
                    { "2", "Numérique" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_UtilisateurLivraisonId",
                table: "Adresses",
                column: "UtilisateurLivraisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_UtilisateurPrincipalId",
                table: "Adresses",
                column: "UtilisateurPrincipalId",
                unique: true,
                filter: "[UtilisateurPrincipalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AuteurLivre_LivresId",
                table: "AuteurLivre",
                column: "LivresId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieLivre_LivresId",
                table: "CategorieLivre",
                column: "LivresId");

            migrationBuilder.CreateIndex(
                name: "IX_LangueLivre_LivresId",
                table: "LangueLivre",
                column: "LivresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_AspNetUsers_UtilisateurLivraisonId",
                table: "Adresses",
                column: "UtilisateurLivraisonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_AspNetUsers_UtilisateurPrincipalId",
                table: "Adresses",
                column: "UtilisateurPrincipalId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Membres_MembreId",
                table: "Commandes",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Membres_MembreId",
                table: "Evaluations",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favoris_Membres_MembreId",
                table: "Favoris",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Membres_MembreId",
                table: "Reservations",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
