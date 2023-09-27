// See https://aka.ms/new-console-template for more information


/**
 * Ce seeder sert à créer des donnés pour tester le programme. Ce seeder crée:
 *      -Auteurs
 *      -Maisons d'édtions
 *      -Livres
 * 
 * Éventuellement, nous n'aurons plus besoin de ce seeder lorsqu'on aura les donnés
 */
using Faker;
using FizzWare.NBuilder;
using Seeder;
using VLISSIDES.Models;

//Signaler le debut du seeder
Console.WriteLine("Début du seed!");
using var context = DbContextFactory.CreateDbContext();

//Listes pour choisir aléatoirement pour les livres
var categories = context.Categories.ToList();
var typeLivres = context.TypeLivres.ToList();
var langues = context.Langues.ToList();

var generator = new RandomGenerator();


//Supprimer les donnés qui avait avant pour créer les nouvelles donnés
context.Livres.RemoveRange(context.Livres);
context.SaveChanges();
context.Auteurs.RemoveRange(context.Auteurs);
context.SaveChanges();
context.MaisonEditions.RemoveRange(context.MaisonEditions);
context.SaveChanges();


//Générer les auteurs
var auteurs = Builder<Auteur>.CreateListOfSize(99)
    .All()
    .With(c => c.NomAuteur = Name.Last())
    .Build();
context.Auteurs.AddRange(auteurs);
context.SaveChanges();

//Générer les maisons d'édition
var maisonsEditions = Builder<MaisonEdition>.CreateListOfSize(99)
    .All()
    .With(c => c.Nom = Company.Name())
    .Build();
context.MaisonEditions.AddRange(maisonsEditions);
context.SaveChanges();

//Générer les livres
var livres = Builder<Livre>.CreateListOfSize(299)
    .All()
    .With(c => c.Titre = Company.Name())
    .With(c => c.Resume = Lorem.Paragraph())
    .With(c => c.Couverture = "https://i.pinimg.com/236x/37/a9/98/37a99839a447357ee6d3d4b9c991d864.jpg")
    .With(c => c.NbExemplaires = 1)
    .With(c => c.DateAjout = DateTime.Now)
    .With(c => c.NbPages = 120)
    .With(c => c.Prix = 1.99)
    .With(c => c.DatePublication = Identification.DateOfBirth())
    .With(c => c.ISBN = Identification.UsPassportNumber())
    .With(c => c.Categorie = Pick<Categorie>.RandomItemFrom(categories))
    .With(c => c.Auteur = Pick<Auteur>.RandomItemFrom(auteurs))
    .With(c => c.MaisonEdition = Pick<MaisonEdition>.RandomItemFrom(maisonsEditions))
    .With(c => c.LivreTypeLivres = new List<LivreTypeLivre> { new() { TypeLivre = Pick<TypeLivre>.RandomItemFrom(typeLivres) } })
    .With(c => c.Langues = new List<Langue> { Pick<Langue>.RandomItemFrom(langues) })
    .Build();
context.Livres.AddRange(livres);
context.SaveChanges();

//Signaler la fin du seeder
Console.WriteLine("Fin du seed!");