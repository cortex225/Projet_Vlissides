using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil
{
    public class _PromotionCardVM
    {
        public _PromotionCardVM(string description, decimal rabais, DateTime dateDebut, DateTime dateFin)
        {
            Description = description;
            Rabais = rabais;
            DateDebut = dateDebut;
            DateFin = dateFin;
        }
        public _PromotionCardVM(Promotions promotions)
        {
            Description = promotions.Description;
            Rabais = promotions.Rabais;
            DateDebut = promotions.DateDebut;
            DateFin = promotions.DateFin;
        }
        [DisplayName("Description")] public string Description { get; set; }
        [DisplayName("Rabais")] public decimal Rabais { get; set; }
        [DisplayName("Date de début")] public DateTime DateDebut { get; set; }
        [DisplayName("Date de fin")] public DateTime DateFin { get; set; }
    }
}
