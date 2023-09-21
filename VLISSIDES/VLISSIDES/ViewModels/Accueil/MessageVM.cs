namespace VLISSIDES.ViewModels.Accueil;

public class MessageVM
{
    public MessageVM(string tittre, string message)
    {
        Tittre = tittre;
        Message = message;
    }

    public string Tittre { get; set; }
    public string Message { get; set; }
}