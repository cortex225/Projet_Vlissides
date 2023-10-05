using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreCategorieConfiguration : IEntityTypeConfiguration<LivreCategorie>
{
    public LivreCategorieConfiguration(List<Livre> livres, List<IEnumerable<string>> listCategories)
    {
        LivreCategories = new List<LivreCategorie>();
        foreach (var categories in listCategories)
        foreach (var categorie in categories)
            LivreCategories.Add(new LivreCategorie
                { LivreId = livres[listCategories.IndexOf(categories)].Id, CategorieId = categorie });
    }

    private List<LivreCategorie> LivreCategories { get; }

    public void Configure(EntityTypeBuilder<LivreCategorie> builder)
    {
        builder.ToTable("LivreCategories");
        builder.HasKey(sc => sc.LivreId);
        builder.Property(sc => sc.LivreId).ValueGeneratedOnAdd();
        builder.HasKey(sc => sc.CategorieId);
        builder.Property(sc => sc.CategorieId).ValueGeneratedOnAdd();
        builder.HasData(LivreCategories);
    }
}