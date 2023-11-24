using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Livres;

public class AjouterVM
{
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

    [Display(Name = "Catégories")] public List<Categorie>? Categories { get; set; }

    [Display(Name = "Catégorie liste")] public List<SelectListItem>? SelectListCategories { get; set; }

    //Auteurs
    [Display(Name = "Auteur")] public List<string>? AuteurIds { get; set; }
    [Display(Name = "Auteurs")] public List<Auteur>? Auteurs { get; set; } //Plusieur auteurs écrit un livre 

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

    [Display(Name = "Type")] public List<TypeLivre>? Types { get; set; }

    //Langue
    [Display(Name = "Langue")] public string? LangueId { get; set; }

    [Display(Name = "Liste langue")] public List<SelectListItem>? SelectLangues { get; set; }

    //Image
    [Display(Name = "Chemin de la couverture")] public string? CoverImageUrl { get; set; }

    [Display(Name = "Image du livre")] public IFormFile? CoverPhoto { get; set; }

    //PDF pour livre numérique
    [Display(Name = "Chemin du pdf")] public string? NumeriqueUrl { get; set; }
    [Display(Name = "Fichier numérique")] public IFormFile? NumeriqueFile { get; set; }

    public AjouterVM(List<SelectListItem>? selectListCategories, List<SelectListItem>? selectListAuteurs,
       List<SelectListItem>? selectMaisonEditions, List<SelectListItem>? SelectionTypes,
       List<SelectListItem>? selectLangues, IFormFile? papierFile, IFormFile? numeriqueFile)
    {
        Titre = "";
        Resume = "";
        Couverture = "";
        NbExemplaires = 0;
        NbPages = 0;
        DatePublication = new();
        ISBN = "";
        CategorieIds = new();
        Categories = new();
        SelectListCategories = selectListCategories;
        AuteurIds = new();
        Auteurs = new();
        SelectListAuteurs = selectListAuteurs;
        MaisonEditionId = "";
        SelectMaisonEditions = selectMaisonEditions;
        TypeLivreId = "";
        Numerique = false;
        PrixNumerique = 0;
        Papier = false;
        PrixPapier = 0;
        Types = new();
        LangueId = "";
        SelectLangues = selectLangues;
        CoverImageUrl = "";
        CoverPhoto = papierFile;
        NumeriqueUrl = "";
        NumeriqueFile = numeriqueFile;
    }
}