using System.ComponentModel;

namespace VLISSIDES.Models
{
    public class LivreTypeLivre
    {
        [DisplayName("Prix")] public decimal Prix { get; set; } = default!;
        public string LivreId { get; set; } = default!;
        public Livre Livre { get; set; } = default!;
        public string TypeLivreId { get; set; } = default!;
        public TypeLivre TypeLivre { get; set; } = default!;
    }
}
