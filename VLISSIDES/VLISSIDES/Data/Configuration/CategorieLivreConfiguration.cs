using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class CategorieLivreConfiguration : IEntityTypeConfiguration<Categorie>
{
    public void Configure(EntityTypeBuilder<Categorie> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).ValueGeneratedOnAdd();
        builder.HasData(
            new Categorie
            {
                Id = "1",
                Nom = "Art musique et cinéma",
                Description =
                    "L'art sous toutes ses facettes : peinture, sculpture, musique, street art... Vous trouverez ici des monographies, des catalogues d'exposition, des biographies d'artistes et une multitude de beaux livres. Les livres sont classés par date " +
                    "de parution, les plus récents en tête. 1 914 livres sont proposés dans cette catégorie."
            },
            new Categorie
            {
                Id = "2",
                Nom = "Bandes dessinées",
                Description =
                    " Dans cette catégorie : Bandes dessinées, comics, romans graphiques et mangas. Choisissez une sous-catégorie (BD ou manga) pour affiner la sélection. " +
                    "Les livres sont classés par date de parution, les plus récents en tête. "
            },
            new Categorie
            {
                Id = "3",
                Nom = "Cuisine",
                Description =
                    "Les livres de cuisine ont le vent en poupe, malgré la disponibilité de multiples recettes sur internet. Dans cette catégorie, vous trouverez des ouvrages généralistes ou thématiques, pour ceux qui doivent suivre un régime par exemple ou qui, simplement," +
                    " font attention à leur alimentation. "
            },
            new Categorie
            {
                Id = "4",
                Nom = "Développement personnel",
                Description = "Dans cette catégorie : tous les ouvrages qui peuvent " +
                              "aider à mieux vivre. Les livres sont classés par date de parution, les plus récents en tête."
            },
            new Categorie
            {
                Id = "5",
                Nom = "Dictionnaires & langues",
                Description =
                    "Dans cette catégorie : tous les dictionnaires pour tous les niveaux et tous les âges, mais aussi les méthodes d'apprentissage des langues." +
                    " Les livres sont classés par date de parution, les plus récents en tête."
            },
            new Categorie
            {
                Id = "6",
                Nom = "Droit & économie",
                Description = "Les livres sont classés par date de parution, les plus récents en tête."
            },
            new Categorie
            {
                Id = "7",
                Nom = "Essais et documents",
                Description =
                    "La production de livres ne se limite pas à la littérature. Vous trouverez dans cette catégories des essais " +
                    "ou documents, politiques ou non. Les livres sont classés par date de parution, les plus récents en tête."
            },
            new Categorie
            {
                Id = "8",
                Nom = "Guides pratiques",
                Description =
                    "Dans cette catégorie : tous les guides pratiques pour vous aider dans la vie quotidienne. Les livres sont classés par date de parution, les plus récents en tête."
            },
            new Categorie
            {
                Id = "9",
                Nom = "Histoire",
                Description =
                    "L'histoire permet de comprendre le présent. Vous trouverez ici tout ce qui a trait à l'histoire, de l'antiquité à nos jours, en France comme dans le monde." +
                    " Les livres sont classés par date de parution, les plus récents en tête. "
            },
            new Categorie
            {
                Id = "10",
                Nom = "Humour",
                Description = "Dans cette catégorie : tous les livres qui ont un contenu humoristique." +
                              " Les livres sont classés par date de parution, les plus récents en tête."
            },
            new Categorie
            {
                Id = "11",
                Nom = "Informatique et internet",
                Description =
                    " Dans cette catégorie : tous les livres qui ont un contenu liés à internet et des nouvelles techniques de l'information." +
                    " Les livres sont classés par date de parution, les plus récents en tête."
            },
            new Categorie
            {
                Id = "12",
                Nom = "Jeunesse",
                Description =
                    "Dans cette catégorie : tous les livres pour la jeunesse, du premier âge à l'adolescence. Les publications pour la jeunesse sont abondantes." +
                    " Et c'est tant mieux. Inciter les plus jeunes à lire devrait être une priorité. "
            },
            new Categorie
            {
                Id = "13",
                Nom = "Littérature",
                Description = "Dans cette catégorie, toute la littérature, française ou étrangère." +
                              " Des classiques aux auteurs contemporains, le choix est large."
            },
            new Categorie
            {
                Id = "14",
                Nom = "Littérature sentimentale",
                Description = "Littérature sentimentale : un genre qui se renouvelle et qui a toujours ses adeptes." +
                              " Passions et liaisons contrariées, les sentiments sont ici à l'honneur."
            },
            new Categorie
            {
                Id = "15",
                Nom = "Policier, suspense, thrillers",
                Description = "Romans noirs, polars, suspense, thrillers... " +
                              "tous les livres pour faire passer des nuits blanches aux amateurs de littérature noire. "
            },
            new Categorie
            {
                Id = "16",
                Nom = "Religion et spiritualité",
                Description = "Dans cette catégorie : tous les livres qui ont un contenu religieux ou spirituel. " +
                              "Les livres sont classés par date de parution, les plus récents en tête."
            },
            new Categorie
            {
                Id = "17",
                Nom = "Sciences sociales",
                Description =
                    "Dans cette catégorie : toutes les sciences sociales : ethnologie, philopsophie, psychologie, sociologie..." +
                    " L'histoire fait l'objet d'une catégorie à part. "
            },
            new Categorie
            {
                Id = "18",
                Nom = "Sciences, techniques & médecine",
                Description =
                    "Dans cette catégorie : les ouvrages scientifiques, qu'ils soient destinés aux spécialistes ou au grand public. " +
                    "Les livres sont classés par date de parution, les plus récents en tête."
            },
            new Categorie
            {
                Id = "19",
                Nom = "Scolaire et pédagogie",
                Description =
                    "Dans cette catégorie, tous les ouvrages scolaires, de la maternelle à l'enseignement supérieur." +
                    " Les livres sont classés par date de parution, les plus récents en tête."
            },
            new Categorie
            {
                Id = "20",
                Nom = "SF, Fantasy",
                Description = "Dans cette catégorie : tous les livres de science-fiction et de fantasy. " +
                              "Les livres sont classés par date de parution, les plus récents en tête."
            },
            new Categorie
            {
                Id = "21",
                Nom = "Sports et loisirs",
                Description = "Dans cette catégorie : tous les livres qui ont un contenu lié au sport et aux loisirs." +
                              " Les livres sont classés par date de parution, les plus récents en tête."
            }, new Categorie
            {
                Id = "22",
                Nom = "Théâtre",
                Description = "Dans cette catégorie : tous les livres qui ont un contenu lié au théâtre." +
                              " Les livres sont classés par date de parution, les plus récents en tête."
            },
            new Categorie
            {
                Id = "23",
                Nom = "Tourisme et voyages",
                Description =
                    "Dans cette catégorie : tous les livres qui ont un contenu lié au tourisme et aux voyages." +
                    " Les livres sont classés par date de parution, les plus récents en tête."
            }
        );
    }
}