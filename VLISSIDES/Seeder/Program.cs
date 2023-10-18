// See https://aka.ms/new-console-template for more information


//Signaler le debut du seeder

using ExcelDataReader;
using Faker;
using FizzWare.NBuilder;
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

        var generator = new RandomGenerator();
        Random rand = new Random();


//Supprimer les donnés qui avait avant pour créer les nouvelles donnés
_context.Livres.RemoveRange(_context.Livres);
_context.SaveChanges();
_context.Auteurs.RemoveRange(_context.Auteurs);
_context.SaveChanges();
_context.MaisonEditions.RemoveRange(_context.MaisonEditions);
_context.SaveChanges();


//Générer les auteurs
        var auteurs = Builder<Auteur>.CreateListOfSize(99)
            .All()
            .With(c => c.NomAuteur = Name.Last())
            .Build();
        _context.Auteurs.AddRange(auteurs);
        _context.SaveChanges();

//Générer les maisons d'édition
        var maisonsEditions = Builder<MaisonEdition>.CreateListOfSize(99)
            .All()
            .With(c => c.Nom = Company.Name())
            .Build();
        _context.MaisonEditions.AddRange(maisonsEditions);
        _context.SaveChanges();

//Générer les livres
        var livres = Builder<Livre>.CreateListOfSize(299)
            .All()
            .With(c => c.Titre = Company.Name())
            .With(c => c.Resume = Lorem.Paragraph())
            .With(c => c.Couverture)
            .With(c => c.NbExemplaires = 1)
            .With(c => c.DateAjout = DateTime.Now)
            .With(c => c.NbPages = 120)
            .With(c => c.DatePublication = Identification.DateOfBirth())
            .With(c => c.ISBN = Identification.UsPassportNumber())
            .With(c => c.Categories = new List<LivreCategorie>())
            .With(c => c.LivreAuteurs = new())
            .With(c => c.MaisonEdition = Pick<MaisonEdition>.RandomItemFrom(maisonsEditions))
            .With(c => c.LivreTypeLivres = new List<LivreTypeLivre>
                { new() { TypeLivre = Pick<TypeLivre>.RandomItemFrom(typeLivres) } })
            .With(c => c.Langue = Pick<Langue>.RandomItemFrom(langues))
            .Build();
        _context.Livres.AddRange(livres);
        _context.SaveChanges();

//Générer les prix de chaque livres existant dans la base de donnés 
        var livreTypeLivres = _context.LivreTypeLivres.ToList();
        foreach (var livre in livres)
        {
            var livreTypeLivre = livreTypeLivres.FirstOrDefault(ltl => ltl.LivreId == livre.Id);
            if (livreTypeLivre != null)
            {
                livreTypeLivre.Prix = rand.Next(10, 100);
            }
        }

        _context.SaveChanges();

        //Signaler le début de la lecture du fichier Excel
        Console.WriteLine("************ Début de la lecture du fichier Excel!************* ");
        string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Ressources", "DonneesLivres.xlsx");
        SeedFromExcel(fileName);
        //Signaler la fin de la lecture du fichier Excel
        Console.WriteLine("************ Succès!************* ");


//Signaler la fin du seeder
        Console.WriteLine("Fin du seed!");
    }

    private void SeedFromExcel(string fileName)
    {
        using var stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

        using var reader = ExcelReaderFactory.CreateReader(stream);

        while (reader.Read()) // Chaque ligne représente un livre
        {
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

            if (reader.GetValue(2) != null) maisonEdition.Nom = reader.GetString(2);

            #endregion

            #region Page

            livre.NbPages = reader.GetValue(3) != null ? (int)reader.GetDouble(3) : 0;

            #endregion

            #region ISBN

            livre.ISBN = reader.GetValue(4) != null ? reader.GetValue(4).ToString().Trim() : "";

            #endregion

            #region Couverture

            livre.Couverture = reader.GetValue(0) != null
                ? "/img/Couvertures/" + reader.GetString(0).Trim().Trim('"').Trim() + ".png"
                : "";

            #endregion

            #region Catégorie

            if (reader.GetValue(6) != null)
                categories.Add(new Categorie { Id = id, Nom = reader.GetString(6), Description = "" });

            #endregion

            #region Quantité

            livre.NbExemplaires = reader.GetValue(9) != null ? (int)reader.GetDouble(9) : 0;

            #endregion

            #region Papier

            if (reader.GetValue(7) != null)
                typeLivres.Add(new LivreTypeLivre
                {
                    LivreId = id,
                    TypeLivreId = "2",
                    Prix = reader.GetValue(7) != null ? reader.GetDecimal(8) : 0,
                });

            #endregion

            #region Numérique

            if (reader.GetValue(10) != null)
                typeLivres.Add(new LivreTypeLivre
                {
                    TypeLivreId = "1",
                    Prix = reader.GetValue(7) != null ? reader.GetDecimal(11) : 0
                });

            #endregion

            // Ajouter les objets créés à la base de données
            _context.Livres.Add(livre);
            _context.Auteurs.AddRange(auteurs);
            _context.MaisonEditions.Add(maisonEdition);
            _context.Categories.AddRange(categories);
            _context.LivreTypeLivres.AddRange(typeLivres);
        }

        _context.SaveChanges();
    }
}