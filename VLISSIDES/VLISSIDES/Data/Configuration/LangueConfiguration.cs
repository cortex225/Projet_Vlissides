using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LangueConfiguration : IEntityTypeConfiguration<Langue>
{
    public void Configure(EntityTypeBuilder<Langue> builder)
    {
        builder.ToTable("Langues");
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).ValueGeneratedOnAdd();
        builder.Property(sc => sc.Nom).IsRequired().HasMaxLength(50);
        builder.HasData(
            new Langue
            {
                Id = "1",
                Nom = "Français",
                Code = "fr"
            },
            new Langue
            {
                Id = "2",
                Nom = "Anglais",
                Code = "en"
            }

        );
}
}