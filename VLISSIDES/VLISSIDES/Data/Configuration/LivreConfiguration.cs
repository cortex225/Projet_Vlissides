using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreConfiguration : IEntityTypeConfiguration<Livre>
{
    private List<Livre> livres;

    public LivreConfiguration(List<string> titres, List<string> maisonEditionIds, List<int> pages, List<string> ISBNs, List<string> couvertures,
        List<int> quantites, out List<string> livreIds)
    {
        livres = new();
        foreach (var titre in titres)
        {
            var id = titres.IndexOf(titre);
            livres.Add(new()
            {
                Id = "Excel " + id,
                Titre = titre,
                MaisonEditionId = maisonEditionIds[id],
                Resume = "",
                DateAjout = DateTime.Now,
                LangueId = null,
                NbPages = pages[id],
                ISBN = ISBNs[id],
                Couverture = couvertures[id],
                NbExemplaires = quantites[id],
            });
        }
        livreIds = livres.Select(l => l.Id).ToList();
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