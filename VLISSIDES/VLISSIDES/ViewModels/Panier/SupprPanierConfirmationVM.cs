namespace VLISSIDES.ViewModels.Panier;

public class SupprPanierConfirmationVM
{
    public string Id { get; set; }
    public string Titre { get; set; }

    public SupprPanierConfirmationVM(string id, string titre)
    {
        Id = id;
        Titre = titre;
    }
}