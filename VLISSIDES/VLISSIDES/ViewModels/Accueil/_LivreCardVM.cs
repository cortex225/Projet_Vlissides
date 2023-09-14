//ViewModel pour _CarteLivre.cshtml et CarteLivrePetit.cshtml

using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class _LivreCardVM
{
    public _LivreCardVM(string couverture = "", string titre = "", double prix = 0, List<Auteur> auteurs = default!,
        List<Categorie> categories = default!)
    {
        auteurs ??= new List<Auteur>();
        categories ??= new List<Categorie>();
        Couverture = couverture;
        Titre = titre;
        Prix = prix;
        Auteurs = "";
        if (auteurs.Any())
        {
            auteurs.ForEach(auteur => Auteurs += auteur.NomComplet + ", ");
            Auteurs.Remove(Auteurs.Length - 2, 2);
        }

        Categories ??= new List<string>();
        categories.ForEach(categorie => Categories.Add(categorie.Nom));
    }

    public _LivreCardVM(Livre livre)
    {
        livre.Evaluations ??= new List<Evaluation>();
        Couverture = livre.Couverture;
        Titre = livre.Titre;
        Prix = livre.Prix;
        Auteurs = "";
        Score = (int)livre.Evaluations.Select(evaluation => evaluation.Note).Average();
        if (!((List<Auteur>)livre.Auteur).Any())
        {
            ((List<Auteur>)livre.Auteur).ForEach(auteur => Auteurs += auteur.NomComplet + ", ");
            Auteurs.Remove(Auteurs.Length - 2, 2);
        }

        Categories ??= new List<string>();
        ((List<Auteur>)livre.Categories).ForEach(categorie => Categories.Add(categorie.Nom));
    }

    [DisplayName("Page couverture")] public string Couverture { get; set; }

    [DisplayName("Titre")] public string Titre { get; set; }

    [DisplayName("Prix")] public double Prix { get; set; }

    [DisplayName("Auteurs")] public string Auteurs { get; set; }

    [DisplayName("Score")] public int Score { get; set; }

    [DisplayName("Catégories associés")] public List<string> Categories { get; set; }
}