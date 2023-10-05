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
                value: "06a234f5-841f-4300-abf9-2011d5b4870c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "02855473-5bda-49fc-97fc-22bcaf704fdf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b64fcabb-b5aa-4f1e-89fb-2418ff364d31");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0", 0, null, "a768e422-2fd9-4dfb-9ad1-19c12cbeb2c5", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Admin", "ebef9099-b466-42cc-b241-3502694bc89d", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NoEmploye", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "", "bd735ca2-3a53-4113-bfe2-e6a4b1eab5f0", "Employe", "employe@employe.com", true, false, null, "007", "EMPLOYE", "EMPLOYE@EMPLOYE.COM", "EMPLOYE@EMPLOYE.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Employe", "4b1ffda0-fc32-4921-b66e-85912fdac203", false, "employe@employe.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "CommandeId", "ConcurrencyStamp", "DateAdhesion", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NoMembre", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "ReservationId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "", null, "17b2c8ff-06a3-4197-abb1-04d27f4f20cb", new DateTime(2023, 10, 5, 9, 31, 34, 578, DateTimeKind.Local).AddTicks(5541), "Membre", "membre@membre.com", true, false, null, "123456", "MEMBRE", "MEMBRE@MEMBRE.COM", "MEMBRE@MEMBRE.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Membre", null, "c8604b80-dfd2-4724-b325-9e55cfa2e59f", false, "membre@membre.com" });

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

            migrationBuilder.InsertData(
                table: "Livres",
                columns: new[] { "Id", "CommandeId", "Couverture", "DateAjout", "DatePublication", "ISBN", "LangueId", "MaisonEditionId", "NbExemplaires", "NbPages", "Resume", "Titre" },
                values: new object[,]
                {
                    { "Excel 1", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4791), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001193", null, "Excel 1", 24, 96, "", "\"Le Petit Prince\"" },
                    { "Excel 10", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4886), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001202", null, "Excel 10", 32, 464, "", "\"La Nuit des temps\"" },
                    { "Excel 11", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4890), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001203", null, "Excel 11", 2, 256, "", "\"Le Guépard\"" },
                    { "Excel 12", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4988), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001204", null, "Excel 12", 13, 540, "", "\"Les Fourmis\"" },
                    { "Excel 13", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4992), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540102", null, "Excel 13", 62, 720, "", "\"Moby-Dick\"" },
                    { "Excel 14", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4996), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540103", null, "Excel 14", 2, 704, "", "\"Crime et Châtiment\"" },
                    { "Excel 15", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5001), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540104", null, "Excel 15", 2, 480, "", "\"Le Maître et Marguerite\"" },
                    { "Excel 16", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5005), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540105", null, "Excel 16", 14, 255, "", "\"Le Parfum\"" },
                    { "Excel 17", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5010), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540106", null, "Excel 17", 15, 288, "", "\"Le Lion\"" },
                    { "Excel 18", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5016), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540107", null, "Excel 18", 34, 123, "", "\"L'Étranger\"" },
                    { "Excel 19", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5022), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540108", null, "Excel 19", 6, 880, "", "\"Le Chardonneret\"" },
                    { "Excel 2", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4845), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001194", null, "Excel 2", 325, 320, "", "\"Harry Potter à l'école des sorciers\"" },
                    { "Excel 20", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5026), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540109", null, "Excel 20", 2, 384, "", "\"Le Journal d'Anne Frank\"" },
                    { "Excel 21", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5031), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540110", null, "Excel 21", 40, 144, "", "\"La Ferme des Animaux\"" },
                    { "Excel 22", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5035), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540111", null, "Excel 22", 31, 416, "", "\"L'Odyssée\"" },
                    { "Excel 23", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5041), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540112", null, "Excel 23", 20, 128, "", "\"Le Vieil Homme et la Mer\"" },
                    { "Excel 24", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5049), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540113", null, "Excel 24", 21, 320, "", "\"Le Journal de Bridget Jones\"" },
                    { "Excel 25", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5054), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540114", null, "Excel 25", 1, 416, "", "\"Le Meilleur des Mondes\"" },
                    { "Excel 26", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5059), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540115", null, "Excel 26", 15, 192, "", "\"L'Alchimiste\"" },
                    { "Excel 27", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5065), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540116", null, "Excel 27", 4, 384, "", "\"Le Portrait de Dorian Gray\"" },
                    { "Excel 28", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5069), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540118", null, "Excel 28", 6, 1312, "", "\"Le Comte de Monte-Cristo\"" },
                    { "Excel 29", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5074), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540119", null, "Excel 29", 20, 320, "", "\"Le Hobbit\"" },
                    { "Excel 3", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4852), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001195", null, "Excel 3", 3, 328, "", "\"1984\"" },
                    { "Excel 30", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5079), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540120", null, "Excel 30", 21, 704, "", "\"Les Trois Mousquetaires\"" },
                    { "Excel 31", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5084), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540121", null, "Excel 31", 2, 368, "", "\"Les Cerfs-volants de Kaboul\"" },
                    { "Excel 32", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5089), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540122", null, "Excel 32", 0, 224, "", "\"Le Grand Meaulnes\"" },
                    { "Excel 33", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5094), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540123", null, "Excel 33", 10, 304, "", "\"Le Journal de Kurt Cobain\"" },
                    { "Excel 34", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5101), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "978-2253004229", null, "Excel 34", 0, 288, "", "\"Les Fleurs du Mal\"" },
                    { "Excel 35", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5105), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "978-2070367980", null, "Excel 35", 30, 128, "", "\"Le Parti pris des choses\"" },
                    { "Excel 36", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5110), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140586", null, "Excel 36", 2, 288, "", "Les Contes de Grimm" },
                    { "Excel 37", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5116), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140589", null, "Excel 37", 12, 192, "", "Contes de Perrault" },
                    { "Excel 38", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5121), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140590", null, "Excel 38", 13, 384, "", "Les Contes d'Andersen" },
                    { "Excel 39", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5125), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140591", null, "Excel 39", 50, 832, "", "Contes des Mille et Une Nuits" },
                    { "Excel 4", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4856), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001196", null, "Excel 4", 60, 576, "", "\"Le Seigneur des Anneaux : La Communauté de l'Anneau\"" },
                    { "Excel 40", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5134), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140592", null, "Excel 40", 21, 160, "", "Contes de la Rue Broca" },
                    { "Excel 42", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5140), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140594", null, "Excel 42", 3, 400, "", "\"Pédagogie positive\"" },
                    { "Excel 43", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5145), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140595", null, "Excel 43", 23, 160, "", "\"L'École du Colibri\"" },
                    { "Excel 44", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5151), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140596", null, "Excel 44", 2, 288, "", "\"Apprendre autrement avec la pédagogie positive\"" },
                    { "Excel 45", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5156), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140597", null, "Excel 45", 150, 320, "", "\"Le guide de survie enseignant suppléant\"" },
                    { "Excel 46", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5161), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140598", null, "Excel 46", 3, 192, "", "\"La pédagogie Montessori à la maison\"" },
                    { "Excel 48", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5167), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782012101320", null, "Excel 48", 20, 48, "", "\"Astérix le Gaulois\"" }
                });

            migrationBuilder.InsertData(
                table: "Livres",
                columns: new[] { "Id", "CommandeId", "Couverture", "DateAjout", "DatePublication", "ISBN", "LangueId", "MaisonEditionId", "NbExemplaires", "NbPages", "Resume", "Titre" },
                values: new object[,]
                {
                    { "Excel 49", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5173), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001193", null, "Excel 49", 12, 62, "", "\"Tintin au Tibet\"" },
                    { "Excel 5", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4860), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001197", null, "Excel 5", 3, 592, "", "\"Le Nom de la Rose\"" },
                    { "Excel 50", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5178), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540102", null, "Excel 50", 2, 296, "", "\"Maus\"" },
                    { "Excel 51", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5206), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140587", null, "Excel 51", 6, 352, "", "\"Persepolis\"" },
                    { "Excel 52", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(5211), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "978-2-8094-3960-2", null, "Excel 52", 8, 416, "", "\"Watchmen\"" },
                    { "Excel 6", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4867), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001198", null, "Excel 6", 5, 384, "", "\"Orgueil et Préjugés\"" },
                    { "Excel 7", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4871), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001199", null, "Excel 7", 10, 316, "", "\"L'Écume des Jours\"" },
                    { "Excel 8", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4876), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001200", null, "Excel 8", 12, 1232, "", "\"Les Misérables\"" },
                    { "Excel 9", null, "", new DateTime(2023, 10, 5, 9, 31, 34, 572, DateTimeKind.Local).AddTicks(4880), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001201", null, "Excel 9", 1, 576, "", "\"Le Rouge et le Noir\"" }
                });

            migrationBuilder.InsertData(
                table: "LivreAuteurs",
                columns: new[] { "AuteurId", "LivreId" },
                values: new object[,]
                {
                    { "Excel 1", "Excel 1" },
                    { "Excel 10", "Excel 10" },
                    { "Excel 11", "Excel 11" },
                    { "Excel 12", "Excel 12" },
                    { "Excel 13", "Excel 13" },
                    { "Excel 14", "Excel 14" },
                    { "Excel 15", "Excel 15" },
                    { "Excel 16", "Excel 16" },
                    { "Excel 17", "Excel 17" },
                    { "Excel 18", "Excel 18" },
                    { "Excel 19", "Excel 19" },
                    { "Excel 2", "Excel 2" },
                    { "Excel 20", "Excel 20" },
                    { "Excel 3", "Excel 21" },
                    { "Excel 22", "Excel 22" },
                    { "Excel 23", "Excel 23" },
                    { "Excel 24", "Excel 24" },
                    { "Excel 25", "Excel 25" },
                    { "Excel 26", "Excel 26" },
                    { "Excel 27", "Excel 27" },
                    { "Excel 28", "Excel 28" },
                    { "Excel 4", "Excel 29" },
                    { "Excel 3", "Excel 3" },
                    { "Excel 28", "Excel 30" },
                    { "Excel 31", "Excel 31" },
                    { "Excel 32", "Excel 32" },
                    { "Excel 33", "Excel 33" },
                    { "Excel 34", "Excel 34" },
                    { "Excel 35", "Excel 35" },
                    { "Excel 36", "Excel 36" },
                    { "Excel 37", "Excel 37" },
                    { "Excel 38", "Excel 38" },
                    { "Excel 39", "Excel 39" },
                    { "Excel 4", "Excel 4" },
                    { "Excel 40", "Excel 40" },
                    { "Excel 42", "Excel 42" },
                    { "Excel 43", "Excel 43" },
                    { "Excel 44", "Excel 44" },
                    { "Excel 45", "Excel 45" },
                    { "Excel 46", "Excel 46" },
                    { "Excel 48", "Excel 48" },
                    { "Excel 49", "Excel 49" }
                });

            migrationBuilder.InsertData(
                table: "LivreAuteurs",
                columns: new[] { "AuteurId", "LivreId" },
                values: new object[,]
                {
                    { "Excel 5", "Excel 5" },
                    { "Excel 50", "Excel 50" },
                    { "Excel 51", "Excel 51" },
                    { "Excel 52", "Excel 52" },
                    { "Excel 6", "Excel 6" },
                    { "Excel 7", "Excel 7" },
                    { "Excel 8", "Excel 8" },
                    { "Excel 9", "Excel 9" }
                });

            migrationBuilder.InsertData(
                table: "LivreCategories",
                columns: new[] { "CategorieId", "LivreId" },
                values: new object[,]
                {
                    { "18", "Excel 1" },
                    { "18", "Excel 10" },
                    { "18", "Excel 11" },
                    { "18", "Excel 12" },
                    { "18", "Excel 13" },
                    { "18", "Excel 14" },
                    { "18", "Excel 15" },
                    { "18", "Excel 16" },
                    { "18", "Excel 17" },
                    { "18", "Excel 18" },
                    { "18", "Excel 19" },
                    { "18", "Excel 2" },
                    { "18", "Excel 20" },
                    { "18", "Excel 21" },
                    { "18", "Excel 22" },
                    { "18", "Excel 23" },
                    { "18", "Excel 24" },
                    { "18", "Excel 25" },
                    { "18", "Excel 26" },
                    { "18", "Excel 27" },
                    { "18", "Excel 28" },
                    { "18", "Excel 29" },
                    { "18", "Excel 3" },
                    { "18", "Excel 30" },
                    { "18", "Excel 31" },
                    { "18", "Excel 32" },
                    { "5", "Excel 33" },
                    { "Excel 34", "Excel 34" },
                    { "Excel 34", "Excel 35" },
                    { "6", "Excel 36" },
                    { "6", "Excel 37" },
                    { "6", "Excel 38" },
                    { "6", "Excel 39" },
                    { "18", "Excel 4" }
                });

            migrationBuilder.InsertData(
                table: "LivreCategories",
                columns: new[] { "CategorieId", "LivreId" },
                values: new object[,]
                {
                    { "6", "Excel 40" },
                    { "Excel 42", "Excel 42" },
                    { "Excel 43", "Excel 43" },
                    { "Excel 42", "Excel 44" },
                    { "Excel 42", "Excel 45" },
                    { "Excel 42", "Excel 46" },
                    { "Excel 48", "Excel 48" },
                    { "Excel 48", "Excel 49" },
                    { "18", "Excel 5" },
                    { "Excel 48", "Excel 50" },
                    { "Excel 48", "Excel 51" },
                    { "Excel 48", "Excel 52" },
                    { "18", "Excel 6" },
                    { "18", "Excel 7" },
                    { "18", "Excel 8" },
                    { "18", "Excel 9" }
                });

            migrationBuilder.InsertData(
                table: "LivreTypeLivres",
                columns: new[] { "LivreId", "TypeLivreId", "Prix" },
                values: new object[,]
                {
                    { "Excel 1", "Papier Excel 1", 0m },
                    { "Excel 10", "Numérique Excel 10", 0m },
                    { "Excel 10", "Papier Excel 10", 0m },
                    { "Excel 11", "Papier Excel 11", 0m },
                    { "Excel 12", "Numérique Excel 12", 0m },
                    { "Excel 12", "Papier Excel 12", 0m },
                    { "Excel 13", "Numérique Excel 13", 0m },
                    { "Excel 13", "Papier Excel 13", 0m },
                    { "Excel 14", "Papier Excel 14", 0m },
                    { "Excel 15", "Numérique Excel 15", 0m },
                    { "Excel 15", "Papier Excel 15", 0m },
                    { "Excel 16", "Numérique Excel 16", 0m },
                    { "Excel 16", "Papier Excel 16", 0m },
                    { "Excel 17", "Papier Excel 17", 0m },
                    { "Excel 18", "Papier Excel 18", 0m },
                    { "Excel 19", "Papier Excel 19", 0m },
                    { "Excel 2", "Numérique Excel 2", 0m },
                    { "Excel 2", "Papier Excel 2", 0m },
                    { "Excel 20", "Papier Excel 20", 0m },
                    { "Excel 21", "Papier Excel 21", 0m },
                    { "Excel 22", "Numérique Excel 22", 0m },
                    { "Excel 22", "Papier Excel 22", 0m },
                    { "Excel 23", "Numérique Excel 23", 0m },
                    { "Excel 23", "Papier Excel 23", 0m },
                    { "Excel 24", "Numérique Excel 24", 0m },
                    { "Excel 24", "Papier Excel 24", 0m }
                });

            migrationBuilder.InsertData(
                table: "LivreTypeLivres",
                columns: new[] { "LivreId", "TypeLivreId", "Prix" },
                values: new object[,]
                {
                    { "Excel 25", "Numérique Excel 25", 0m },
                    { "Excel 25", "Papier Excel 25", 0m },
                    { "Excel 26", "Papier Excel 26", 0m },
                    { "Excel 27", "Papier Excel 27", 0m },
                    { "Excel 28", "Papier Excel 28", 0m },
                    { "Excel 29", "Numérique Excel 29", 0m },
                    { "Excel 29", "Papier Excel 29", 0m },
                    { "Excel 3", "Papier Excel 3", 0m },
                    { "Excel 30", "Papier Excel 30", 0m },
                    { "Excel 31", "Papier Excel 31", 0m },
                    { "Excel 32", "Papier Excel 32", 0m },
                    { "Excel 33", "Papier Excel 33", 0m },
                    { "Excel 34", "Papier Excel 34", 0m },
                    { "Excel 35", "Papier Excel 35", 0m },
                    { "Excel 36", "Numérique Excel 36", 0m },
                    { "Excel 36", "Papier Excel 36", 0m },
                    { "Excel 37", "Numérique Excel 37", 0m },
                    { "Excel 37", "Papier Excel 37", 0m },
                    { "Excel 38", "Numérique Excel 38", 0m },
                    { "Excel 38", "Papier Excel 38", 0m },
                    { "Excel 39", "Numérique Excel 39", 0m },
                    { "Excel 39", "Papier Excel 39", 0m },
                    { "Excel 4", "Numérique Excel 4", 0m },
                    { "Excel 4", "Papier Excel 4", 0m },
                    { "Excel 40", "Numérique Excel 40", 0m },
                    { "Excel 40", "Papier Excel 40", 0m },
                    { "Excel 42", "Numérique Excel 42", 0m },
                    { "Excel 42", "Papier Excel 42", 0m },
                    { "Excel 43", "Numérique Excel 43", 0m },
                    { "Excel 43", "Papier Excel 43", 0m },
                    { "Excel 44", "Numérique Excel 44", 0m },
                    { "Excel 44", "Papier Excel 44", 0m },
                    { "Excel 45", "Numérique Excel 45", 0m },
                    { "Excel 45", "Papier Excel 45", 0m },
                    { "Excel 46", "Numérique Excel 46", 0m },
                    { "Excel 46", "Papier Excel 46", 0m },
                    { "Excel 48", "Papier Excel 48", 0m },
                    { "Excel 49", "Papier Excel 49", 0m },
                    { "Excel 5", "Papier Excel 5", 0m },
                    { "Excel 50", "Papier Excel 50", 0m },
                    { "Excel 51", "Papier Excel 51", 0m },
                    { "Excel 52", "Papier Excel 52", 0m }
                });

            migrationBuilder.InsertData(
                table: "LivreTypeLivres",
                columns: new[] { "LivreId", "TypeLivreId", "Prix" },
                values: new object[,]
                {
                    { "Excel 6", "Papier Excel 6", 0m },
                    { "Excel 7", "Papier Excel 7", 0m },
                    { "Excel 8", "Papier Excel 8", 0m },
                    { "Excel 9", "Papier Excel 9", 0m }
                });

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
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 1", "Papier Excel 1" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 10", "Numérique Excel 10" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 10", "Papier Excel 10" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 11", "Papier Excel 11" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 12", "Numérique Excel 12" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 12", "Papier Excel 12" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 13", "Numérique Excel 13" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 13", "Papier Excel 13" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 14", "Papier Excel 14" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 15", "Numérique Excel 15" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 15", "Papier Excel 15" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 16", "Numérique Excel 16" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 16", "Papier Excel 16" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 17", "Papier Excel 17" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 18", "Papier Excel 18" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 19", "Papier Excel 19" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 2", "Numérique Excel 2" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 2", "Papier Excel 2" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 20", "Papier Excel 20" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 21", "Papier Excel 21" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 22", "Numérique Excel 22" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 22", "Papier Excel 22" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 23", "Numérique Excel 23" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 23", "Papier Excel 23" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 24", "Numérique Excel 24" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 24", "Papier Excel 24" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 25", "Numérique Excel 25" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 25", "Papier Excel 25" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 26", "Papier Excel 26" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 27", "Papier Excel 27" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 28", "Papier Excel 28" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 29", "Numérique Excel 29" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 29", "Papier Excel 29" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 3", "Papier Excel 3" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 30", "Papier Excel 30" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 31", "Papier Excel 31" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 32", "Papier Excel 32" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 33", "Papier Excel 33" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 34", "Papier Excel 34" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 35", "Papier Excel 35" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 36", "Numérique Excel 36" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 36", "Papier Excel 36" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 37", "Numérique Excel 37" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 37", "Papier Excel 37" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 38", "Numérique Excel 38" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 38", "Papier Excel 38" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 39", "Numérique Excel 39" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 39", "Papier Excel 39" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 4", "Numérique Excel 4" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 4", "Papier Excel 4" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 40", "Numérique Excel 40" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 40", "Papier Excel 40" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 42", "Numérique Excel 42" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 42", "Papier Excel 42" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 43", "Numérique Excel 43" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 43", "Papier Excel 43" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 44", "Numérique Excel 44" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 44", "Papier Excel 44" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 45", "Numérique Excel 45" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 45", "Papier Excel 45" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 46", "Numérique Excel 46" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 46", "Papier Excel 46" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 48", "Papier Excel 48" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 49", "Papier Excel 49" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 5", "Papier Excel 5" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 50", "Papier Excel 50" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 51", "Papier Excel 51" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 52", "Papier Excel 52" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 6", "Papier Excel 6" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 7", "Papier Excel 7" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 8", "Papier Excel 8" });

            migrationBuilder.DeleteData(
                table: "LivreTypeLivres",
                keyColumns: new[] { "LivreId", "TypeLivreId" },
                keyValues: new object[] { "Excel 9", "Papier Excel 9" });

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
                keyValue: "Excel 43");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "Excel 48");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 1");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 10");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 11");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 12");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 13");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 14");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 15");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 16");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 17");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 18");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 19");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 2");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 20");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 21");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 22");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 23");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 24");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 25");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 26");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 27");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 28");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 29");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 3");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 30");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 31");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 32");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 33");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 34");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 35");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 36");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 37");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 38");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 39");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 4");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 40");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 42");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 43");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 44");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 45");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 46");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 48");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 49");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 5");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 50");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 51");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 52");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 6");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 7");

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 8");

            migrationBuilder.DeleteData(
                table: "Livres",
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
