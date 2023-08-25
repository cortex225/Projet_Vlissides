using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class TypeLivreConfiguration : IEntityTypeConfiguration<Type>
{
    public void Configure(EntityTypeBuilder<Type> builder)
    {
        builder.ToTable("Types");
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).ValueGeneratedOnAdd();
        builder.HasData(
            new Models.Type()
            {
                Id = "1",
                Nom = "Neuf",
            },
            new Models.Type()
            {
                Id = "2",
                Nom = "Numérique",
            }
            
    );
}

}