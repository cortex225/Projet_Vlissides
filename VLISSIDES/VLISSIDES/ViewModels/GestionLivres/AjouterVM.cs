﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Livres;

public class AjouterVM
{
    [Required(ErrorMessage = "Le titre est obligatoire")]
    [Display(Name = "Nom du livre")]
    public string Titre { get; set; }

    [Required(ErrorMessage = "La description est obligatoire")]
    [Display(Name = "Description")]
    public string Resume { get; set; }

    public string? Couverture { get; set; }

    [Display(Name = "Nombre d'exemplaires")]
    public int NbExemplaires { get; set; }

    [Display(Name = "Nombre de pages")] public int NbPages { get; set; }


    [Display(Name = "Date de publication")]
    public DateTime DatePublication { get; set; }

    [Required(ErrorMessage = "L'ISBN est obligatoire")]
    [Display(Name = "ISBN")]
    public string ISBN { get; set; }

    //Categories
    [Required(ErrorMessage = "Les catégories sont obligatoires")]
    [Display(Name = "Catégorie")]
    public List<string> CategorieIds { get; set; }

    public ICollection<Categorie>? Categories { get; set; }

    public List<SelectListItem>? SelectListCategories { get; set; }

    //Auteurs
    [Display(Name = "Auteur")] public List<string>? AuteurIds { get; set; }

    public List<SelectListItem>? SelectListAuteurs { get; set; }

    public ICollection<Auteur>? Auteurs { get; set; } //Plusieur auteurs écrit un livre 

    //Maison Edition
    [Display(Name = "Éditeur")] public string MaisonEditionId { get; set; }

    public List<SelectListItem>? SelectMaisonEditions { get; set; }

    //Type
    [Display(Name = "Type")] public string? TypeLivreId { get; set; }

    public bool Numerique { get; set; }

    [Display(Name = "Prix Numérique")] public decimal PrixNumerique { get; set; }

    public bool Neuf { get; set; }

    [Display(Name = "Prix Neuf")] public decimal PrixNeuf { get; set; }

    public ICollection<TypeLivre>? Types { get; set; }

    //public string EvaluationId { get; set; }

    //Langue


    [Display(Name = "Langue")] public string? LangueId { get; set; }

    public List<SelectListItem>? SelectLangues { get; set; }

    //Image
    public string? CoverImageUrl { get; set; }

    [Display(Name = "Image du livre")] public IFormFile? CoverPhoto { get; set; }
}