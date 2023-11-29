using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class PromotionCardVM
{
    public PromotionCardVM(string description, decimal rabais, DateTime dateDebut, DateTime? dateFin, string image)
    {
        Description = description;
        Rabais = rabais;
        DateDebut = dateDebut;
        DateFin = dateFin;
        Image = image;
    }

    public PromotionCardVM(Promotion promotion)
    {
        Description = promotion.Description;
        Rabais = (decimal)promotion.PourcentageRabais;
        DateDebut = promotion.DateDebut;
        DateFin = promotion.DateFin;
        Image = promotion.Image;
    }

    [DisplayName("Description")] public string Description { get; set; }
    [DisplayName("Rabais")] public decimal Rabais { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy hh:mm}")]
    [DisplayName("Date de début")]
    public DateTime DateDebut { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy hh:mm}")]
    [DisplayName("Date de fin")]
    public DateTime? DateFin { get; set; }

    [DisplayName("Image promotion")] public string Image { get; set; }
}