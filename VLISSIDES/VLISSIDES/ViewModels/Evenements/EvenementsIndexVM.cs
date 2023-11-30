using System.ComponentModel;

namespace VLISSIDES.ViewModels.Evenements;

public class EvenementsIndexVM
{
    [DisplayName("Évènements")] public List<EvenementsVM> Evenements { get; set; }
    [DisplayName("Mes évènements")] public List<EvenementsVM> MesEvenements { get; set; }

    public EvenementsIndexVM(IEnumerable<EvenementsVM> evenements = null, IEnumerable<EvenementsVM> mesEvenements = null)
    {
        evenements ??= new List<EvenementsVM>();
        mesEvenements ??= new List<EvenementsVM>();
        Evenements = evenements.ToList();
        MesEvenements = mesEvenements.ToList();
    }
}