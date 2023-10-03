using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreTypeLivreConfiguration : IEntityTypeConfiguration<LivreTypeLivre>
{
    private List<LivreTypeLivre> LivreTypeLivres { get; set; }
    public LivreTypeLivreConfiguration(List<string> livreIds, List<string> typeLivreIds)
    {
        LivreTypeLivres = new List<LivreTypeLivre>();
        foreach (var id in typeLivreIds)
            LivreTypeLivres.Add(new() { LivreId = livreIds[typeLivreIds.IndexOf(id)], TypeLivreId = id });
    }

    public void Configure(EntityTypeBuilder<LivreTypeLivre> builder)
    {
        builder.ToTable("Categories");
        //foreach (var categorie in categories)
        builder.HasData(LivreTypeLivres);
    }
}