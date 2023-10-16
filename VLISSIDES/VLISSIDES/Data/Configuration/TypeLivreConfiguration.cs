using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class TypeLivreConfiguration : IEntityTypeConfiguration<TypeLivre>
{
    private readonly List<TypeLivre> typeLivres;

    public TypeLivreConfiguration(List<List<TypeLivre>> listTypeLivre)
    {
        this.typeLivres = new List<TypeLivre>();
        foreach (var typeLivres in listTypeLivre)
            this.typeLivres.AddRange(typeLivres);
    }

    public void Configure(EntityTypeBuilder<TypeLivre> builder)
    {
        ((EntityTypeBuilder)builder).ToTable("TypeLivres");
        builder.HasKey(sc => sc.Id);
        builder.HasData(typeLivres);
    }
}