using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class TypeLivreConfiguration : IEntityTypeConfiguration<TypeLivre>
{
    public void Configure(EntityTypeBuilder<TypeLivre> builder)
    {
        ((EntityTypeBuilder)builder).ToTable("TypeLivres");
        builder.HasKey(sc => sc.Id);
        builder.HasData(
            new TypeLivre
            {
                Id = "1",
                Nom = "Papier"
            },
            new TypeLivre
            {
                Id = "2",
                Nom = "Numérique"
            }
        );
    }
}