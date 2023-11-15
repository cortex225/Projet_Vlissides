using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLISSIDES.Models;

public class Promotions
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    [Display(Name = "Nom de la promotion")] public string Nom { get; set; }
    [Display(Name = "Description")] public string Description { get; set; }
    
    [Display(Name = "D�but de la promotion")] public DateTime DateDebut { get; set; }
    [Display(Name = "Fin de la promotion")] public DateTime DateFin { get; set; }

    public string? Image { get; set; }


    [Display(Name = "Auteur")] public string? AuteurId { get; set; }
    public Auteur? Auteur { get; set; }

    [Display(Name = "Cat�gorie")] public string? CategorieId { get; set; }
    public Categorie? Categorie { get; set; }

    [Display(Name = "Maison d'�dition")] public string? MaisonEditionId { get; set; }
    public MaisonEdition? MaisonEdition { get; set; }


    [Display(Name = "Type de promotion")] public string TypePromotion { get; set; }

    [Display(Name = "Livres � acheter")] public int? LivresAcheter { get; set; }
    [Display(Name = "Livres gratuits")] public int? LivresGratuits { get; set; }

    [Display(Name = "Pourcentage du rabais")] public int? PourcentageRabais { get; set; }

    [Display(Name = "Code promo")] public string CodePromo { get; set; }
}