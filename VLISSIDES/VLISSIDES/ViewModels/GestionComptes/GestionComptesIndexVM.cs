using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionComptes;

public class GestionComptesIndexVM
{
    [DisplayName("Nembres")] public List<GestionComptesMembreVM> Membres { get; set; }
    [DisplayName("Employe")] public List<GestionComptesEmployeVM> Employes { get; set; }
    [DisplayName("Admin")] public List<GestionComptesAdminVM> Admins { get; set; }

    public GestionComptesIndexVM(IEnumerable<Membre> membres, IEnumerable<Employe> employes,
        IEnumerable<ApplicationUser> admins)
    {
        Membres = membres.Select(m => new GestionComptesMembreVM(m)).ToList();
        Employes = employes.Select(e => new GestionComptesEmployeVM(e)).ToList();
        Admins = admins.Select(u => new GestionComptesAdminVM(u)).ToList();
    }
}