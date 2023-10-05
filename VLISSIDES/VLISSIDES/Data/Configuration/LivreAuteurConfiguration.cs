using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreAuteurConfiguration : IEntityTypeConfiguration<LivreAuteur>
{
    private List<LivreAuteur> LivreAuteurs { get; set; }
    public LivreAuteurConfiguration(List<Livre> livres, List<IEnumerable<string>> listAuteurs)
    {
        LivreAuteurs = new List<LivreAuteur>();
        foreach (var auteurs in listAuteurs)
            foreach (var auteur in auteurs)
                LivreAuteurs.Add(new() { LivreId = livres[listAuteurs.IndexOf(auteurs)].Id, AuteurId = auteur });
    }

    public void Configure(EntityTypeBuilder<LivreAuteur> builder)
    {
        builder.ToTable("LivreAuteurs");
        builder.HasData(LivreAuteurs);
    }
}