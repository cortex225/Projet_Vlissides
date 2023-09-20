using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.MaisonEditions
{
    public class MaisonEditionsIndexVM
    {
        public MaisonEditionsAjouterVM? MaisonEditionsAjouterVM { get; set; }

        public List<MaisonEdition>? ListeMaisonEditions { get; set; }
    }
}