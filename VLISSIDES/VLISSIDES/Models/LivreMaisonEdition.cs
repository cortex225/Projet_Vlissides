namespace VLISSIDES.Models
{
    public class LivreMaisonEdition
    {
        public string LivreId { get; set; } = default!;
        public Livre Livre { get; set; } = default!;
        public string auteurId { get; set; } = default!;
        public MaisonEdition MaisonEdition { get; set; } = default!;
    }
}
