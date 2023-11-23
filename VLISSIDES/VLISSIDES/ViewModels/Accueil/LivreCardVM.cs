//ViewModel pour _CarteLivre.cshtml et CarteLivrePetit.cshtml

using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class LivreCardVM
{

    [DisplayName("Page couverture")] public string Couverture { get; set; }

    [DisplayName("Titre")] public string Titre { get; set; }

    [DisplayName("Prix")] public decimal Prix { get; set; }

    [DisplayName("Auteurs")] public List<string> Auteurs { get; set; }

    [DisplayName("Score")] public double Score { get; set; }

    [DisplayName("Catégories associés")] public List<string> Categories { get; set; }

    public LivreCardVM(Livre livre)
    {
        livre ??= new();
        livre.Evaluations ??= new List<Evaluation>();
        livre.LivreTypeLivres ??= new List<LivreTypeLivre>() { new() { Prix = 0 } };
        livre.LivreAuteurs ??= new List<LivreAuteur>();
        Couverture = livre.Couverture;
        Titre = livre.Titre;
        Prix = livre.LivreTypeLivres.First().Prix;
        Auteurs = livre.LivreAuteurs.Select(a => a.Auteur.NomAuteur).ToList();
        Score = (int)livre.Note;
        Categories = livre.Categories.Select(lc => lc.Categorie.Nom).ToList();
    }
}