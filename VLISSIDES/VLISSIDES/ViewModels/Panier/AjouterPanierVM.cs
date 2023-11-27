using System.ComponentModel;

namespace VLISSIDES.ViewModels.Panier;

public class AjouterPanierVM
{
    [DisplayName("Identifiant du livre")] public string? LivreId { get; set; }
    [DisplayName("Quantitée")] public int? Quantitee { get; set; }
    [DisplayName("Identifiant du type")] public string? TypeId { get; set; }

    public AjouterPanierVM(string? livreAjouteId, int? quantitee, string? typeId)
    {
        LivreId = livreAjouteId;
        Quantitee = quantitee;
        TypeId = typeId;
    }
}