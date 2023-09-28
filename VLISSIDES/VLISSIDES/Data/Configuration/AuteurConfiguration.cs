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
            if (!this.auteurs.Any(a => a.NomComplet.Equals(auteur)))
                this.auteurs.Add(new()
                {
                    Id = ids[auteurs.IndexOf(auteur)],
                    Prenom = auteur.Split(" ").Count() > 1 ? auteur.Split(" ")[0] : auteur,
                    Nom = auteur.Split(" ").Count() > 1 ? auteur.Substring(auteur.Split(" ")[0].Count()).Trim() : ""
                });
        }
        foreach (var auteur in this.auteurs)
            Console.WriteLine(auteur.Id + " : " + auteur.NomComplet);
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