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
    public Decimal? Papier { get; set; }
    public Decimal? Numerique { get; set; }

    private Random rnd { get; set; }
    private double rDouble { get; set; }
    public double cote { get; set; }

    public DetailsLivreVM(string id, string titre, IEnumerable<Auteur> auteurs, IEnumerable<Categorie> categories, DateTime datePublication,
        string couverture, MaisonEdition? maisonEdition, int nbPages, string resume, int nbExemplaires,
        IEnumerable<LivreTypeLivre> livreTypeLivres)
    {
        rnd = new Random();
        rDouble = rnd.NextDouble();
        cote = rDouble * (5.0 - 0.0) + 0.0;

        Id = id;
        Titre = titre;
        Auteurs = auteurs.Select(a => a.NomAuteur).ToList();
        Categories = categories.Select(c => c.Nom).ToList();
        DatePublication = datePublication;
        Couverture = couverture;
        MaisonEdition = maisonEdition != null ? maisonEdition.Nom : "";
        NbPages = nbPages;
        Resume = resume;
        NbExemplaires = nbExemplaires;
        foreach (var media in livreTypeLivres)
            switch (media.TypeLivre.Nom)
            {
                case "Papier": Papier = media.Prix; break;
                case "Numérique": Numerique = media.Prix; break;
            }
    }
}