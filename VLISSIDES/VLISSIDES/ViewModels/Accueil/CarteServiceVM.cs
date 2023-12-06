using System.ComponentModel;

namespace VLISSIDES.ViewModels.Accueil;

public class CarteServiceVM
{
    [DisplayName("Image")] public string Image { get; set; }

    [DisplayName("Titre")] public string Titre { get; set; }

    [DisplayName("Description")] public string Description { get; set; }
    [DisplayName("Icons")] public string Icones { get; set; }
    public CarteServiceVM(string image = "", string titre = "", string description = "", string icones = "")
    {
        Image = image;
        Titre = titre;
        Description = description;
        Icones = icones;
    }

}