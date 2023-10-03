//ViewModel pour _CarteLivre.cshtml et CarteLivrePetit.cshtml

using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class LivreCardVM
{
    public LivreCardVM(string couverture = "", string titre = "", decimal prix = 0, Auteur auteurs = default!,
        Categorie categories = default!)
    {
        //auteurs ??= new List<Auteur>();
        //categories ??= new List<Categorie>();
        Couverture = couverture;
        Titre = titre;
        Prix = prix;
        Auteurs = auteurs?.NomAuteur;

        Categorie = categories?.Nom;
    }

    public LivreCardVM(string v, Livre livre)
    {
        livre.Evaluations ??= new List<Evaluation>();
        Couverture = livre.Couverture;
        Titre = livre.Titre;
        Prix = livre.LivreTypeLivres.FirstOrDefault().Prix;
        Auteurs = "";
        livre.Auteurs.ForEach(a => Auteurs += a.NomAuteur + ", ");
        Score = (int)livre.Evaluations.Select(evaluation => evaluation.Note).Average();

        Categorie = livre.Categorie.Nom;
    }

    [DisplayName("Page couverture")] public string Couverture { get; set; }

    [DisplayName("Titre")] public string Titre { get; set; }

    [DisplayName("Prix")] public decimal Prix { get; set; }

    [DisplayName("Auteurs")] public string Auteurs { get; set; }

    [DisplayName("Score")] public int Score { get; set; }

    [DisplayName("Catégories associés")] public string Categorie { get; set; }
}