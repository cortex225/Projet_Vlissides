using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionLivres;

public class ModifierVM
{
    [Display(Name = "Identifiant")] public string Id { get; set; }
    [Required(ErrorMessage = "Le titre est obligatoire")]
    [Display(Name = "Nom du livre")] public string Titre { get; set; }

    [Required(ErrorMessage = "La description est obligatoire")]
    [Display(Name = "Description")] public string Resume { get; set; }

    [Display(Name = "Couverture")] public string? Couverture { get; set; }

    [Display(Name = "Nombre d'exemplaires")] public int NbExemplaires { get; set; }

    [Display(Name = "Nombre de pages")] public int NbPages { get; set; }


    [Display(Name = "Date de publication")] public DateTime DatePublication { get; set; }

    [Required(ErrorMessage = "L'ISBN est obligatoire")]
    [Display(Name = "ISBN")] public string ISBN { get; set; }

    //Categories
    [Required(ErrorMessage = "Les catégories sont obligatoires")]
    [Display(Name = "Catégorie")] public List<string> CategorieIds { get; set; }

    [Display(Name = "Catégories")] public List<string>? Categories { get; set; }

    [Display(Name = "Catégorie liste")] public List<SelectListItem>? SelectListCategories { get; set; }

    //Auteurs
    [Display(Name = "Auteur")] public List<string>? AuteurIds { get; set; }
    [Display(Name = "Auteurs")] public List<string>? Auteurs { get; set; } //Plusieur auteurs écrit un livre 

    [Display(Name = "Auteur liste")] public List<SelectListItem>? SelectListAuteurs { get; set; }


    //Maison Edition
    [Display(Name = "Éditeur")] public string MaisonEditionId { get; set; }

    [Display(Name = "Éditeur liste")] public List<SelectListItem>? SelectMaisonEditions { get; set; }

    //Type
    [Display(Name = "Type")] public string? TypeLivreId { get; set; }

    [Display(Name = "À une version numerique")] public bool Numerique { get; set; }

    [Display(Name = "Prix mumérique")] public decimal PrixNumerique { get; set; }

    [Display(Name = "À une version papier")] public bool Papier { get; set; }

    [Display(Name = "Prix papier")] public decimal PrixPapier { get; set; }

    [Display(Name = "Type")] public List<string>? Types { get; set; }

    //Langue
    [Display(Name = "Langue")] public string? LangueId { get; set; }

    [Display(Name = "Liste langue")] public List<SelectListItem>? SelectLangues { get; set; }

    //Image
    [Display(Name = "Chemin de la couverture")] public string? CoverImageUrl { get; set; }

    [Display(Name = "Image du livre")] public IFormFile? CoverPhoto { get; set; }

    //PDF pour livre numérique
    [Display(Name = "Chemin du pdf")] public string? NumeriqueUrl { get; set; }
    [Display(Name = "Fichier numérique")] public IFormFile? NumeriqueFile { get; set; }

    public ModifierVM()
    {
        Id = "";
        Titre = "";
        Resume = "";
        Couverture = "";
        NbExemplaires = 0;
        NbPages = 0;
        DatePublication = DateTime.Now;
        ISBN = "";
        CategorieIds = new();
        Categories = new();
        SelectListCategories = new();
        AuteurIds = new();
        Auteurs = new();
        SelectListAuteurs = new();
        MaisonEditionId = "";
        SelectMaisonEditions = new();
        TypeLivreId = "";
        Numerique = false;
        PrixNumerique = 0;
        Papier = false;
        PrixPapier = 0;
        Types = new();
        LangueId = "";
        SelectLangues = new();
        CoverImageUrl = "";
        CoverPhoto = null;
        NumeriqueUrl = "";
        NumeriqueFile = null;
    }
    public ModifierVM(Livre livre, IEnumerable<Categorie> categories, IEnumerable<Auteur> auteurs,
        IEnumerable<MaisonEdition> maisonEditions, IEnumerable<Langue> langues)
    {
        livre ??= new();
        Id = livre.Id;
        Titre = livre.Titre;
        Resume = livre.Resume;
        Couverture = livre.Couverture;
        NbExemplaires = livre.NbExemplaires;
        NbPages = livre.NbPages;
        DatePublication = livre.DatePublication;
        ISBN = livre.ISBN;
        CategorieIds = livre.Categories.Select(c => c.Categorie.Id).ToList();
        Categories = livre.Categories.Select(c => c.Categorie.Nom).ToList();
        SelectListCategories = categories.Select(x => new SelectListItem
        {
            Text = x.Nom,
            Value = x.Id
        }).ToList();
        AuteurIds = (livre.LivreAuteurs ?? new()).Select(la => la.AuteurId).ToList();
        Auteurs = (livre.LivreAuteurs ?? new()).Select(la => la.Auteur.NomAuteur).ToList();
        SelectListAuteurs = auteurs.Select(x => new SelectListItem
        {
            Text = x.NomAuteur,
            Value = x.Id
        }).ToList();
        MaisonEditionId = (livre.MaisonEdition ?? new()).Nom;
        SelectMaisonEditions = maisonEditions.Select(x => new SelectListItem
        {
            Text = x.Nom,
            Value = x.Id
        }).ToList();
        TypeLivreId = "";
        Numerique = livre.LivreTypeLivres.Any(ltl => ltl.TypeLivre.Nom.Equals("Numérique"));
        PrixNumerique = Numerique ? livre.LivreTypeLivres.First(ltl => ltl.TypeLivre.Nom.Equals("Numérique")).Prix : 0;
        Papier = livre.LivreTypeLivres.Any(ltl => ltl.TypeLivre.Nom.Equals("Papier"));
        PrixPapier = Papier ? livre.LivreTypeLivres.First(ltl => ltl.TypeLivre.Nom.Equals("Papier")).Prix : 0;
        Types = new();
        LangueId = livre.LangueId;
        SelectLangues = langues.Select(x => new SelectListItem
        {
            Text = x.Nom,
            Value = x.Id
        }).ToList();
        CoverImageUrl = livre.Couverture;
        CoverPhoto = null;
        NumeriqueUrl = livre.UrlNumerique;
        NumeriqueFile = null;
    }
}