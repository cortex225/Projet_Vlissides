using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreTypeLivreConfiguration : IEntityTypeConfiguration<LivreTypeLivre>
{
    // public LivreTypeLivreConfiguration(List<Livre> livres, List<List<TypeLivre>> listTypeLivres)
    // {
    //     LivreTypeLivres = new List<LivreTypeLivre>();
    //     foreach (var typeLivres in listTypeLivres)
    //     foreach (var typeLivre in typeLivres)
    //         LivreTypeLivres.Add(new LivreTypeLivre
    //             { LivreId = livres[listTypeLivres.IndexOf(typeLivres)].Id, TypeLivreId = typeLivre.Id });
    //     //Console.WriteLine(livres[listTypeLivres.IndexOf(typeLivres)].Id + "|" + typeLivre.Id);
    // }

    // private List<LivreTypeLivre> LivreTypeLivres { get; }

    public void Configure(EntityTypeBuilder<LivreTypeLivre> builder)
    {
        builder.ToTable("LivreTypeLivres");
        // builder.HasData(LivreTypeLivres);
    }
}