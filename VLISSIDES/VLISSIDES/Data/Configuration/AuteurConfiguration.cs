using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class AuteurConfiguration : IEntityTypeConfiguration<Auteur>
{
    private readonly List<Auteur> auteurs;


    public AuteurConfiguration(List<List<Auteur>> listAuteurs, out List<IEnumerable<string>> listIdfinal)
    {
        this.auteurs = new List<Auteur>();
        listIdfinal = new List<IEnumerable<string>>();
        foreach (var auteurs in listAuteurs)
        foreach (var auteur in auteurs)
            if (!this.auteurs.Any(a => a.NomAuteur.Equals(auteur.NomAuteur)))
                this.auteurs.Add(auteur);

        foreach (var auteurs in listAuteurs)
            listIdfinal.Add(auteurs.Select(a =>
                a.Id = this.auteurs.First(thisA => thisA.NomAuteur.Equals(a.NomAuteur)).Id));
        //foreach (var auteur in this.auteurs)
        //    Console.WriteLine(auteur.Id + " : " + auteur.NomAuteur);
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