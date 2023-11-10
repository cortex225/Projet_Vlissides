using System.ComponentModel;

namespace VLISSIDES.ViewModels.Evenements
{
    public class EvenementsVM
    {
        public string Id { get; set; } = default!;

        [DisplayName("Nom")] public string Nom { get; set; } = default!;

        [DisplayName("Description")] public string Description { get; set; } = default!;

        [DisplayName("Image")] public string Image { get; set; } = default!;

        [DisplayName("Date de début")] public DateTime DateDebut { get; set; } = default!;

        [DisplayName("Date de fin")] public DateTime DateFin { get; set; } = default!;

        [DisplayName("Lieu")] public string Lieu { get; set; } = default!;

        [DisplayName("Nombre de places total")]
        public string NbPlaces { get; set; } = default!;

        [DisplayName("Nombre de places destinés aux membres")]
        public string NbPlacesMembre { get; set; } = default!;

        [DisplayName("Nombre de places réservées ")]
        public string NbPlacesReservees { get; set; } = default!;

        [DisplayName("Prix")] public decimal? Prix { get; set; } = default!;
    }
}
