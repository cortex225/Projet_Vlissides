﻿//ViewModel pour _CarteEvenement.cshtml

using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class EventCardVM
{
    public EventCardVM(string image = "", string nom = "", string description = "")
    {
        Image = image;
        Nom = nom;
        Description = description;
    }

    public EventCardVM(Evenement evenement)
    {
        Image = evenement.Image;
        Nom = evenement.Nom;
        Description = evenement.Description;
    }

    [DisplayName("Image")] public string Image { get; set; }

    [DisplayName("NomAuteur")] public string Nom { get; set; }

    [DisplayName("Description")] public string Description { get; set; }
}