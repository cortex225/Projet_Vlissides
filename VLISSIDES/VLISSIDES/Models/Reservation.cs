using System;

namespace VLISSIDES.Models;

public class Reservation
{
    public string Id { get; set; }

    public DateTime DateReservation { get; set; }

    public string Description { get; set; }

    public string IdEvenement { get; set; }

    public Evenement Evenement { get; set; }

}