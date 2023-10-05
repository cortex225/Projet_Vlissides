using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class PromotionCardVM
{
    public PromotionCardVM(string description, decimal rabais, DateTime dateDebut, DateTime dateFin,string image)
    {
        Description = description;
        Rabais = rabais;
        DateDebut = dateDebut;
        DateFin = dateFin;
        Image = image;
    }
    
    public PromotionCardVM(Promotions promotions)
    {
        Description = promotions.Description;
        Rabais = promotions.Rabais;
        DateDebut = promotions.DateDebut;
        DateFin = promotions.DateFin;
        Image = promotions.Image;
    }

    [DisplayName("Description")] public string Description { get; set; }
    [DisplayName("Rabais")] public decimal Rabais { get; set; }
    [DisplayName("Date de début")] public DateTime DateDebut { get; set; }
    [DisplayName("Date de fin")] public DateTime DateFin { get; set; }
    [DisplayName("Image promotion")] public string Image { get; set; }
}