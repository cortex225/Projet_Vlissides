using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Recherche;

public class DetailsLivreVM
{
    public string Id { get; set; }
    public string Titre { get; set; }
    public List<string> Auteurs { get; set; }
    public List<string> Categories { get; set; }
    public DateTime DatePublication { get; set; }
    public string Couverture { get; set; }
    public string MaisonEdition { get; set; }
    public int NbPages { get; set; }
    public string Resume { get; set; }
    public int NbExemplaires { get; set; }
    public double? Papier { get; set; }
    public double? Numerique { get; set; }

    public DetailsLivreVM(string id, string titre, IEnumerable<Auteur> auteurs, IEnumerable<Categorie> categories, DateTime datePublication,
        string couverture, MaisonEdition? maisonEdition, int nbPages, string resume, int nbExemplaires,
        IEnumerable<TypeLivre> livreTypeLivres)
    {
        Id = id;
        Titre = titre;
        Auteurs = auteurs.Select(a => a.NomAuteur).ToList();
        Categories = categories.Select(c => c.Nom).ToList();
        DatePublication = datePublication;
        Couverture = couverture;
        MaisonEdition = maisonEdition.Nom ?? "";
        NbPages = nbPages;
        Resume = resume;
        NbExemplaires = nbExemplaires;
        foreach (var media in livreTypeLivres)
            switch (media.Nom)
            {
                case "Papier": Papier = (double?)media.TypeLivres.Where(t => t.TypeLivre.Nom.Equals("Papier")).First().Prix; break;
                case "Numérique": Numerique = (double?)media.TypeLivres.Where(t => t.TypeLivre.Nom.Equals("Numérique")).First().Prix; break;
            }
    }
}