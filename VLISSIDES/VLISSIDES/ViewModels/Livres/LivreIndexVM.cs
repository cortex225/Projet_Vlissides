using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Livres;

public class LivreIndexVM
{
    [Display(Name = "Mot rechercé")] public string MotRecherche { get; set; }
    [Display(Name = "Critères")] public string Criteres { get; set; }

    //"Résultat de recherche pour "MotRecherche"
    [Display(Name = "Resultat de la recherche")] public List<string> ResultatRecherche { get; set; }
    [Display(Name = "Livre partials")] public List<LivreDetailsVM> LivrePartials { get; set; }
    [Display(Name = "Livres")] public List<string> Livres { get; set; }
    [Display(Name = "Auteurs")] public List<string> Auteurs { get; set; }
    [Display(Name = "Editions")] public List<string> MaisonEditions { get; set; }
    [Display(Name = "Catégories")] public List<string> Categories { get; set; }
    [Display(Name = "Langues")] public List<string> Langues { get; set; }
    [Display(Name = "Types de livre")] public List<string> TypeLivres { get; set; }

    [Display(Name = "Prix minimal")] public double minPrix { get; set; }
    [Display(Name = "Prix maximal")] public double maxPrix { get; set; }

    public LivreIndexVM(string motRecherche, string criteres, List<Livre> resultatRecherche, List<Livre> livres,
        List<Auteur> auteurs, List<MaisonEdition> maisonEditions, List<Categorie> categories,
        List<Langue> langues, List<TypeLivre> typeLivres, List<LivreDetailsVM> livresPartials,
        double minPrix = 0, double maxPrix = 199.99)
    {
        motRecherche ??= "";
        criteres ??= "";
        resultatRecherche ??= new List<Livre>();
        LivrePartials ??= new List<LivreDetailsVM>();
        livres ??= new();
        auteurs ??= new();
        maisonEditions ??= new();
        categories ??= new List<Categorie>();
        langues ??= new List<Langue>();
        typeLivres ??= new List<TypeLivre>();
        MotRecherche = motRecherche.Replace("|", ", ");
        Criteres = criteres.Replace("|", ", ");
        ResultatRecherche = resultatRecherche.Select(rr => rr.Titre).ToList();
        LivrePartials = resultatRecherche.Select(rr => new LivreDetailsVM(rr)).ToList();
        Livres = livres.Select(l => l.Titre).ToList();
        Auteurs = auteurs.Select(a => a.NomAuteur).ToList();
        MaisonEditions = maisonEditions.Select(me => me.Nom).ToList();
        Categories = categories.Select(lc => lc.Nom).ToList();
        Langues = langues.Select(lc => lc.Nom).ToList();
        TypeLivres = typeLivres.Select(lc => lc.Nom).ToList();
        this.minPrix = minPrix;
        this.maxPrix = maxPrix;

    }


}