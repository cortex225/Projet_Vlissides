using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreConfiguration : IEntityTypeConfiguration<Livre>
{
    private List<Livre> livres;

    public LivreConfiguration(List<string> titres, List<string> auteurIds, List<int> pages, List<string> ISBNs, List<string> couvertures,
        List<int> quantites, List<string> typeLivreIds, List<double> prix)
    {
        livres = new();
        foreach (var titre in titres)
        {
            livres.Add(new()
            {
                Id = "Excel " + titres.IndexOf(titre),
                Titre = titre,
                Resume = "",
                NbPages = pages[titres.IndexOf(titre)],
                ISBN = ISBNs[titres.IndexOf(titre)],
                Couverture = couvertures[titres.IndexOf(titre)],
                NbExemplaires = quantites[titres.IndexOf(titre)],
                TypeLivreId = typeLivreIds[titres.IndexOf(titre)],
                Prix = prix[titres.IndexOf(titre)]
            });
        }
        foreach (var livre in livres)
            Console.WriteLine(livre.Id + " : " + livre.Titre);
    }

    public void Configure(EntityTypeBuilder<Livre> builder)
    {

        builder.ToTable("Livres");
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).ValueGeneratedOnAdd();
        foreach (var livre in livres)
            builder.HasData(livre);
    }
}