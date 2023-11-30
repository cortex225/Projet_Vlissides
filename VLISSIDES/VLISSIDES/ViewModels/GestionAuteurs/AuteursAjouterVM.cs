using System.ComponentModel;

namespace VLISSIDES.ViewModels.GestionAuteurs;

public class AuteursAjouterVM
{
    [DisplayName("Nom")] public string Nom { get; set; }

    public AuteursAjouterVM()
    {
        Nom = "";
    }
}