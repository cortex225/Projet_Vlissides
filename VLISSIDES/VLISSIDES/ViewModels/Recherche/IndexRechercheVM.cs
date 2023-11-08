using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionLivres;

namespace VLISSIDES.ViewModels.Recherche;

public class IndexRechercheVM
{
    public string MotRecherche { get; set; } //Juste le mot clé que l'on va afficher dans le message 

    //"Résultat de recherche pour "MotRecherche"
    public List<string> ResultatRecherche { get; set; }
    public List<DetailsLivreVM> LivrePartials { get; set; }
    public List<string> ListeCategories { get; set; }
    public List<string> ListeLangues { get; set; }
    public List<string> ListeTypeLivres { get; set; }

    public double minPrix { get; set; }
    public double maxPrix { get; set; }

    public IndexRechercheVM(string motRecherche, List<Livre> resultatRecherche, List<Categorie> listeCategories,
        List<Langue> listeLangues, List<TypeLivre> listeTypeLivres, double minPrix = 0, double maxPrix = 199.99)
    {
        motRecherche ??= "";
        resultatRecherche ??= new();
        LivrePartials ??= new();
        listeCategories ??= new();
        listeLangues ??= new();
        listeTypeLivres ??= new();
        MotRecherche = motRecherche;
        ResultatRecherche = resultatRecherche.Select(rr => rr.Titre).ToList();
        LivrePartials = resultatRecherche.Select(rr => new DetailsLivreVM(rr)).ToList();
        ListeLangues = listeLangues.Select(lc => lc.Nom).ToList();
        ListeTypeLivres = listeTypeLivres.Select(lc => lc.Nom).ToList();
        this.minPrix = minPrix;
        this.maxPrix = maxPrix;
    }
}