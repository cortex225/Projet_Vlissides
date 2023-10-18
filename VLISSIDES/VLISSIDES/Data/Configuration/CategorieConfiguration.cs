using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class CategorieConfiguration : IEntityTypeConfiguration<Categorie>
{
    private readonly List<Categorie> categories;

    private readonly List<Categorie> categoriesDeBase = new()
    {
        new Categorie
        {
            Id = "1",
            Nom = "Art",
            Description =
                "Une section dédiée à l'exploration des chefs-d'œuvre artistiques, des mouvements et des artistes qui ont marqué l'histoire."
        },
        new Categorie
        {
            Id = "2",
            Nom = "Art de vivre",
            Description =
                "Plongez dans un monde de bien-être, d'esthétique et d'équilibre pour enrichir votre quotidien."
        },
        new Categorie
        {
            Id = "3",
            Nom = "BD, Jeunesse, Humour",
            Description =
                "De colorées bandes dessinées aux histoires captivantes pour les plus jeunes, sans oublier une touche d'humour."
        },
        new Categorie
        {
            Id = "4",
            Nom = "Bandes dessinées",
            Description = "Un vaste choix de narrations graphiques, des super-héros aux récits autobiographiques."
        },
        new Categorie
        {
            Id = "5",
            Nom = "Biographie",
            Description = "Découvrez les vies fascinantes des personnalités qui ont façonné le monde."
        },
        new Categorie
        {
            Id = "6",
            Nom = "Conte",
            Description =
                "Voyagez dans des mondes lointains avec des histoires intemporelles, des fables et des légendes."
        },
        new Categorie
        {
            Id = "7",
            Nom = "Cuisine – Vin",
            Description =
                "Des recettes alléchantes aux guides sommeliers, découvrez les saveurs du monde."
        },
        new Categorie
        {
            Id = "8",
            Nom = "Culture et Société",
            Description =
                "Approfondissez votre compréhension des sociétés contemporaines et de leurs nuances culturelles."
        },
        new Categorie
        {
            Id = "9",
            Nom = "Dictionnaire – Langues – Éducation",
            Description =
                "Des ressources pour les linguistes, les étudiants et les éternels apprenants."
        },
        new Categorie
        {
            Id = "10",
            Nom = "Essai",
            Description =
                "Engagez-vous dans des réflexions profondes et argumentatives sur des enjeux contemporains."
        },
        new Categorie
        {
            Id = "11",
            Nom = "Faune – Flore",
            Description =
                "Explorez le monde naturel, de la canopée de la jungle aux profondeurs des océans."
        },
        new Categorie
        {
            Id = "12",
            Nom = "Géographie – Voyage",
            Description =
                "Évadez-vous avec des guides de voyage et des récits d'aventuriers des quatre coins du monde."
        },
        new Categorie
        {
            Id = "13",
            Nom = "Gestion – Économie – droit",
            Description = "Démystifiez le monde des affaires, la complexité économique et les arcanes du droit."
        },
        new Categorie
        {
            Id = "14",
            Nom = "Guide pratique",
            Description =
                "Conseils et astuces pour naviguer dans la vie quotidienne, du bricolage à la gestion du temps."
        },
        new Categorie
        {
            Id = "15",
            Nom = "Histoire - Politique",
            Description = "Immergez-vous dans les moments clés de l'histoire et les débats politiques actuels. "
        },
        new Categorie
        {
            Id = "16",
            Nom = "Humour",
            Description = "Pour un moment de détente, une collection de recueils drôles et de satires."
        },
        new Categorie
        {
            Id = "17",
            Nom = "Informatique",
            Description =
                "Restez à la pointe de la technologie avec des guides sur les logiciels, le codage et les innovations numériques."
        },
        new Categorie
        {
            Id = "18",
            Nom = "Littérature",
            Description =
                "Une riche collection de classiques et de nouvelles œuvres, pour les amateurs de belle lettre."
        },
        new Categorie
        {
            Id = "19",
            Nom = "Loisir, Tourisme, Nature",
            Description =
                "Inspirez-vous pour votre prochaine aventure, qu'elle soit en pleine nature ou dans une métropole animée."
        },
        new Categorie
        {
            Id = "20",
            Nom = "Maternité – Famille",
            Description =
                "Des ressources pour les parents et ceux qui aspirent à le devenir, pour une vie familiale épanouie."
        },
        new Categorie
        {
            Id = "21",
            Nom = "Poésie – Théâtre – Essais",
            Description =
                "Laissez-vous emporter par le rythme des vers, l'intensité du théâtre et la profondeur des essais."
        },
        new Categorie
        {
            Id = "22",
            Nom = "Psychologie – Santé",
            Description = "omprenez mieux la complexité de l'esprit humain et les clés d'une vie saine."
        },
        new Categorie
        {
            Id = "23",
            Nom = "Religion – Ésotérisme",
            Description =
                "Explorez les croyances spirituelles du monde entier, des textes sacrés aux mystères ésotériques."
        },
        new Categorie
        {
            Id = "24",
            Nom = "Roman de science-fiction et fantastique",
            Description =
                "Voyagez dans des mondes parallèles, où l'imaginaire rencontre souvent la réflexion profonde."
        },
        new Categorie
        {
            Id = "25",
            Nom = "Roman français et étranger ",
            Description =
                "Des romans venus de France et d'ailleurs pour vous transporter dans de multiples univers narratifs."
        },
        new Categorie
        {
            Id = "26",
            Nom = "Roman policier",
            Description =
                "Plongez dans des enquêtes palpitantes, des énigmes à résoudre et des mystères à élucider."
        },
        new Categorie
        {
            Id = "27",
            Nom = "Roman québécois",
            Description =
                "Découvrez la richesse de la littérature québécoise, avec ses voix uniques et ses paysages envoûtants."
        },
        new Categorie
        {
            Id = "28",
            Nom = "Savoir Sciences",
            Description = "Éclairez votre curiosité avec des textes scientifiques accessibles et informatifs."
        },
        new Categorie
        {
            Id = "29",
            Nom = "Sciences",
            Description = "De la biologie à la physique, découvrez les dernières découvertes et théories."
        },
        new Categorie
        {
            Id = "30",
            Nom = "Sexualité",
            Description = "Des textes éclairants pour comprendre et explorer la diversité de la sexualité humaine."
        },
        new Categorie
        {
            Id = "31",
            Nom = "Sport - Loisirs",
            Description =
                "Pour les passionnés de sport et les chercheurs d'activités, des histoires inspirantes aux guides pratiques."
        }
    };

    // public CategorieConfiguration(List<List<Categorie>> listCategories, out List<IEnumerable<string>> listIdfinal)
    // {
    //     this.categories = new List<Categorie>();
    //     listIdfinal = new List<IEnumerable<string>>();
    //     foreach (var categories in listCategories)
    //     foreach (var categorie in categories)
    //         if (!this.categories.Any(c => c.Nom.Equals(categorie.Nom)))
    //             this.categories.Add(categorie);
    //     foreach (var categorie in categoriesDeBase)
    //         if (this.categories.Any(c => categorie.Nom.Equals(c.Nom)))
    //             this.categories.Remove(this.categories.Find(c => c.Nom.Equals(categorie.Nom)));
    //     this.categories.AddRange(categoriesDeBase);
    //     List<Categorie> sousCategorie = new();
    //     foreach (var categorie in this.categories)
    //     {
    //         for (var souscategorieId = 1; souscategorieId < categorie.Nom.Split(" – ").Length; souscategorieId++)
    //             sousCategorie.Add(new Categorie
    //             {
    //                 Id = "Sous-Catégorie " + categorie.Id + "-" + souscategorieId,
    //                 Nom = categorie.Nom.Split(" – ").ToList()[souscategorieId],
    //                 Description = "",
    //                 ParentId = categorie.Id
    //             });
    //         for (var souscategorieId = 1; souscategorieId < categorie.Nom.Split(" - ").Length; souscategorieId++)
    //             sousCategorie.Add(new Categorie
    //             {
    //                 Id = "Sous-Catégorie " + categorie.Id + "-" + souscategorieId,
    //                 Nom = categorie.Nom.Split(" - ").ToList()[souscategorieId],
    //                 Description = "",
    //                 ParentId = categorie.Id
    //             });
    //         categorie.Nom = categorie.Nom.Split(" - ")[0];
    //     }
    //
    //     this.categories.AddRange(sousCategorie);
    //     foreach (var categories in listCategories)
    //         listIdfinal.Add(categories.Select(c => c.Id = this.categories.First(thisC => thisC.Nom.Equals(c.Nom)).Id));
    //     //foreach (var categorie in this.categories)
    //     //    Console.WriteLine(categorie.Id + " : " + categorie.Nom);
    // }

    public void Configure(EntityTypeBuilder<Categorie> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).ValueGeneratedOnAdd();
        builder.HasData(categoriesDeBase);
    }
}