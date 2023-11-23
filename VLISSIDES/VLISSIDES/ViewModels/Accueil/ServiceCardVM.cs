﻿using System.ComponentModel;

namespace VLISSIDES.ViewModels.Accueil;

public class ServiceCardVM
{
    [DisplayName("Image")] public string Image { get; set; }

    [DisplayName("Titre")] public string Titre { get; set; }

    [DisplayName("Description")] public string Description { get; set; }
    [DisplayName("Icons")] public string Icons { get; set; }
    public ServiceCardVM(string image = "", string titre = "", string description = "", string icons = "")
    {
        Image = image;
        Titre = titre;
        Description = description;
        this.Icons = icons;
    }

}