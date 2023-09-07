// See https://aka.ms/new-console-template for more information
using FizzWare.NBuilder;
using Seeder;
using VLISSIDES.Models;

Console.WriteLine("Début du seed!");
using var context = DbContextFactory.CreateDbContext();

var categories = context.Categories.ToList();
var typeLivres = context.TypeLivres.ToList();
var evaluations = context.Evaluations.ToList();
var langues = context.Langues.ToList();

var generator = new RandomGenerator();

context.Auteurs.RemoveRange(context.Auteurs); context.SaveChanges();
context.MaisonEditions.RemoveRange(context.MaisonEditions); context.SaveChanges();
context.Livres.RemoveRange(context.Livres); context.SaveChanges();



var auteurs = Builder<Auteur>.CreateListOfSize(99)
    .All()
    .With(c => c.Nom = Faker.Name.Last())
    .With(c => c.Prenom = Faker.Name.First())
    .With(c => c.Biographie = Faker.Lorem.Paragraph())
    .With(c => c.Photo = "~/jean-luc.png")
    .Build();
context.Auteurs.AddRange(auteurs); context.SaveChanges();

var maisonsEditions = Builder<MaisonEdition>.CreateListOfSize(99)
    .All()
    .With(c => c.Nom = Faker.Company.Name())
    .Build();
context.MaisonEditions.AddRange(maisonsEditions); context.SaveChanges();

var livres = Builder<Livre>.CreateListOfSize(2999)
    .All()
    .With(c => c.Titre = Faker.Company.Name())
    .With(c => c.Resume = Faker.Lorem.Paragraph())
    .With(c => c.Couverture = "https://i.pinimg.com/236x/37/a9/98/37a99839a447357ee6d3d4b9c991d864.jpg")
    .With(c => c.NbExemplaires = 1)
    .With(c => c.DateAjout = DateTime.Now)
    .With(c => c.NbPages = 120)
    .With(c => c.Prix = 1.99)
    .With(c => c.DatePublication = Faker.Identification.DateOfBirth())
    .With(c => c.ISBN = Faker.Identification.UsPassportNumber())
    .With(c => c.Categories = new List<Categorie> { Pick<Categorie>.RandomItemFrom(categories) })
    .With(c => c.Auteur = new List<Auteur> { Pick<Auteur>.RandomItemFrom(auteurs) })
    .With(c => c.MaisonEdition = Pick<MaisonEdition>.RandomItemFrom(maisonsEditions))
    .With(c => c.TypesLivre = new List<TypeLivre> { Pick<TypeLivre>.RandomItemFrom(typeLivres) })
    .With(c => c.Langues = new List<Langue> { Pick<Langue>.RandomItemFrom(langues) })
    .Build();
context.Livres.AddRange(livres); context.SaveChanges();

Console.WriteLine("Fin du seed!");
