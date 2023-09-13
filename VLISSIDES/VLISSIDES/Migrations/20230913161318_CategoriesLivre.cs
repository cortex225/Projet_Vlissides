using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class CategoriesLivre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Membres",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "2cf86ff9-f2c9-412f-a3a0-293e52bc4b99");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "838001f3-1b5e-4636-9902-33b931579385");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a259c22a-5232-42ac-a574-c20ba0e496be");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "de894c76-4964-4488-a2da-7861205468c9", "3b6405ac-8f5a-41d3-a2ae-95e67a40bb4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e03060f8-9251-4643-ac45-50ca5f55965d", "04d95c76-472f-4061-bc74-f3d6a929f98a" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Une section dédiée à l'exploration des chefs-d'œuvre artistiques, des mouvements et des artistes qui ont marqué l'histoire.", "Art" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Engagez-vous dans des réflexions profondes et argumentatives sur des enjeux contemporains.", "Essai" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Explorez le monde naturel, de la canopée de la jungle aux profondeurs des océans.", "Faune – Flore" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Évadez-vous avec des guides de voyage et des récits d'aventuriers des quatre coins du monde.", "Géographie – Voyage" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Démystifiez le monde des affaires, la complexité économique et les arcanes du droit.", "Gestion – Économie – droit" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Conseils et astuces pour naviguer dans la vie quotidienne, du bricolage à la gestion du temps.", "Guide pratique" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "15",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Immergez-vous dans les moments clés de l'histoire et les débats politiques actuels. ", "Histoire - Politique" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "16",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Pour un moment de détente, une collection de recueils drôles et de satires.", "Humour" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "17",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Restez à la pointe de la technologie avec des guides sur les logiciels, le codage et les innovations numériques.", "Informatique" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "18",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Une riche collection de classiques et de nouvelles œuvres, pour les amateurs de belle lettre.", "Littérature" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "19",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Inspirez-vous pour votre prochaine aventure, qu'elle soit en pleine nature ou dans une métropole animée.", "Loisir, Tourisme, Nature" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Plongez dans un monde de bien-être, d'esthétique et d'équilibre pour enrichir votre quotidien.", "Art de vivre" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "20",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Des ressources pour les parents et ceux qui aspirent à le devenir, pour une vie familiale épanouie.", "Maternité – Famille" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Laissez-vous emporter par le rythme des vers, l'intensité du théâtre et la profondeur des essais.", "Poésie – Théâtre – Essais" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "omprenez mieux la complexité de l'esprit humain et les clés d'une vie saine.", "Psychologie – Santé" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "23",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Explorez les croyances spirituelles du monde entier, des textes sacrés aux mystères ésotériques.", "Religion – Ésotérisme" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "De colorées bandes dessinées aux histoires captivantes pour les plus jeunes, sans oublier une touche d'humour.", "BD, Jeunesse, Humour" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Un vaste choix de narrations graphiques, des super-héros aux récits autobiographiques.", "Bandes dessinées" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Découvrez les vies fascinantes des personnalités qui ont façonné le monde.", "Biographie" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Voyagez dans des mondes lointains avec des histoires intemporelles, des fables et des légendes.", "Conte" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Des recettes alléchantes aux guides sommeliers, découvrez les saveurs du monde.", "Cuisine – Vin" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Approfondissez votre compréhension des sociétés contemporaines et de leurs nuances culturelles.", "Culture et Société" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Des ressources pour les linguistes, les étudiants et les éternels apprenants.", "Dictionnaire – Langues – Éducation" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[,]
                {
                    { "24", "Voyagez dans des mondes parallèles, où l'imaginaire rencontre souvent la réflexion profonde.", "Roman de science-fiction et fantastique" },
                    { "25", "Des romans venus de France et d'ailleurs pour vous transporter dans de multiples univers narratifs.", "Roman français et étranger " },
                    { "26", "Plongez dans des enquêtes palpitantes, des énigmes à résoudre et des mystères à élucider.", "Roman policier" },
                    { "27", "Découvrez la richesse de la littérature québécoise, avec ses voix uniques et ses paysages envoûtants.", "Roman québécois" },
                    { "28", "Éclairez votre curiosité avec des textes scientifiques accessibles et informatifs.", "Savoir Sciences" },
                    { "29", "De la biologie à la physique, découvrez les dernières découvertes et théories.", "Sciences" },
                    { "30", "Des textes éclairants pour comprendre et explorer la diversité de la sexualité humaine.", "Sexualité" },
                    { "31", "Pour les passionnés de sport et les chercheurs d'activités, des histoires inspirantes aux guides pratiques.", "Sport - Loisirs" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "24");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "25");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "26");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "27");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "28");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "29");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "30");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "31");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "c67845d3-8ee3-4674-a131-b8f8b62a0496");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "52c06941-650c-4944-8605-f2a4a375f81f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ba9b522e-e73a-4d07-bb1b-693d1f4aaacd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "14a49074-dd8d-4aab-991f-4892481b8287", "fb529e7a-e6cf-41ca-8cca-687109816421" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "90d38bb4-d6f9-4ae8-83aa-ae6b71894fc6", "ff9a9db9-218b-44c3-936a-494c93c817ea" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdresseLivraisonId", "AdressePrincipaleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, null, "", "68efeb05-6978-437e-bb38-130f34ae6823", "membre@membre.com", true, false, null, "MEMBRE", "MEMBRE@MEMBRE.COM", "MEMBRE@MEMBRE.COM", null, null, false, "Membre", "6339cfbb-98c9-4659-ad7f-afa7beeab313", false, "membre@membre.com" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "L'art sous toutes ses facettes : peinture, sculpture, musique, street art... Vous trouverez ici des monographies, des catalogues d'exposition, des biographies d'artistes et une multitude de beaux livres. Les livres sont classés par date de parution, les plus récents en tête. 1 914 livres sont proposés dans cette catégorie.", "Art musique et cinéma" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie : tous les livres qui ont un contenu humoristique. Les livres sont classés par date de parution, les plus récents en tête.", "Humour" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "Description", "Nom" },
                values: new object[] { " Dans cette catégorie : tous les livres qui ont un contenu liés à internet et des nouvelles techniques de l'information. Les livres sont classés par date de parution, les plus récents en tête.", "Informatique et internet" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie : tous les livres pour la jeunesse, du premier âge à l'adolescence. Les publications pour la jeunesse sont abondantes. Et c'est tant mieux. Inciter les plus jeunes à lire devrait être une priorité. ", "Jeunesse" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie, toute la littérature, française ou étrangère. Des classiques aux auteurs contemporains, le choix est large.", "Littérature" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Littérature sentimentale : un genre qui se renouvelle et qui a toujours ses adeptes. Passions et liaisons contrariées, les sentiments sont ici à l'honneur.", "Littérature sentimentale" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "15",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Romans noirs, polars, suspense, thrillers... tous les livres pour faire passer des nuits blanches aux amateurs de littérature noire. ", "Policier, suspense, thrillers" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "16",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie : tous les livres qui ont un contenu religieux ou spirituel. Les livres sont classés par date de parution, les plus récents en tête.", "Religion et spiritualité" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "17",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie : toutes les sciences sociales : ethnologie, philopsophie, psychologie, sociologie... L'histoire fait l'objet d'une catégorie à part. ", "Sciences sociales" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "18",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie : les ouvrages scientifiques, qu'ils soient destinés aux spécialistes ou au grand public. Les livres sont classés par date de parution, les plus récents en tête.", "Sciences, techniques & médecine" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "19",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie, tous les ouvrages scolaires, de la maternelle à l'enseignement supérieur. Les livres sont classés par date de parution, les plus récents en tête.", "Scolaire et pédagogie" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "Description", "Nom" },
                values: new object[] { " Dans cette catégorie : Bandes dessinées, comics, romans graphiques et mangas. Choisissez une sous-catégorie (BD ou manga) pour affiner la sélection. Les livres sont classés par date de parution, les plus récents en tête. ", "Bandes dessinées" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "20",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie : tous les livres de science-fiction et de fantasy. Les livres sont classés par date de parution, les plus récents en tête.", "SF, Fantasy" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie : tous les livres qui ont un contenu lié au sport et aux loisirs. Les livres sont classés par date de parution, les plus récents en tête.", "Sports et loisirs" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie : tous les livres qui ont un contenu lié au théâtre. Les livres sont classés par date de parution, les plus récents en tête.", "Théâtre" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "23",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie : tous les livres qui ont un contenu lié au tourisme et aux voyages. Les livres sont classés par date de parution, les plus récents en tête.", "Tourisme et voyages" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Les livres de cuisine ont le vent en poupe, malgré la disponibilité de multiples recettes sur internet. Dans cette catégorie, vous trouverez des ouvrages généralistes ou thématiques, pour ceux qui doivent suivre un régime par exemple ou qui, simplement, font attention à leur alimentation. ", "Cuisine" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie : tous les ouvrages qui peuvent aider à mieux vivre. Les livres sont classés par date de parution, les plus récents en tête.", "Développement personnel" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie : tous les dictionnaires pour tous les niveaux et tous les âges, mais aussi les méthodes d'apprentissage des langues. Les livres sont classés par date de parution, les plus récents en tête.", "Dictionnaires & langues" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Les livres sont classés par date de parution, les plus récents en tête.", "Droit & économie" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "La production de livres ne se limite pas à la littérature. Vous trouverez dans cette catégories des essais ou documents, politiques ou non. Les livres sont classés par date de parution, les plus récents en tête.", "Essais et documents" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "Dans cette catégorie : tous les guides pratiques pour vous aider dans la vie quotidienne. Les livres sont classés par date de parution, les plus récents en tête.", "Guides pratiques" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "Description", "Nom" },
                values: new object[] { "L'histoire permet de comprendre le présent. Vous trouverez ici tout ce qui a trait à l'histoire, de l'antiquité à nos jours, en France comme dans le monde. Les livres sont classés par date de parution, les plus récents en tête. ", "Histoire" });

            migrationBuilder.InsertData(
                table: "Membres",
                columns: new[] { "Id", "CommandeId", "DateAdhesion", "NoMembre", "ReservationId" },
                values: new object[] { "2", null, new DateTime(2023, 9, 8, 10, 5, 8, 969, DateTimeKind.Local).AddTicks(1513), "123456", null });
        }
    }
}
