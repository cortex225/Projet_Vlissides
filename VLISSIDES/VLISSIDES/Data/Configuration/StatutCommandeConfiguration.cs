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
        builder.Property(sc => sc.Nom).IsRequired().HasMaxLength(50);
        builder.HasData(
            new StatutCommande
            {
                Id = "1",
                Nom = "En attente"
            },
            new StatutCommande
            {
                Id = "2",
                Nom = "En cours de traitement"
            },
            new StatutCommande
            {
                Id = "3",
                Nom = "En cours de livraison"
            },
            new StatutCommande
            {
                Id = "4",
                Nom = "Livrée"
            },
            new StatutCommande
            {
                Id = "5",
                Nom = "Annulée"
            }
        );
    }
}