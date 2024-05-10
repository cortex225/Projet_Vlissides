using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionLivres;

public class GestionLivresAfficherVM
{
    [Display(Name = "Identifiant")] public string Id { get; set; }
    [Display(Name = "Image")] public string Image { get; set; }
    [Display(Name = "Titre")] public string Titre { get; set; }
    [Display(Name = "ISBN")] public string ISBN { get; set; }

    [Display(Name = "Catégories")] public List<string> Categories { get; set; }
    [Display(Name = "Types de livre")] public List<string> LivreTypeLivres { get; set; }

    //public ICollection<Auteur>? Auteur { get; set; }
    [Display(Name = "List d'auteur")] public List<string>? ListAuteur { get; set; }

    [Display(Name = "Quantité")] public int Quantite { get; set; }

    public GestionLivresAfficherVM(Livre livre)
    {
        livre ??= new();
        Id = livre.Id;
        Image = livre.Couverture;
        Titre = livre.Titre;
        ISBN = livre.ISBN;
        Categories = livre.Categories.Select(c => c.Categorie.Nom).ToList();
        LivreTypeLivres = livre.LivreTypeLivres.Select(ltl => ltl.TypeLivre.Nom).ToList();
        ListAuteur = (livre.LivreAuteurs ?? new()).Select(la => la.Auteur.NomAuteur).ToList();
        Quantite = livre.NbExemplaires;
    }
}