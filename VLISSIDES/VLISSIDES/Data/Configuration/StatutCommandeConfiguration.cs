using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class StatutCommandeConfiguration : IEntityTypeConfiguration<StatutCommande>
{
    
    public void Configure(EntityTypeBuilder<StatutCommande> builder)
    {
        builder.ToTable("StatutCommande");
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).ValueGeneratedOnAdd();
        builder.Property(sc => sc.Description).IsRequired().HasMaxLength(50);
        builder.HasData(
            new StatutCommande
            {
                Id = "1",
                Description = "En attente"
            },
            new StatutCommande
            {
                Id = "2",
                Description = "En cours de traitement"
            },
            new StatutCommande
            {
                Id = "3",
                Description = "En cours de livraison"
            },
            new StatutCommande
            {
                Id = "4",
                Description = "Livrée"
            },
            new StatutCommande
            {
                Id = "5",
                Description = "Annulée"
            }
        );
    }
    
}