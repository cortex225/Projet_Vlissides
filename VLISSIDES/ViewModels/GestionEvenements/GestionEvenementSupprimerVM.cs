using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionEvenements;

public class GestionEvenementSupprimerVM
{
    [DisplayName("Identifiant")] public string Id { get; set; }
    [DisplayName("Nom")] public string Nom { get; set; }

    public GestionEvenementSupprimerVM()
    {
        Id = "";
        Nom = "";
    }
    public GestionEvenementSupprimerVM(Evenement evenement)
    {
        Id = evenement.Id;
        Nom = evenement.Nom;
    }
}