using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionCommandes;

public class LivreCommandeVM
{
    public Livre Livre { get; set; } = default!;

    public string CommandeId { get; set; } = default!;

    public int Quantite { get; set; } = default!;

    public double PrixAchat { get; set; } = default!;

    public bool EnDemandeRetourner { get; set; } = default!;
}