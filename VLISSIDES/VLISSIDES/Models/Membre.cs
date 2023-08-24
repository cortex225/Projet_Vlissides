using System;
using System.Collections.Generic;

namespace VLISSIDES.Models;

public class Membre: ApplicationUser
{
    public string NumeroMembre { get; set; }
    
    public DateTime DateAdhesion { get; set; }
    
    public string IdCommande { get; set; }
    
    public List<Commande> Commandes { get; set; }
    
    public string IdReservation { get; set; }
    
    public List<Reservation> Reservations { get; set; }
    
}