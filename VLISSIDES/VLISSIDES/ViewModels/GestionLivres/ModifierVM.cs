﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionLivres;

public class ModifierVM
{
    public string Id { get; set; }

    [Display(Name = "Nom du livre")] public string Titre { get; set; }

    [Display(Name = "Description")] public string Resume { get; set; }

    public string? Couverture { get; set; }

    public int NbExemplaires { get; set; }

    [Display(Name = "Nombre de pages")] public int NbPages { get; set; }

    public double Prix { get; set; }
    public DateTime DatePublication { get; set; }

    public string ISBN { get; set; }

    //Categories
    public string CategorieId { get; set; }
    public List<SelectListItem>? SelectListCategories { get; set; }

    //Auteurs
    [Display(Name = "Auteur")] public string AuteurId { get; set; }

    public List<SelectListItem>? SelectListAuteurs { get; set; }

    public ICollection<Auteur>? Auteurs { get; set; } //Plusieur auteurs écrit un livre 

    //Maison Edition
    [Display(Name = "Éditeur")] public string MaisonEditionId { get; set; }

    public List<SelectListItem>? SelectMaisonEditions { get; set; }

    //Type
    public string? TypeLivreId { get; set; }
    public bool Numerique { get; set; }
    public bool Neuf { get; set; }
    public ICollection<TypeLivre>? Types { get; set; }

    //public string EvaluationId { get; set; }

    //Langue
    public List<SelectListItem>? SelectLangues { get; set; }
    public string? LangueId { get; set; }

    //Image
    public string? CoverImageUrl { get; set; }

    [Display(Name = "Image du livre")] public IFormFile? CoverPhoto { get; set; }
}