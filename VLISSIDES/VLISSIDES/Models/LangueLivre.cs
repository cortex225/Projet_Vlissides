using System.ComponentModel;

namespace VLISSIDES.Models;

public class LangueLivre
{
    public string LangueId { get; set; } = default!;
    public Langue Langue { get; set; } = default!;

    public string LivreId { get; set; } = default!;
    public Livre Livre { get; set; } = default!;

    [DisplayName("Nombre d'exemplaires disponibles")]
    public int? NbExemplaires { get; set; } = default!;
    
}