using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreAuteurConfiguration : IEntityTypeConfiguration<LivreAuteur>
{
    private List<LivreAuteur> LivreAuteur { get; set; }
    public LivreAuteurConfiguration(List<string> livreIds, List<string> auteurId)
    {
        LivreAuteur = new List<LivreAuteur>();
        foreach (var id in auteurId)
            LivreAuteur.Add(new() { LivreId = livreIds[auteurId.IndexOf(id)], AuteurId = id });
    }

    public void Configure(EntityTypeBuilder<LivreAuteur> builder)
    {
        builder.ToTable("Categories");
        builder.HasData(LivreAuteur);
    }
}