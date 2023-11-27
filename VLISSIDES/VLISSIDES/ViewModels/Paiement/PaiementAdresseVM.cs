using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Paiement;

public class PaiementAdresseVM
{
    [DisplayName("Adresses Existantes")] public IEnumerable<AdresseVM>? AdressesExistantes { get; set; }

    [DisplayName("Nouvelle Adresse")] public AdresseVM NouvelleAdresse { get; set; }

    public PaiementAdresseVM(IEnumerable<Adresse> adresseExistantes, Adresse nouvelleAdresse)
    {
        AdressesExistantes = adresseExistantes.Select(ae => new AdresseVM(ae));
        NouvelleAdresse = new(nouvelleAdresse);
    }
}