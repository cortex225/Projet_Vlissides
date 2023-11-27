using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Recherche;

public class DetailsLivreVM
{
    public DetailsLivreVM(string id, string titre, IEnumerable<Auteur> auteurs, IEnumerable<Categorie> categories,
        IEnumerable<int> notes,
        DateTime datePublication, string couverture, MaisonEdition? maisonEdition, int nbPages, string resume,
        int nbExemplaires,
        ICollection<LivreTypeLivre> livreTypeLivres, string isbn, string langue)
    {
        Id = id;
        Titre = titre;
        Auteurs = auteurs.Select(a => a.NomAuteur).ToList();
        Categories = categories.Select(c => c.Nom).ToList();
        Notes = notes.ToList();
        DatePublication = datePublication;
        Couverture = couverture;
        MaisonEdition = maisonEdition != null ? maisonEdition.Nom : "";
        NbPages = nbPages;
        Resume = resume;
        ISBN = isbn;
        Langue = langue;
        NbExemplaires = nbExemplaires;
        foreach (var media in livreTypeLivres)
            switch (media.TypeLivre.Nom)
            {
                case "Papier":
                    Papier = media.Prix;
                    break;
                case "Numérique":
                    Numerique = media.Prix;
                    break;
            }

        CalculerNote();
    }

    public string Id { get; set; }
    public string Titre { get; set; }
    public List<string> Auteurs { get; set; }
    public List<string> Categories { get; set; }
    public List<int> Notes { get; set; }
    public DateTime DatePublication { get; set; }
    public string Couverture { get; set; }
    public string MaisonEdition { get; set; }
    public int NbPages { get; set; }
    public string Resume { get; set; }
    public int NbExemplaires { get; set; }
    public decimal? Papier { get; set; }
    public decimal? Numerique { get; set; }

    private Random rnd { get; set; }
    private double rDouble { get; set; }
    public double Note { get; set; }

    public string ISBN { get; set; }

    public string Langue { get; set; }
    public int Quantite { get; set; }

    public void CalculerNote()
    {
        var total = 0.0;
        double nbNotes = Notes.Count();
        foreach (var n in Notes) total += Convert.ToDouble(n);

        if (nbNotes == 0.0)
            Note = 0.0;
        else
            Note = total / nbNotes;
    }

}