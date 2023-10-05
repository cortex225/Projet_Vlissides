﻿// See https://aka.ms/new-console-template for more information




//Signaler le debut du seeder
using Faker;
using FizzWare.NBuilder;
using Seeder;
using VLISSIDES.Models;
/**
* Ce seeder sert à créer des donnés pour tester le programme. Ce seeder crée:
*      -Auteurs
*      -Maisons d'édtions
*      -Livres
* 
* Éventuellement, nous n'aurons plus besoin de ce seeder lorsqu'on aura les donnés
*/
Console.WriteLine("Début du seed!");
using var context = DbContextFactory.CreateDbContext();

//Listes pour choisir aléatoirement pour les livres
var categories = context.Categories.ToList();
var typeLivres = context.TypeLivres.ToList();
var langues = context.Langues.ToList();

var generator = new RandomGenerator();
Random rand = new Random();


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
    .With(c => c.Couverture)
    .With(c => c.NbExemplaires = 1)
    .With(c => c.DateAjout = DateTime.Now)
    .With(c => c.NbPages = 120)
    .With(c => c.DatePublication = Identification.DateOfBirth())
    .With(c => c.ISBN = Identification.UsPassportNumber())
    .With(c => c.Categories = new List<LivreCategorie>())
    .With(c => c.LivreAuteurs = new())
    .With(c => c.MaisonEdition = Pick<MaisonEdition>.RandomItemFrom(maisonsEditions))
    .With(c => c.LivreTypeLivres = new List<LivreTypeLivre> { new() { TypeLivre = Pick<TypeLivre>.RandomItemFrom(typeLivres) } })
    .With(c => c.Langue = Pick<Langue>.RandomItemFrom(langues))
    .Build();
context.Livres.AddRange(livres);
context.SaveChanges();

//Générer les prix de chaque livres existant dans la base de donnés 
var livreTypeLivres = context.LivreTypeLivres.ToList();
foreach (var livre in livres)
{
    var livreTypeLivre = livreTypeLivres.FirstOrDefault(ltl => ltl.LivreId == livre.Id);
    if (livreTypeLivre != null)
    {
        livreTypeLivre.Prix = rand.Next(10, 100);
    }
}
context.SaveChanges();

//Signaler la fin du seeder
Console.WriteLine("Fin du seed!");