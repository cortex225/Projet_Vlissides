using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class AuteurConfiguration : IEntityTypeConfiguration<Auteur>
{
    private List<Auteur> auteurs;


    public AuteurConfiguration(List<string> auteurs, List<string> ids)
    {
        this.auteurs = new();
        foreach (var auteur in auteurs)
        {
            if (!this.auteurs.Any(a => a.NomAuteur.Equals(auteur)))
                this.auteurs.Add(new()
                {
                    Id = ids[auteurs.IndexOf(auteur)],
                    NomAuteur = auteur
                });
        }
        foreach (var auteur in this.auteurs)
            Console.WriteLine(auteur.Id + " : " + auteur.NomAuteur);
    }

    public void Configure(EntityTypeBuilder<Auteur> builder)
    {
        builder.ToTable("Auteurs");
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).ValueGeneratedOnAdd();
        foreach (var auteur in auteurs)
            builder.HasData(auteur);
    }
}