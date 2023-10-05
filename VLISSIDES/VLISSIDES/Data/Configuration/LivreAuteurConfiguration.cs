using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreAuteurConfiguration : IEntityTypeConfiguration<LivreAuteur>
{
    public LivreAuteurConfiguration(List<Livre> livres, List<IEnumerable<string>> listAuteurs)
    {
        LivreAuteurs = new List<LivreAuteur>();
        foreach (var auteurs in listAuteurs)
        foreach (var auteur in auteurs)
            LivreAuteurs.Add(new LivreAuteur { LivreId = livres[listAuteurs.IndexOf(auteurs)].Id, AuteurId = auteur });
    }

    private List<LivreAuteur> LivreAuteurs { get; }

    public void Configure(EntityTypeBuilder<LivreAuteur> builder)
    {
        builder.ToTable("LivreAuteurs");
        builder.HasData(LivreAuteurs);
    }
}