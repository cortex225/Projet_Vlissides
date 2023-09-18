using System.ComponentModel;

namespace VLISSIDES.ViewModels.Accueil;

public class ServiceCardVM
{
    public ServiceCardVM(string image = "", string titre = "", string description = "", string icons = "")
    {
        Image = image;
        Titre = titre;
        Description = description;
        this.icons = icons;
    }

    [DisplayName("Image")] public string Image { get; set; }

    [DisplayName("Titre")] public string Titre { get; set; }

    [DisplayName("Description")] public string Description { get; set; }
    /*public ServiceCardVM(Service service)
    {
        Image = service.image;
        Description = service.description;
    }*/
    
    public string icons { get; set; }
}