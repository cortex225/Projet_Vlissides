using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionPromotions;

public class GestionPromotionsIndexVM
{
    public string Id { get; set; }

    public string Nom { get; set; }
    public string Description { get; set; }

    public decimal Rabais { get; set; }

    public DateTime DateDebut { get; set; }

    public DateTime? DateFin { get; set; }

    public string? Image { get; set; }

    public string? TypePromotion { get; set; }


}