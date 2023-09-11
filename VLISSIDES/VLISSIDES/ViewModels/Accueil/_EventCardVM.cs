//ViewModel pour _CarteEvenement.cshtml

using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil
{
    public class _EventCardVM
    {
        public string Image { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        public _EventCardVM(string image = "", string nom = "", string description = "")
        {
            Image = image;
            Nom = nom;
            Description = description;
        }
        public _EventCardVM(Evenement evenement)
        {
            Image = evenement.Image;
            Nom = evenement.Nom;
            Description = evenement.Description;
        }
    }
}