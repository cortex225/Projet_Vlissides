﻿using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Profile
{
    public class ProfileModifierAdressesVM
    {
        public string Id { get; set; }
        public Adresse? AdressePrincipale { get; set; }
        public List<Adresse>? AdressesDeLivraison { get; set; }

    }
}
