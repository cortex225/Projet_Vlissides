using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Recherche;

public class DetailsLivreVM
{

    [Display(Name = "Identifié")] public string Id { get; set; }
    [Display(Name = "Titre")] public string Titre { get; set; }
    [Display(Name = "Auteurs")] public List<string> Auteurs { get; set; }
    [Display(Name = "Categories")] public List<string> Categories { get; set; }
    [Display(Name = "DatePublication")] public DateTime DatePublication { get; set; }
    [Display(Name = "Couverture")] public string Couverture { get; set; }
    [Display(Name = "MaisonEdition")] public string MaisonEdition { get; set; }
    [Display(Name = "NbPages")] public int NbPages { get; set; }
    [Display(Name = "Resume")] public string Resume { get; set; }
    [Display(Name = "NbExemplaires")] public int NbExemplaires { get; set; }
    [Display(Name = "Papier")] public decimal? Papier { get; set; }
    [Display(Name = "Numerique")] public decimal? Numerique { get; set; }

    [Display(Name = "Note")] public decimal Note { get; set; }

    [Display(Name = "ISBN")] public string ISBN { get; set; }

    [Display(Name = "Langue")] public string Langue { get; set; }
    [Display(Name = "Quantite")] public int Quantite { get; set; }
    public DetailsLivreVM(Livre livre)
    {
        Id = livre.Id;
        Titre = livre.Titre;
        Auteurs = livre.LivreAuteurs.Select(a => a.Auteur.NomAuteur).ToList();
        Categories = livre.Categories.Select(c => c.Categorie.Nom).ToList();
        Note = livre.Note;
        DatePublication = livre.DatePublication;
        Couverture = livre.Couverture;
        MaisonEdition = livre.MaisonEdition != null ? livre.MaisonEdition.Nom : "";
        NbPages = livre.NbPages;
        Resume = livre.Resume;
        ISBN = livre.ISBN;
        Langue = livre.Langue.Nom;
        NbExemplaires = livre.NbExemplaires;
        foreach (var media in livre.LivreTypeLivres)
            switch (media.TypeLivre.Nom)
            {
                case "Papier":
                    Papier = media.Prix;
                    break;
                case "Numérique":
                    Numerique = media.Prix;
                    break;
            }
    }

}