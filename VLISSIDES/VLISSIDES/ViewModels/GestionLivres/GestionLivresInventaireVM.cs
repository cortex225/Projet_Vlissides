using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionLivres;

public class GestionLivresInventaireVM
{
    public GestionLivresInventaireVM(List<Livre> resultatRecherche, List<Livre> livres, List<Auteur> auteurs,
        List<MaisonEdition> maisonEditions, List<Categorie> categories,
        List<Langue> langues, List<TypeLivre> typeLivres, double minPrix = 0, double maxPrix = 199.99)
    {
        resultatRecherche ??= new List<Livre>();
        LivrePartials ??= new List<DetailsLivreVM>();
        livres ??= new List<Livre>();
        auteurs ??= new List<Auteur>();
        maisonEditions ??= new List<MaisonEdition>();
        categories ??= new List<Categorie>();
        langues ??= new List<Langue>();
        typeLivres ??= new List<TypeLivre>();
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
}