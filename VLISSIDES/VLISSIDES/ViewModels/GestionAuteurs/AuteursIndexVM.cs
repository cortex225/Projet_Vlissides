using System.ComponentModel;

namespace VLISSIDES.ViewModels.GestionAuteurs;

public class AuteursIndexVM
{
    [DisplayName("Auteurs")] public List<AuteursAfficherVM>? Auteurs { get; set; }
    [DisplayName("Auteur ajouter")] public AuteursAjouterVM? AuteurAjouter { get; set; }

    public AuteursIndexVM(List<AuteursAfficherVM>? auteurs, AuteursAjouterVM? auteurAjouter)
    {
        Auteurs = auteurs;
        AuteurAjouter = auteurAjouter;
    }
}