using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreCategorieConfiguration : IEntityTypeConfiguration<LivreCategorie>
{
    private List<LivreCategorie> LivreCategories { get; set; }
    public LivreCategorieConfiguration(List<string> livreIds, List<string> categorieids)
    {
        LivreCategories = new List<LivreCategorie>();
        foreach (var id in categorieids)
            LivreCategories.Add(new() { LivreId = livreIds[categorieids.IndexOf(id)], CategorieId = id });
    }

    public void Configure(EntityTypeBuilder<LivreCategorie> builder)
    {
        builder.ToTable("Categories");
        //foreach (var categorie in categories)
        builder.HasData(LivreCategories);
    }
}