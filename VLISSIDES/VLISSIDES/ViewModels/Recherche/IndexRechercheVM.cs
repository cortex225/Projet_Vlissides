using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Recherche;

public class IndexRechercheVM
{
    public string MotRecherche { get; set; }
    public string Criteres { get; set; }

    //"Résultat de recherche pour "MotRecherche"
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

    public IndexRechercheVM(string motRecherche, string criteres, List<Livre> resultatRecherche, List<Livre> livres, List<Auteur> auteurs, List<MaisonEdition> maisonEditions, List<Categorie> categories,
        List<Langue> langues, List<TypeLivre> typeLivres, double minPrix = 0, double maxPrix = 199.99)
    {
        motRecherche ??= "";
        criteres ??= "";
        resultatRecherche ??= new();
        LivrePartials ??= new();
        livres ??= new();
        auteurs ??= new();
        maisonEditions ??= new();
        categories ??= new();
        langues ??= new();
        typeLivres ??= new();
        MotRecherche = motRecherche.Replace("|", ", ");
        Criteres = criteres.Replace("|", ", ");
        ResultatRecherche = resultatRecherche.Select(rr => rr.Titre).ToList();
        LivrePartials = resultatRecherche.Select(rr => new DetailsLivreVM(rr.Id, rr.Titre, rr.LivreAuteurs.Select(la => la.Auteur),
            rr.Categories.Select(lc => lc.Categorie), rr.Evaluations.Select(le => le.Note),
            rr.DatePublication, rr.Couverture, rr.MaisonEdition, rr.NbPages, rr.Resume,
            rr.NbExemplaires, rr.LivreTypeLivres, rr.NbExemplaires)).ToList();
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