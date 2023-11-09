using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.Models;

public class Promotions
{
    public string Id { get; set; }

    [Display(Name = "Nom de la promotion")] public string Nom { get; set; }
    [Display(Name = "Description")] public string Description { get; set; }

    [Display(Name = "Début de la promotion")] public DateTime DateDebut { get; set; }
    [Display(Name = "Fin de la promotion")] public DateTime DateFin { get; set; }

    public string? Image { get; set; }


    [Display(Name = "Auteur")] public string? AuteurId { get; set; }
    public Auteur? Auteur { get; set; }

    [Display(Name = "Catégorie")] public string? CategorieId { get; set; }
    public Categorie? Categorie { get; set; }

    [Display(Name = "Maison d'édition")] public string? MaisonEditionId { get; set; }
    public MaisonEdition? MaisonEdition { get; set; }


    [Display(Name = "Type de promotion")] public string TypePromotion { get; set; }

    [Display(Name = "Livres à acheter")] public int? LivresAcheter { get; set; }
    [Display(Name = "Livres gratuits")] public int? LivresGratuits { get; set; }

    [Display(Name = "Pourcentage du rabais")] public int? PourcentageRabais { get; set; }

    [Display(Name = "Code promo")] public string CodePromo { get; set; }
}