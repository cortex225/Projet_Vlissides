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

    public PromotionCardVM(Promotions promotions)
    {
        Description = promotions.Description;
        Rabais = (decimal)(promotions.PourcentageRabais ?? 0);
        DateDebut = promotions.DateDebut;
        DateFin = promotions.DateFin;
        Image = promotions.Image ?? "";
    }

}