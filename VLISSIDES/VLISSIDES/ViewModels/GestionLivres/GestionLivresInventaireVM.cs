using VLISSIDES.Models;
using VLISSIDES.ViewModels.Recherche;

namespace VLISSIDES.ViewModels.GestionLivres;

public class GestionLivresInventaireVM
{

    public List<string> ResultatRecherche { get; set; }
    public List<DetailsLivreVM> LivrePartials { get; set; }
    public List<string> Livres { get; set; }
    public List<string> Auteurs { get; set; }
    public List<string> MaisonEditions { get; set; }
    public List<string> Categories { get; set; }
    public List<string> Langues { get; set; }
    public List<string> TypeLivres { get; set; }

    public double minPrix { get; set; }
    public double maxPrix { get; set; }

    public GestionLivresInventaireVM(List<Livre> resultatRecherche, List<Livre> livres, List<Auteur> auteurs, List<MaisonEdition> maisonEditions, List<Categorie> categories,
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
        ResultatRecherche = resultatRecherche.Select(rr => rr.Titre).ToList();
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