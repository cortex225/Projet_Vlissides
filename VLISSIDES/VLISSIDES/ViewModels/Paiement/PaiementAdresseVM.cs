using System.ComponentModel;

namespace VLISSIDES.ViewModels.Paiement;

public class PaiementAdresseVM
{
    [DisplayName("Adresses Existantes")] public IEnumerable<AdresseVM>? AdressesExistantes { get; set; }

    [DisplayName("Nouvelle Adresse")] public AdresseVM NouvelleAdresse { get; set; }
}