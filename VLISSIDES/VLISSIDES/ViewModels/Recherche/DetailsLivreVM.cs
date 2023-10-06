using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Recherche;

public class DetailsLivreVM
{
    public string Id { get; set; }
    public string Titre { get; set; }
    public List<Auteur> Auteurs { get; set; }
    public List<Categorie> Categories { get; set; }
    public DateTime DatePublication { get; set; }
    public string Couverture { get; set; }
    public string maisonEdition { get; set; }
    public int NbPages { get; set; }
    public string Resume { get; set; }
    public int NbExemplaires { get; set; }
    public bool Papier { get; set; }
    public double? PrixPapier { get; set; }
    public bool Numerique { get; set; }
    public double? PrixNumerique { get; set; }
    public IEnumerable<LivreTypeLivre> LivreTypeLivres { get; set; }

    public DetailsLivreVM(string id, string titre, List<Auteur> auteurs, List<Categorie> categories, DateTime datePublication,
        string couverture, MaisonEdition? maisonEdition, int nbPages, string resume, int nbExemplaires,
        List<TypeLivre> livreTypeLivres)
    {
        Id = id;
        Titre = titre;
        this.Auteurs = auteurs;
        this.Categories = categories;
        DatePublication = datePublication;
        Couverture = couverture;
        this.maisonEdition = maisonEdition.Nom ?? "";
        NbPages = nbPages;
        Resume = resume;
        NbExemplaires = nbExemplaires;
        var media = livreTypeLivres.First(ltl => ltl.Nom.Equals("Papier"));
        Papier = !media.Equals(null);
        PrixPapier = media.Prix;
        media = livreTypeLivres.First(ltl => ltl.Nom.Equals("Numérique"));
        Numerique = !media.Equals(null);
        PrixNumerique = media.Prix;
    }
}