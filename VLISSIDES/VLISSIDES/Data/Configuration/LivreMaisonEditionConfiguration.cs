using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreMaisonEditionConfiguration : IEntityTypeConfiguration<LivreMaisonEdition>
{
    // public LivreMaisonEditionConfiguration(List<string> livreIds, List<string> maisonEditionIds)
    // {
    //     LivreMaisonEditions = new List<LivreMaisonEdition>();
    //     foreach (var id in maisonEditionIds)
    //         LivreMaisonEditions.Add(new LivreMaisonEdition
    //             { LivreId = livreIds[maisonEditionIds.IndexOf(id)], auteurId = id });
    // }

    // private List<LivreMaisonEdition> LivreMaisonEditions { get; }

    public void Configure(EntityTypeBuilder<LivreMaisonEdition> builder)
    {
        builder.ToTable("Categories");
        // builder.HasData(LivreMaisonEditions);
    }
}