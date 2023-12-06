using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionLivres;

public class GestionLivresIndexVM
{

    [Display(Name = "Resultat de recherche")] public List<DetailsLivreVM> ResultatRecherche { get; set; }
    [Display(Name = "Livreà afficher")] public List<DetailsLivreVM> LivrePartials { get; set; }
    [Display(Name = "Livres")] public List<string> Livres { get; set; }
    [Display(Name = "Auteurs")] public List<string> Auteurs { get; set; }
    [Display(Name = "Editions")] public List<string> MaisonEditions { get; set; }
    [Display(Name = "Categories")] public List<string> Categories { get; set; }
    [Display(Name = "Langues")] public List<string> Langues { get; set; }
    [Display(Name = "Type des Livres")] public List<string> TypeLivres { get; set; }

    [Display(Name = "Prix minimum")] public double minPrix { get; set; }
    [Display(Name = "Prix maximum")] public double maxPrix { get; set; }

    public GestionLivresIndexVM(List<Livre> resultatRecherche, List<Livre> livres, List<Auteur> auteurs, List<MaisonEdition> maisonEditions, List<Categorie> categories,
        List<Langue> langues, List<TypeLivre> typeLivres, double minPrix = 0, double maxPrix = 199.99)
    {
        resultatRecherche ??= new();
        LivrePartials ??= new();
        livres ??= new();
        auteurs ??= new();
        maisonEditions ??= new();
        categories ??= new();
        langues ??= new();
        typeLivres ??= new();
        ResultatRecherche = resultatRecherche.Select(rr => new DetailsLivreVM(rr)).ToList();
        LivrePartials = resultatRecherche.Select(rr => new DetailsLivreVM(rr)).ToList();
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