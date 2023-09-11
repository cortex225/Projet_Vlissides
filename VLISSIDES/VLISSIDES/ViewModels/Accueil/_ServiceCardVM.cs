namespace VLISSIDES.ViewModels.Accueil
{

    public class _ServiceCardVM
    {
        public string Image { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }

        public _ServiceCardVM(string image = "", string titre = "", string description = "")
        {
            Image = image;
            Titre = titre;
            Description = description;
        }
        /*public ServiceCardVM(Service service)
        {
            Image = service.image;
            Description = service.description;
        }*/
    }
}