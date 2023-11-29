//ViewModel pour _CarteLivre.cshtml et CarteLivrePetit.cshtml

using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class LivreCardVM
{
    public LivreCardVM(string couverture = "", string titre = "", decimal prix = 0, List<Auteur> auteurs = default!,
        List<Categorie> categories = default!)
    {
        //auteurs ??= new List<Auteur>();
        //categories ??= new List<Categorie>();
        Couverture = couverture;
        Titre = titre;
        Prix = prix;
        Auteurs = auteurs.Select(a => a.NomAuteur).ToList();
        Categories = categories.Select(c => c.Nom).ToList();
    }

    public LivreCardVM(string v, Livre livre)
    {
        livre.Evaluations ??= new List<Evaluation>();
        Couverture = livre.Couverture;
        Titre = livre.Titre;
        Prix = livre.LivreTypeLivres.FirstOrDefault().Prix;
        Auteurs = livre.LivreAuteurs.Select(a => a.Auteur.NomAuteur).ToList();
        Score = (int)livre.Note;
        Categories = livre.Categories.Select(lc => lc.Categorie.Nom).ToList();
    }

    [DisplayName("Page couverture")] public string Couverture { get; set; }

    [DisplayName("Titre")] public string Titre { get; set; }

    [DisplayName("Prix")] public decimal Prix { get; set; }

    [DisplayName("Auteurs")] public List<string> Auteurs { get; set; }

    [DisplayName("Score")] public double Score { get; set; }

    [DisplayName("Catégories associés")] public List<string> Categories { get; set; }
}