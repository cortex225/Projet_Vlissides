using System.ComponentModel;

namespace VLISSIDES.ViewModels.Accueil
{

    public class _ServiceCardVM
    {
        [DisplayName("Image")]
        public string Image { get; set; }
        [DisplayName("Titre")]
        public string Titre { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }

        public _ServiceCardVM(string image = "", string titre = "", string description = "")
        {
            Image = image;
            Titre = titre;
            Description = description;
        }
        /*public ServiceCardVM(Service service)
        {
            Image = service.image;
            Description = service.description;
        }*/
    }
}