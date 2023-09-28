using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class MaisonEditionsConfiguration : IEntityTypeConfiguration<MaisonEdition>
{
    private List<MaisonEdition> maisonEditions;


    public MaisonEditionsConfiguration(List<string> maisonEditions, List<string> ids)
    {
        this.maisonEditions = new();
        foreach (var maisonEdition in maisonEditions)
        {
            if (!this.maisonEditions.Any(me => me.Nom.Equals(maisonEdition)))
                this.maisonEditions.Add(new()
                {
                    Id = ids[maisonEditions.IndexOf(maisonEdition)],
                    Nom = maisonEdition
                });
        }
        foreach (var maisonEdition in this.maisonEditions)
            Console.WriteLine(maisonEdition.Id + " : " + maisonEdition.Nom);
    }

    public void Configure(EntityTypeBuilder<MaisonEdition> builder)
    {
        builder.ToTable("MaisonEditions");
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).ValueGeneratedOnAdd();
        foreach (var maisonEdition in maisonEditions)
            builder.HasData(maisonEdition);
    }
}