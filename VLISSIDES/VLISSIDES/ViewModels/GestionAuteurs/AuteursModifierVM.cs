using System.ComponentModel;

namespace VLISSIDES.ViewModels.GestionAuteurs;

public class AuteursModifierVM
{
    [DisplayName("Identifiant")] public string Id { get; set; }
    [DisplayName("Nom")] public string Nom { get; set; }
}