using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreMaisonEditionConfiguration : IEntityTypeConfiguration<LivreMaisonEdition>
{
    private List<LivreMaisonEdition> LivreMaisonEditions { get; set; }
    public LivreMaisonEditionConfiguration(List<string> livreIds, List<string> maisonEditionIds)
    {
        LivreMaisonEditions = new List<LivreMaisonEdition>();
        foreach (var id in maisonEditionIds)
            LivreMaisonEditions.Add(new() { LivreId = livreIds[maisonEditionIds.IndexOf(id)], auteurId = id });
    }

    public void Configure(EntityTypeBuilder<LivreMaisonEdition> builder)
    {
        builder.ToTable("Categories");
        builder.HasData(LivreMaisonEditions);
    }
}