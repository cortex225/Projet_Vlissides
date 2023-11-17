using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Recherche;

public class IndexRechercheVM
{
    public IndexRechercheVM(string motRecherche, List<Livre> resultatRecherche, List<Categorie> listeCategories,
        List<Langue> listeLangues, List<TypeLivre> listeTypeLivres, double minPrix = 0, double maxPrix = 199.99)
    {
        motRecherche ??= "";
        resultatRecherche ??= new List<Livre>();
        LivrePartials ??= new List<DetailsLivreVM>();
        listeCategories ??= new List<Categorie>();
        listeLangues ??= new List<Langue>();
        listeTypeLivres ??= new List<TypeLivre>();
        MotRecherche = motRecherche;
        ResultatRecherche = resultatRecherche.Select(rr => rr.Titre).ToList();
        LivrePartials = resultatRecherche.Select(rr => new DetailsLivreVM(rr.Id, rr.Titre,
            rr.LivreAuteurs.Select(la => la.Auteur),
            rr.Categories.Select(lc => lc.Categorie), rr.Evaluations.Select(le => le.Note),
            rr.DatePublication, rr.Couverture, rr.MaisonEdition, rr.NbPages, rr.Resume,
            rr.NbExemplaires, rr.LivreTypeLivres, rr.ISBN, rr.Langue.Nom)).ToList();
        ListeCategories = listeCategories.Select(lc => lc.Nom).ToList();
        ListeLangues = listeLangues.Select(lc => lc.Nom).ToList();
        ListeTypeLivres = listeTypeLivres.Select(lc => lc.Nom).ToList();
        this.minPrix = minPrix;
        this.maxPrix = maxPrix;
    }

    public string MotRecherche { get; set; } //Juste le mot clé que l'on va afficher dans le message 

    //"Résultat de recherche pour "MotRecherche"
    public List<string> ResultatRecherche { get; set; }
    public List<DetailsLivreVM> LivrePartials { get; set; }
    public List<string> ListeCategories { get; set; }
    public List<string> ListeLangues { get; set; }
    public List<string> ListeTypeLivres { get; set; }

    public double minPrix { get; set; }
    public double maxPrix { get; set; }
}