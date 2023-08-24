namespace VLISSIDES.Models
{
    public class LivreCommande
    {
        public string Id { get; set; }
        public int LivreId { get; set; }
        public int CommandeId { get; set; }
        public int Quantite { get; set; }
        public decimal Prix { get; set; }
        public virtual Livre Livre { get; set; }
        public virtual Commande Commande { get; set; }
    }
}
