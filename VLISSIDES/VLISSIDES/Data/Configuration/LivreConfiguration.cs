using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreConfiguration : IEntityTypeConfiguration<Livre>
{
    public string Titre { get; set; }
    public ICollection<Auteur> Auteurs { get; set; }
    public MaisonEdition MaisonEdition { get; set; }
    public int NombresPages { get; set; }
    public string ISBN { get; set; }
    public Bitmap Couverture { get; set; }
    public ICollection<Categorie> Categories { get; set; }
    public TypeLivre TypeLivre { get; set; }
    public int Quantité { get; set; }
    public double Prix { get; set; }

    public LivreConfiguration(string titre, ICollection<Auteur> auteurs, MaisonEdition maisonEdition, int nombresPages, string iSBN,
        Bitmap couverture, ICollection<Categorie> categories, TypeLivre typeLivre, int quantité, double prix)
    {
        Titre = titre;
        Auteurs = auteurs;
        MaisonEdition = maisonEdition;
        NombresPages = nombresPages;
        ISBN = iSBN;
        Couverture = couverture;
        Categories = categories;
        TypeLivre = typeLivre;
        Quantité = quantité;
        Prix = prix;
    }

    public void Configure(EntityTypeBuilder<Livre> builder)
    {
        builder.ToTable("Livres");
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).ValueGeneratedOnAdd();
        builder.HasData(
            new Livre()
            {
                Titre = Titre,
                Auteurs = Auteurs,
                MaisonEdition = MaisonEdition,
                NbPages = NombresPages,
                ISBN = ISBN,
                Couverture = Couverture.ToString() ?? "",
                Categories = Categories,
                TypesLivre = TypeLivre,
                NbExemplaires = Quantité,
                Prix = Prix
            });
    }
}