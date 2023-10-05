namespace VLISSIDES.Models
{
    public class LivreAuteur
    {
        public string LivreId { get; set; } = default!;
        public Livre Livre { get; set; } = default!;
        public string AuteurId { get; set; } = default!;
        public Auteur Auteur { get; set; } = default!;
    }
}
