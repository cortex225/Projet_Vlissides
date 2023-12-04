// See https://aka.ms/new-console-template for more information


//Signaler le debut du seeder


using ExcelDataReader;
using Seeder;
using VLISSIDES.Data;
using VLISSIDES.Models;

/**
* Ce seeder sert à créer des donnés pour tester le programme. Ce seeder crée:
*      -Auteurs
*      -Maisons d'édtions
*      -Livres
*
* Éventuellement, nous n'aurons plus besoin de ce seeder lorsqu'on aura les donnés
*/
internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Début du seed!");

        using var context = DbContextFactory.CreateDbContext();

        var seeder = new DatabaseSeeder(context);
        seeder.Seed();

        Console.WriteLine("Fin du seed!");
    }
}

public class DatabaseSeeder
{
    private readonly ApplicationDbContext _context;

    public DatabaseSeeder(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        //Listes pour choisir aléatoirement pour les livres
        var categories = _context.Categories.ToList();
        var typeLivres = _context.TypeLivres.ToList();
        var langues = _context.Langues.ToList();

        //var generator = new RandomGenerator();
        //Random rand = new Random();


        //Supprimer les donnés qui avait avant pour créer les nouvelles donnés
        // _context.Livres.RemoveRange(_context.Livres);
        // _context.SaveChanges();
        // _context.Auteurs.RemoveRange(_context.Auteurs);
        // _context.SaveChanges();
        // _context.MaisonEditions.RemoveRange(_context.MaisonEditions);
        // _context.SaveChanges();
        // _context.Categories.RemoveRange(_context.Categories);
        // _context.SaveChanges();
        // _context.MaisonEditions.RemoveRange(_context.MaisonEditions);
        // _context.SaveChanges();



        // //Générer les auteurs
        // var auteurs = Builder<Auteur>.CreateListOfSize(99)
        //     .All()
        //     .With(c => c.NomAuteur = Name.Last())
        //     .Build();
        // _context.Auteurs.AddRange(auteurs);
        // _context.SaveChanges();
        //
        // //Générer les maisons d'édition
        // var maisonsEditions = Builder<MaisonEdition>.CreateListOfSize(99)
        //     .All()
        //     .With(c => c.Nom = Company.Name())
        //     .Build();
        // _context.MaisonEditions.AddRange(maisonsEditions);
        // _context.SaveChanges();
        //
        // //Générer les livres
        // var livres = Builder<Livre>.CreateListOfSize(299)
        //     .All()
        //     .With(c => c.Titre = Company.Name())
        //     .With(c => c.Resume = Lorem.Paragraph())
        //     .With(c => c.NbExemplaires = 1)
        //     .With(c => c.DateAjout = DateTime.Now)
        //     .With(c => c.NbPages = 120)
        //     .With(c => c.DatePublication = Identification.DateOfBirth())
        //     .With(c => c.ISBN = Identification.UsPassportNumber())
        //     .With(c => c.Categories = new List<LivreCategorie>())
        //     .With(c => c.LivreAuteurs = new())
        //     .With(c => c.Couverture = "/img/Couvertures/livredefault.png")
        //     .With(c => c.MaisonEdition = Pick<MaisonEdition>.RandomItemFrom(maisonsEditions))
        //     .With(c => c.LivreTypeLivres = new List<LivreTypeLivre>
        //         { new() { TypeLivre = Pick<TypeLivre>.RandomItemFrom(typeLivres) } })
        //     .With(c => c.Langue = Pick<Langue>.RandomItemFrom(langues))
        //     .With(c => c.LivreAuteurs = new List<LivreAuteur>
        //         { new() { Auteur = Pick<Auteur>.RandomItemFrom(auteurs) } })
        //     .With(c => c.Categories = new List<LivreCategorie>
        //         { new() { Categorie = Pick<Categorie>.RandomItemFrom(categories) } })
        //     .Build();
        // _context.Livres.AddRange(livres);
        // _context.SaveChanges();
        //
        // //Générer les prix de chaque livres existant dans la base de donnés 
        // var livreTypeLivres = _context.LivreTypeLivres.ToList();
        // foreach (var livre in livres)
        // {
        //     var livreTypeLivre = livreTypeLivres.FirstOrDefault(ltl => ltl.LivreId == livre.Id);
        //     if (livreTypeLivre != null)
        //     {
        //         livreTypeLivre.Prix = rand.Next(10, 100);
        //     }
        // }
        //
        // _context.SaveChanges();

        //Signaler le début de la lecture du fichier Excel
        Console.WriteLine("************ Début de la lecture du fichier Excel!************* ");
        string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Ressources", "DonneesLivres.xlsx");
        SeedFromExcel(fileName);
        GenerateEvenements();
        GeneratePromotions();
        //Signaler la fin de la lecture du fichier Excel
        Console.WriteLine("************ Succès!************* ");



    }

    private void SeedFromExcel(string fileName)
    {
        using var stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

        using var reader = ExcelReaderFactory.CreateReader(stream);

        bool isFirstRow = true; // Un flag pour identifier la première ligne

        while (reader.Read()) // Chaque ligne représente un livre
        {
            if (isFirstRow) // Si c'est la première ligne, on l'ignore et on continue
            {
                isFirstRow = false;
                continue;
            }

            var id = Guid.NewGuid().ToString(); // Générer un ID unique pour chaque livre

            var livre = new Livre();
            var auteurs = new List<Auteur>();
            var maisonEdition = new MaisonEdition();
            var categories = new List<Categorie>();
            var typeLivres = new List<LivreTypeLivre>();

            #region Titre

            livre.Titre = reader.GetValue(0) != null ? reader.GetString(0).Trim().Trim('"').Trim() : "";

            #endregion

            #region Auteur

            if (reader.GetValue(1) != null)
                auteurs.Add(new Auteur { Id = id, NomAuteur = reader.GetString(1).Trim() });

            #endregion

            #region Edition

            if (reader.GetValue(2) != null)
            {
                string nomMaisonEdition = reader.GetString(2).Trim();

                // Chercher la maison d'édition dans la base de données
                var maisonEditionExistante = _context.MaisonEditions
                    .FirstOrDefault(me => me.Nom == nomMaisonEdition);

                if (maisonEditionExistante != null)
                {
                    // Utiliser l'ID de la maison d'édition existante
                    livre.MaisonEditionId = maisonEditionExistante.Id;
                }
                else if (!string.IsNullOrEmpty(nomMaisonEdition))
                {
                    // Créer une nouvelle maison d'édition et l'ajouter à la base de données
                    var nouvelleMaisonEdition = new MaisonEdition
                    { Id = Guid.NewGuid() + "new", Nom = nomMaisonEdition };
                    _context.MaisonEditions.Add(nouvelleMaisonEdition);

                    // Utiliser l'ID de la nouvelle maison d'édition
                    livre.MaisonEditionId = nouvelleMaisonEdition.Id;
                }
            }

            #endregion

            #region Page

            if (int.TryParse(reader.GetValue(3)?.ToString(), out int nbPages))
            {
                livre.NbPages = nbPages;
            }
            else
            {
                livre.NbPages = 0;
            }


            #endregion

            #region ISBN

            livre.ISBN = reader.GetValue(4) != null ? reader.GetValue(4).ToString().Trim() : "";

            #endregion

            #region Couverture

            string titre = reader.GetString(0).Trim().Trim('"').Trim();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Couvertures",
                titre + ".png");
            if (reader.GetValue(0) != null)
            {

                if (OperatingSystem.IsMacOS())
                {
                    if (File.Exists(path.Replace("/bin/Debug/net6.0/", "/")))
                    {
                        livre.Couverture = "/img/Couvertures/" + reader.GetString(0).Trim().Trim('"').Trim() + ".png";
                    }
                    else
                    {
                        livre.Couverture = "/img/CouvertureLivre/livredefault.png";
                    }
                }
                else if (File.Exists(path.Replace("\\bin\\Debug\\net6.0", "")))
                {
                    livre.Couverture = "/img/Couvertures/" + reader.GetString(0).Trim().Trim('"').Trim() + ".png";
                }
                else
                {
                    livre.Couverture = "/img/CouvertureLivre/livredefault.png";
                }
            }


            #endregion

            #region Catégorie

            if (reader.GetValue(6) != null)
            {
                string categoryName = reader.GetString(6).Trim();

                // Ici je vérifie si la catégorie existe déjà dans la base de données
                var existingCategory = _context.Categories
                    .FirstOrDefault(c => c.Nom == categoryName);

                if (existingCategory == null) // Si la catégorie n'existe pas, créez une nouvelle catégorie
                {
                    existingCategory = new Categorie
                    { Id = Guid.NewGuid() + "new", Nom = categoryName, Description = "" };
                    _context.Categories
                        .Add(existingCategory); // Ici j'ajoute la nouvelle catégorie à la base de données
                }

                categories.Add(
                    existingCategory); // Ici j'ajoute la catégorie (existante ou nouvelle) à la liste de catégories

            }

            #endregion

            #region Quantité

            if (int.TryParse(reader.GetValue(9)?.ToString(), out int nbExemplaires))
            {
                livre.NbExemplaires = nbExemplaires;
            }
            else
            {
                livre.NbExemplaires = 0;
            }

            #endregion

            #region Papier

            if (reader.GetValue(7) != null)
            {
                if (decimal.TryParse(reader.GetValue(8)?.ToString(), out decimal prix))
                {
                    typeLivres.Add(new LivreTypeLivre
                    {
                        LivreId = id,
                        TypeLivreId = "1",
                        Prix = prix,

                    });
                }
                else
                {
                    typeLivres.Add(new LivreTypeLivre
                    {
                        LivreId = id,
                        TypeLivreId = "1",
                        Prix = 0,
                    });
                }


            }



            #endregion

            #region Numérique

            if (reader.GetValue(10) != null)
            {
                if (decimal.TryParse(reader.GetValue(11)?.ToString(), out decimal prix))
                {
                    typeLivres.Add(new LivreTypeLivre
                    {
                        LivreId = id,
                        TypeLivreId = "2",
                        Prix = prix,
                    });
                }
                else
                {
                    typeLivres.Add(new LivreTypeLivre
                    {
                        LivreId = id,
                        TypeLivreId = "2",
                        Prix = 0,
                    });
                }


            }

            #endregion

            livre.Resume =
                "bibendum ut tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce ut placerat orci nulla pellentesque dignissim enim sit";
            livre.DateAjout = DateTime.Now;
            livre.DatePublication = DateTime.Now;
            livre.LangueId = "1";


            // Ajouter les objets créés à la base de données
            _context.Auteurs.AddRange(auteurs);
            _context.Livres.Add(livre);
            _context.SaveChanges(); // Sauvegarder les changements

            //Ici j'ajoute les catégories au livres
            foreach (var typeLivre in typeLivres)
            {
                typeLivre.LivreId = livre.Id;
                _context.LivreTypeLivres.Add(typeLivre);
            }

            //Assigner un ou plusieurs auteurs à un livre
            var livreAuteurs = new List<LivreAuteur>();
            foreach (var auteur in auteurs)
            {
                livreAuteurs.Add(new LivreAuteur
                {
                    LivreId = livre.Id,
                    AuteurId = auteur.Id
                });
            }

            _context.Livres.Find(livre.Id).LivreAuteurs = livreAuteurs;


            // Obtenez les livres et les catégories de la base de données
            var livres = _context.Livres.ToList();

            var NouvelleAssociation = from book in livres
                                      from category in categories
                                      where !_context.LivreCategories.Any(lc => lc.LivreId == book.Id && lc.CategorieId == category.Id)
                                      select new LivreCategorie { LivreId = book.Id, CategorieId = category.Id };

            _context.LivreCategories.AddRange(NouvelleAssociation); _context.SaveChanges();
        }

    }

    private void GenerateEvenements()
    {
        _context.Evenements.Add(new Evenement()
        {
            Id = Guid.NewGuid().ToString(),
            Image = "/img/images_Events/pinocio.png",
            Nom = "Projet Pinochio (5 ans et plus)",
            Description = "Matières chorégraphiques d’exception, ces métamorphoses fantastiques permettent d’évoquer les tourments du corps, les revirements de l’âme," +
            " les changements auxquels nous sommes toutes et tous confrontés. La chorégraphe déconstruit le récit pour en extraire sa subtile essence.",
            Prix = 0,
            NbPlaces = 20,
            NbPlacesMembre = 20,
            DateDebut = new DateTime(2024, 9, 7, 14, 0, 0),
            DateFin = new DateTime(2024, 9, 7, 16, 30, 0),
            Lieu = "À déterminer"

        });
        _context.Evenements.Add(new Evenement()
        {
            Id = Guid.NewGuid().ToString(),
            Image = "/img/images_Events/reve.png",
            Nom = "Rêves à colorier",
            Description = "Aventure musicale haute-voltige qui allie la chanson, le théâtre d’objets et la littérature.",
            Prix = 8,
            NbPlaces = 25,
            NbPlacesMembre = 15,
            DateDebut = new DateTime(2024, 11, 26, 15, 0, 0),
            DateFin = new DateTime(2024, 11, 26, 15, 55, 0),
            Lieu = "À déterminer"
        });
        _context.Evenements.Add(new Evenement()
        {
            Id = Guid.NewGuid().ToString(),
            Image = "/img/images_Events/Heli.png",
            Nom = "Héli, l’enfant cerf-volant",
            Description = "À l’ère du numérique et des fausses nouvelles, ce spectacle foisonnant interroge notre rapport à la mémoire et braque les projecteurs sur les limites parfois floues entre la fiction et la réalité. Atelier d’écriture pour les 12-16 ans",

            Prix = 0,
            NbPlaces = 25,
            NbPlacesMembre = 25,
            DateDebut = new DateTime(2024, 3, 7, 15, 0, 0),
            DateFin = new DateTime(2024, 3, 7, 15, 55, 0),
            Lieu = "À déterminer"
        });
        _context.Evenements.Add(new Evenement()
        {
            Id = Guid.NewGuid().ToString(),
            Image = "/img/images_Events/michel.png",
            Nom = "Conversation avec Michel Tremblay",
            Description = "",

            Prix = 25,
            NbPlaces = 50,
            NbPlacesMembre = 35,
            DateDebut = new DateTime(2024, 2, 14, 20, 0, 0),
            DateFin = new DateTime(2024, 2, 14, 20, 55, 0),
            Lieu = "À déterminer"
        });
        _context.Evenements.Add(new Evenement()
        {
            Id = Guid.NewGuid().ToString(),
            Image = "/img/images_Events/simon.png",
            Nom = "Conversation avec Simon Boulerice",
            Description = "",

            Prix = 15,
            NbPlaces = 50,
            NbPlacesMembre = 10,
            DateDebut = new DateTime(2023, 12, 15, 19, 0, 0),
            DateFin = new DateTime(2023, 12, 15, 19, 55, 0),
            Lieu = "À déterminer"
        });
        _context.SaveChanges();
    }
    private void GeneratePromotions()
    {
        _context.Promotions.Add(new Promotion()
        {
            Id = Guid.NewGuid().ToString(),
            Nom = "Tout pour la lecture",
            Description = "2 pour 1 sur tout les livres québécois",
            Image = "/img/images_Promo/promo1.png",
            DateDebut = new DateTime(2023, 10, 11, 0, 0, 0),
            DateFin = new DateTime(2023, 10, 11, 23, 59, 59),
            LivresAcheter = 1,
            LivresGratuits = 1,
            CodePromo = "2POUR1QC",
            TypePromotion = "2pour1",
            Categorie = _context.Categories.FirstOrDefault(c => c.Nom == "Roman québécois"),
        });
        _context.Promotions.Add(new Promotion()
        {
            Id = Guid.NewGuid().ToString(),
            Nom = "Tout pour la lecture",
            Description = "Les grands soldes sont arrivés. Du 17 au 23 décembre 2023, 30% sur tous les livres",
            Image = "/img/images_Promo/promo2.png",
            DateDebut = new DateTime(2023, 12, 17, 0, 0, 0),
            DateFin = new DateTime(2023, 12, 23, 23, 59, 59),
            CodePromo = "SOLDES30",
            PourcentageRabais = 30,
            TypePromotion = "pourcentage",

        });
        _context.Promotions.Add(new Promotion()
        {
            Id = Guid.NewGuid().ToString(),
            Nom = "Promotion éclair d'une journée",
            Description = "25% de rabais sur tous les livres avec le code promo OHE25",
            Image = "/img/images_Promo/promo3.png",
            DateDebut = new DateTime(2023, 10, 1, 0, 0, 0),
            DateFin = new DateTime(2023, 10, 1, 23, 59, 59),
            CodePromo = "OHE25",
            PourcentageRabais = 25,
            TypePromotion = "pourcentage",

        });
        _context.Promotions.Add(new Promotion()
        {
            Id = Guid.NewGuid().ToString(),
            Nom = "Promotion éclair d'une journée",
            Description = "30% de rabais sur tous les romans policiers avec le code promo OHE30",
            Image = "/img/images_Promo/promo3.png",
            DateDebut = new DateTime(2023, 10, 27, 0, 0, 0),
            DateFin = new DateTime(2023, 10, 27, 23, 59, 59),
            CodePromo = "OHE30",
            PourcentageRabais = 30,
            TypePromotion = "pourcentage",
            Categorie = _context.Categories.FirstOrDefault(c => c.Nom == "Roman policier")
        });
        _context.Promotions.Add(new Promotion()
        {
            Id = Guid.NewGuid().ToString(),
            Nom = "Promotion éclair sur 2 jours",
            Description = "20% de rabais sur tous les livres de pédagogie avec le code promo OHE20",
            Image = "/img/images_Promo/promo3.png",
            DateDebut = new DateTime(2024, 1, 15, 0, 0, 0),
            DateFin = new DateTime(2024, 1, 16, 23, 59, 59),
            CodePromo = "OHE20",
            PourcentageRabais = 20,
            TypePromotion = "pourcentage",
            Categorie = _context.Categories.FirstOrDefault(c => c.Nom == "Pédagogie")
        });
        _context.Promotions.Add(new Promotion()
        {
            Id = Guid.NewGuid().ToString(),
            Nom = "Tout pour la lecture",
            Description = "Les grands soldes de décembre,Du 1er au 16 décembre 2023, 10% sur tous les livres avec le code promo PROMO10DEC ",
            Image = "/img/images_Promo/promo2.png",
            DateDebut = new DateTime(2023, 12, 1, 0, 0, 0),
            DateFin = new DateTime(2023, 12, 16, 23, 59, 59),
            CodePromo = "PROMO10DEC",
            PourcentageRabais = 10,
            TypePromotion = "pourcentage",

        });
        _context.Promotions.Add(new Promotion()
        {
            Id = Guid.NewGuid().ToString(),
            Nom = "Tout pour la lecture",
            Description = "Les grands soldes de janvier. Du 4 au 10 janvier 2024, 20% sur tous les livres avec le code promo PROMO20JAN",
            Image = "/img/images_Promo/promo2.png",
            DateDebut = new DateTime(2024, 1, 4, 0, 0, 0),
            DateFin = new DateTime(2024, 1, 10, 23, 59, 59),
            CodePromo = "PROMO20JAN",
            PourcentageRabais = 20,
            TypePromotion = "pourcentage",

        });
        _context.SaveChanges();
    }
}
