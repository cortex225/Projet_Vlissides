//ViewModel pour _CarteLivre.cshtml et CarteLivrePetit.cshtml

using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class _LivreCardVM
{
    public Livre monLivre { get; set; } = new();
}