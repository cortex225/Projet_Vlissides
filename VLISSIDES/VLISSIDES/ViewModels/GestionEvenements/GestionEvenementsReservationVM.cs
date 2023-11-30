using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionEvenements
{
    public class GestionEvenementsReservationVM
    {
        [DisplayName("Identifiant")] public string Id { get; set; }

        [DisplayName("Nom de l'utilisateur")] public string NomUtilisateur { get; set; }
        [DisplayName("Nom de l'évènement")] public string NomEvenement { get; set; }

        public GestionEvenementsReservationVM(Reservation reservation)
        {
            Id = reservation.Id;
            NomUtilisateur = reservation.Membre.Id;
            NomEvenement = reservation.Evenement.Nom;
        }
    }
}
