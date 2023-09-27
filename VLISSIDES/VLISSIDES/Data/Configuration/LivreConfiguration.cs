using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;
using System.Text;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class LivreConfiguration : IEntityTypeConfiguration<Livre>
{
    public void Configure(EntityTypeBuilder<Livre> builder)
    {
        builder.ToTable("Livres");
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).ValueGeneratedOnAdd();
        #region Prendre les données de la feuille excel
        List<string> titres;
        List<string> auteurs;
        List<string> maisonEditions;
        List<int> pages;
        List<string> isbns;
        List<Image> couvertures;
        List<string> categories;
        List<bool> papiers;
        List<double> prixPapiers;
        List<int> quantites;
        List<bool> numeriques;
        List<double> prixNumeriques;
        ReadPdf("Data/DonneesLivres.xlsx", out titres, out auteurs, out maisonEditions, out pages, out isbns, out couvertures, out categories, out papiers,
            out prixPapiers, out quantites, out numeriques, out prixNumeriques);
        #endregion
        if (titres.Any()) return;
        for (int compteur = 0; compteur < titres.Count(); compteur++)
            builder.HasData(
                new Livre()
                {
                    Titre = titres[compteur],
                    //Auteurs = auteurs[compteur],
                    //MaisonEdition = maisonEditions[compteur],
                    NbPages = pages[compteur],
                    ISBN = isbns[compteur],
                    //Couverture = couvertures[compteur],
                    //Categories = categories[compteur],
                    //TypesLivre = papiers[compteur],
                    NbExemplaires = quantites[compteur],
                    Prix = prixPapiers[compteur]
                });
    }
    public void ReadPdf(string url, out List<string> titres, out List<string> auteurs, out List<string> maisonEditions,
    out List<int> pages, out List<string> isbns, out List<Image> couvertures, out List<string> categories, out List<bool> papiers,
    out List<double> prixPapiers, out List<int> quantites, out List<bool> numeriques, out List<double> prixNumeriques)
    {
        url ??= "";
        titres = new();
        auteurs = new();
        maisonEditions = new();
        pages = new();
        isbns = new();
        couvertures = new();
        categories = new();
        papiers = new();
        prixPapiers = new();
        quantites = new();
        numeriques = new();
        prixNumeriques = new();
        //Permet l'encodage pour "encoding 1252."
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        //Lire la page excel
        using (var stream = File.Open(url, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                reader.Read();
                while (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("-Titre-----------------------------------------------------------\n" + reader.GetString(0));
                        titres.Add(reader.GetString(0).Trim());
                        Console.WriteLine("\n-Auteur----------------------------------------------------------\n" + reader.GetString(1));
                        auteurs.Add(reader.GetString(1).Trim());
                        Console.WriteLine("\n-Edition---------------------------------------------------------\n" + reader.GetString(2));
                        maisonEditions.Add(reader.GetString(2).Trim());
                        Console.WriteLine("\n-Page---------------------------------------------------------\n" + reader.GetDouble(3));
                        pages.Add((int)reader.GetDouble(3));
                        try
                        {
                            Console.WriteLine("\n-Isbns--------------------------------------------------------\n"
                                + reader.GetDouble(4));
                            isbns.Add(reader.GetDouble(4).ToString().Trim());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\n-Isbns--------------------------------------------------------\n"
                                + reader.GetString(4));
                            isbns.Add(reader.GetString(4).Trim());
                        }
                        Console.WriteLine("\n-Couverture---------------------------------------------------\n");
                        Console.WriteLine(reader.GetFieldType(5));
                        //couvertures.Add(reader.GetValue(5) as Image);
                        Console.WriteLine("\n-Catégorie----------------------------------------------------\n" + reader.GetString(6));
                        categories.Add(reader.GetString(6).Trim());
                        Console.WriteLine("\n-Papier-------------------------------------------------------\n" + reader.GetString(7)
                            + reader.GetString(7) == null ? "false" : "true");
                        papiers.Add(reader.GetString(7) == null ? false : true);
                        if (papiers.Last())
                        {
                            Console.WriteLine("\n-Prix papier--------------------------------------------------\n" + reader.GetDouble(8));
                            prixPapiers.Add(reader.GetDouble(8));
                        }
                        Console.WriteLine("\n-Quantité-----------------------------------------------------\n" + reader.GetDouble(9));
                        quantites.Add((int)reader.GetDouble(9));
                        Console.WriteLine("\n-Numérique----------------------------------------------------\n" + reader.GetString(10)
                            + reader.GetString(10) == null ? "false" : "true");
                        numeriques.Add(reader.GetString(10) == null ? false : true);
                        if (numeriques.Last())
                        {
                            Console.WriteLine("\n-Prix numérique-----------------------------------------------\n" + reader.GetDouble(11));
                            prixNumeriques.Add(reader.GetDouble(11));
                        }
                    }
                }
            }
        }
    }
    /*public void exemple()
    {
        Categorie categorie = new();
        List<Categorie> categories = new();
        List<Livre> livres = new();
        categories.Add(categorie);
        AjouterCategoriesEnfants(categorie);
        if (!categories.Contains(categorie.Parent)) categories.Add(categorie.Parent);
        AjouterCategoriesEnfants(categorie.Parent);
        livres.Sort((a, b) =>
        {
            List<Categorie> ac = a.Categories.ToList();
            List<Categorie> bc = b.Categories.ToList();
            foreach (var c in categories)
            {
                if (ac.Contains(c) && bc.Contains(c)) ;
                else
                if (ac.Contains(c)) return 1;
                else
                if (bc.Contains(c)) return -1;
            }
            return 0;
        });
        void AjouterCategoriesEnfants(Categorie categoriec)
        {
            List<Categorie> SousCategories = new(categorie.Enfants);

            while (!SousCategories.Any())
            {
                List<Categorie> SousCategoriestraite = SousCategories;
                SousCategories.Clear();
                foreach (var sc in SousCategories)
                {
                    SousCategories.Add(sc);
                    foreach (var c in sc.Enfants) if (!(categories.Any(c) || SousCategoriestraite.Any(c) || SousCategories.Any(c)))
                            SousCategoriestraite.Add(c);
                    categories.AddRange(SousCategoriestraite);
                }
            }
        }
    }*/
}