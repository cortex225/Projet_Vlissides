using System.ComponentModel;

namespace VLISSIDES.ViewModels.Accueil;

public class MessageVM
{
    [DisplayName("Titre")] public string Titre { get; set; }
    [DisplayName("Message")] public string Message { get; set; }

    public MessageVM(string titre, string message)
    {
        Titre = titre;
        Message = message;
    }

}