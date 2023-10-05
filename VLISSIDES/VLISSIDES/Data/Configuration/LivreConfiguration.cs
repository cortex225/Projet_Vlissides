using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreConfiguration : IEntityTypeConfiguration<Livre>
{
    private List<Livre> livres;

    public LivreConfiguration(List<Livre> livres, List<MaisonEdition> maisonEditions)
    {
        this.livres = new();
        foreach (var livre in livres)
        {
            this.livres.Add(new()
            {
                Id = livre.Id,
                Titre = livre.Titre,
                MaisonEditionId = maisonEditions[livres.IndexOf(livre)].Id,
                Resume = "",
                DateAjout = DateTime.Now,
                LangueId = null,
                NbPages = livre.NbPages,
                ISBN = livre.ISBN,
                Couverture = livre.Couverture,
                NbExemplaires = livre.NbExemplaires,
            });
        }
        foreach (var livre in this.livres)
            Console.WriteLine(livre.Id + " : " + livre.Titre);
    }

    public void Configure(EntityTypeBuilder<Livre> builder)
    {

        builder.ToTable("Livres");
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).ValueGeneratedOnAdd();
        builder.HasData(livres);
    }
}