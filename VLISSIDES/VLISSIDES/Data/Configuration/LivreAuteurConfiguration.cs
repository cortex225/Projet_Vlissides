using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreAuteurConfiguration : IEntityTypeConfiguration<LivreAuteur>
{
    private List<LivreAuteur> LivreAuteur { get; set; }
    public LivreAuteurConfiguration(List<Livre> livres, List<IEnumerable<string>> listAuteurs)
    {
        LivreAuteur = new List<LivreAuteur>();
        foreach (var auteurs in listAuteurs)
            foreach (var auteur in auteurs)
                LivreAuteur.Add(new() { LivreId = livres[listAuteurs.IndexOf(auteurs)].Id, AuteurId = auteur });
    }

    public void Configure(EntityTypeBuilder<LivreAuteur> builder)
    {
        builder.ToTable("LivreAuteurs");
        builder.HasKey(sc => sc.LivreId);
        builder.Property(sc => sc.LivreId).ValueGeneratedOnAdd();
        builder.HasKey(sc => sc.AuteurId);
        builder.Property(sc => sc.AuteurId).ValueGeneratedOnAdd();
        builder.HasData(LivreAuteur);
    }
}