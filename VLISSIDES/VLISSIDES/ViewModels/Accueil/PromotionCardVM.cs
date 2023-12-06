using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class PromotionCardVM
{
    [DisplayName("Description")] public string Description { get; set; }
    [DisplayName("Rabais")] public decimal Rabais { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy hh:mm}")]
    [DisplayName("Date de début")] public DateTime DateDebut { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy hh:mm}")]
    [DisplayName("Date de fin")] public DateTime DateFin { get; set; }
    [DisplayName("Image promotion")] public string Image { get; set; }

    public PromotionCardVM(Promotion promotion)
    {
        Description = promotion.Nom;
        Rabais = (decimal)(promotion.PourcentageRabais ?? 0);
        DateDebut = promotion.DateDebut;
        DateFin = promotion.DateFin ?? new();
        Image = promotion.Image ?? "";
    }

}