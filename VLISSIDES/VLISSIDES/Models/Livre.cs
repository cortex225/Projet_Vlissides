namespace VLISSIDES.Models;

public class Livre
{
    public string Id { get; set; }

    public string Titre { get; set; }

    public string Auteur { get; set; }

    public string Editeur { get; set; }

    public string AnneeEdition { get; set; }

    public string Resume { get; set; }

    public string Image { get; set; }

    public int NbExemplaires { get; set; }

    public int NbPages { get; set; }

    public string Description { get; set; }

    public DateTime DatePublication { get; set; }

    public string ISBN { get; set; }

    public string CategorieId { get; set; }

    public List<Categorie> Categories { get; set; }

    public string TypeId { get; set; }

    public List<TypeLivre> Types { get; set; }

    public string IdCommentaire { get; set; }

    public List<Commentaire> Commentaires { get; set; }

    public string IdLangue { get; set; }

    public List<Langue> Langues { get; set; }
}