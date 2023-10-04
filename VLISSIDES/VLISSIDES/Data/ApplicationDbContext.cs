using ExcelDataReader;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    #region DbSet
    public DbSet<Adresse> Adresses { get; set; }

    public DbSet<Commande> Commandes { get; set; }

    public DbSet<Employe> Employes { get; set; }

    public DbSet<Auteur> Auteurs { get; set; }

    public DbSet<Membre> Membres { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<Evenement> Evenements { get; set; }

    public DbSet<Evaluation> Evaluations { get; set; }

    public DbSet<Livre> Livres { get; set; }

    public DbSet<Categorie> Categories { get; set; }

    public DbSet<LivreCommande> LivreCommandes { get; set; }

    public DbSet<StatutCommande> StatutCommandes { get; set; }

    public DbSet<TypeLivre> TypeLivres { get; set; }

    public DbSet<Favori> Favoris { get; set; }

    public DbSet<Langue> Langues { get; set; }

    public DbSet<MaisonEdition> MaisonEditions { get; set; }

    public DbSet<Promotions> Promotions { get; set; }

    public DbSet<LivreAuteur> LivreAuteurs { get; set; }
    public DbSet<LivreCategorie> LivreCategories { get; set; }
    public DbSet<LivreTypeLivre> LivreTypeLivres { get; set; }
    #endregion


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        #region configuration
        #region Prendre les données de la feuille excel
        List<Livre> livres;
        List<List<Auteur>> auteurs;
        List<IEnumerable<string>> auteurIds = new();
        List<MaisonEdition> maisonEditions;
        List<List<Categorie>> categories;
        List<IEnumerable<string>> categorieIds = new();
        List<List<TypeLivre>> typeLivres;
        ReadExcel("Data/DonneesLivres.xlsx", out livres, out auteurs, out maisonEditions,
        out categories, out typeLivres);
        #endregion

        //Ajout des statuts des commandes à la bd
        builder.ApplyConfiguration(new StatutCommandeConfiguration());

        //Ajout des types de livres à la bd
        builder.ApplyConfiguration(new TypeLivreConfiguration(typeLivres));

        //Ajout des catégories des livres à la bd
        builder.ApplyConfiguration(new CategorieConfiguration(categories, out categorieIds));

        //Ajout des langues des livres à la bd
        builder.ApplyConfiguration(new LangueConfiguration());
        //Ajout des auteurs à la bd
        builder.ApplyConfiguration(new AuteurConfiguration(auteurs, out auteurIds));
        //Ajout des maison d'édition à la bd
        builder.ApplyConfiguration(new MaisonEditionsConfiguration(maisonEditions));
        //Ajout des livres à la bd
        builder.ApplyConfiguration(new LivreConfiguration(livres, maisonEditions));

        //Ajout des relations livres auteurs à la bd
        builder.ApplyConfiguration(new LivreAuteurConfiguration(livres, auteurIds));
        //Ajout des relations livres catégories à la bd
        builder.ApplyConfiguration(new LivreCategorieConfiguration(livres, categorieIds));
        //Ajout des relations livres typeLivres à la bd
        builder.ApplyConfiguration(new LivreTypeLivreConfiguration(livres, typeLivres));

        #endregion
        #region Favorie
        // Configuration de la relation entre les favoris les membres et les livres
        builder.Entity<Favori>()
            .HasKey(f => new { f.MembreId, f.LivreId });
        //Un membre peut avoir plusieurs favoris
        builder.Entity<Favori>()
            .HasOne(f => f.Membre)
            .WithMany(m => m.Favoris)
            .HasForeignKey(f => f.MembreId);
        //Un livre peut etre mit en favoris par plusieurs membres
        builder.Entity<Favori>()
            .HasOne(f => f.Livre)
            .WithMany(l => l.Favoris)
            .HasForeignKey(f => f.LivreId);
        #endregion
        #region Livre
        //Un livre a plusieurs auteurs et un auteurs a plusieurs livres
        builder.Entity<Livre>()
            .HasMany(l => l.LivreAuteurs)
            .WithOne(la => la.Livre)
            .HasForeignKey(la => la.LivreId);
        //Un livre a un éditeur et un éditeur a plusieurs livres
        builder.Entity<Livre>()
            .HasOne(l => l.MaisonEdition)
            .WithMany(me => me.Livres);
        //Un livre peut avoir plusiseurs catégories et une catégorie peut avoir plusieurs livres
        builder.Entity<Livre>()
            .HasMany(l => l.LivreCategories)
            .WithOne(lc => lc.Livre)
            .HasForeignKey(lc => lc.LivreId);
        //Un livre peut avoir un type de livre et un type de livre peut avoir plusieurs livres
        builder.Entity<Livre>()
            .HasMany(l => l.LivreTypeLivres)
            .WithOne(tl => tl.Livre)
            .HasForeignKey(l => l.TypeLivreId);
        //Un livre peut avoir plusiseurs évaluation et une évaluation peut avoir qu'un livre
        builder.Entity<Livre>()
            .HasMany(l => l.Evaluations)
            .WithOne(e => e.Livre)
            .HasForeignKey(e => e.LivreId);
        //Un livre peut avoir une langue et une langue peut avoir plusieurs livres
        builder.Entity<Livre>()
            .HasOne(l => l.Langue)
            .WithMany(l => l.Livres);
        //Un livre peut avoir plusiseurs promotions et une ptomotion peut avoir plusieurs livres
        builder.Entity<Livre>()
            .HasMany(l => l.Promotions)
            .WithMany(c => c.Livres);
        #endregion
        #region Livre commendé
        // Configuration de la relation entre Livre et Commande et la table de liaison LivreCommande
        builder.Entity<LivreCommande>()
            .HasKey(lc => new { lc.LivreId, lc.CommandeId });

        //Un livre peut être dans plusieurs commandes
        builder.Entity<LivreCommande>()
            .HasOne(lc => lc.Livre)
            .WithMany(l => l.LivreCommandes)
            .HasForeignKey(lc => lc.LivreId);

        //Une commande peut avoir plusieurs livres
        builder.Entity<LivreCommande>()
            .HasOne(lc => lc.Commande)
            .WithMany(c => c.LivreCommandes)
            .HasForeignKey(lc => lc.CommandeId);

        // Configuration de la relation entre Livre et TypeLivre
        builder.Entity<LivreTypeLivre>()
            .HasKey(ltl => new { ltl.LivreId, ltl.TypeLivreId });

        //Un livre peut être dans plusieurs types de livres
        builder.Entity<LivreTypeLivre>()
            .HasOne(ltl => ltl.Livre)
            .WithMany(l => l.LivreTypeLivres)
            .HasForeignKey(ltl => ltl.LivreId);

        //Un type de livre peut avoir plusieurs livres
        builder.Entity<LivreTypeLivre>()
            .HasOne(ltl => ltl.TypeLivre)
            .WithMany(l => l.TypeLivres)
            .HasForeignKey(ltl => ltl.TypeLivreId);

        //Création des différent comptes
        //var password = new PasswordHasher<ApplicationUser>();
        var UserAdmin = new ApplicationUser
        {
            Id = "0",
            Nom = "ADMIN",
            Prenom = "Admin",
            Email = "admin@admin.com",
            UserName = "admin@admin.com",
            NormalizedEmail = "admin@admin.com".ToUpper(),
            NormalizedUserName = "admin@admin.com".ToUpper(),
            EmailConfirmed = true
        };
        //var adminHasher = password.HashPassword(UserAdmin, "Jaimelaprog1!");
        UserAdmin.PasswordHash = "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==";
        builder.Entity<ApplicationUser>().HasData(UserAdmin);

        var UserEmploye = new Employe
        {
            Id = "1",
            Nom = "EMPLOYE",
            Prenom = "Employe",
            NoEmploye = "007",
            Email = "employe@employe.com",
            UserName = "employe@employe.com",
            NormalizedEmail = "employe@employe.com".ToUpper(),
            NormalizedUserName = "employe@employe.com".ToUpper(),
            EmailConfirmed = true,
            AdressePrincipaleId = ""
        };
        // var employeHasher = password.HashPassword(UserEmploye, "Jaimelaprog1!");
        UserEmploye.PasswordHash =
            "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==";
        builder.Entity<Employe>().HasData(UserEmploye);

        var UserMembre = new Membre
        {
            Id = "2",
            Nom = "MEMBRE",
            Prenom = "Membre",
            NoMembre = "123456",
            Email = "membre@membre.com",
            UserName = "membre@membre.com",
            NormalizedEmail = "membre@membre.com".ToUpper(),
            NormalizedUserName = "membre@membre.com".ToUpper(),
            EmailConfirmed = true,
            DateAdhesion = DateTime.Now,
            AdressePrincipaleId = ""
        };
        // var employeHasher = password.HashPassword(UserEmploye, "Jaimelaprog1!");
        UserMembre.PasswordHash =
            "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==";
        builder.Entity<Membre>().HasData(UserMembre);

        var DefaultAuteur = new Auteur
        {
            Id = "0",
            NomAuteur = "Tony"

        };
        builder.Entity<Auteur>().HasData(DefaultAuteur);

        var DefaultMaisonEdition = new MaisonEdition
        {
            Id = "0",
            Nom = "Maison d'édition par défaut"
        };
        builder.Entity<MaisonEdition>().HasData(DefaultMaisonEdition);

        //Connecte les rôles aux users pré-créés
        //Roles de l'application
        var roleEmploye = new IdentityRole { Id = "0", Name = "Employe", NormalizedName = "Employe".ToUpper() };
        var roleMembre = new IdentityRole { Id = "1", Name = "Membre", NormalizedName = "Membre".ToUpper() };
        var roleAdmin = new IdentityRole { Id = "2", Name = "Admin", NormalizedName = "Admin".ToUpper() };
        builder.Entity<IdentityRole>().HasData(roleEmploye, roleMembre, roleAdmin);

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = roleEmploye.Id, UserId = UserEmploye.Id },
            new IdentityUserRole<string> { RoleId = roleMembre.Id, UserId = UserMembre.Id },
            new IdentityUserRole<string> { RoleId = roleAdmin.Id, UserId = UserAdmin.Id }
        );
        #endregion
        #region Adresse


        //Un type de livre peut avoir plusieurs livres
        /*builder.Entity<Adresse>()
            .HasOne(a => a.UtilisateurLivraison)
            .WithMany(l => l.AdressesLivraison)
            .HasForeignKey(a => a.UtilisateurLivraisonId);
        //Un type de livre peut avoir plusieurs livres
        builder.Entity<Adresse>()
            .HasOne(a => a.UtilisateurPrincipal)
            .WithOne(l => l.AdressePrincipale);*/
        #endregion
        #region LivreAuteur
        // Configuration des relation de livreAuteur
        builder.Entity<LivreAuteur>()
            .HasKey(la => new { la.LivreId, la.AuteurId });
        //Un livreAuteur peut avoir un livre qui a plusieurs livreAuteurs
        builder.Entity<LivreAuteur>()
            .HasOne(la => la.Livre)
            .WithMany(l => l.LivreAuteurs)
            .HasForeignKey(la => la.LivreId);
        //Un livreauteur peut avoir un auteur qui a plusieurs livreAuteurs
        builder.Entity<LivreAuteur>()
            .HasOne(la => la.Auteur)
            .WithMany(a => a.Livres)
            .HasForeignKey(la => la.AuteurId);
        #endregion
        #region LivreCatégorie
        // Configuration des relation de livreCatégorie
        builder.Entity<LivreCategorie>()
            .HasKey(la => new { la.LivreId, la.CategorieId });
        //Un LivreCategorie peut avoir un livre qui a plusieurs LivreCategories
        builder.Entity<LivreCategorie>()
            .HasOne(la => la.Livre)
            .WithMany(l => l.LivreCategories)
            .HasForeignKey(la => la.CategorieId);
        //Un LivreCategorie peut avoir une catégorie qui a plusieurs LivreCategories
        builder.Entity<LivreCategorie>()
            .HasOne(la => la.Categorie)
            .WithMany(c => c.Livres)
            .HasForeignKey(la => la.CategorieId);
        #endregion
        #region LivreTypeLivre
        // Configuration des relations de LivreTypeLivre
        //builder.Entity<LivreTypeLivre>()
        //    .HasKey(la => new { la.LivreId, la.TypeLivreId });
        //Un LivreTypeLivre peut avoir un livre qui a plusieurs LivreTypeLivres
        builder.Entity<LivreTypeLivre>()
            .HasOne(la => la.Livre)
            .WithMany(tl => tl.LivreTypeLivres)
            .HasForeignKey(la => la.LivreId);
        //Un LivreTypeLivre peut avoir un typeLivre qui a plusieurs LivreTypeLivres
        builder.Entity<LivreTypeLivre>()
            .HasOne(la => la.TypeLivre)
            .WithMany(a => a.TypeLivres)
            .HasForeignKey(la => la.TypeLivreId);
        #endregion
    }
    public void ReadExcel(string url, out List<Livre> livres, out List<List<Auteur>> listAuteurs, out List<MaisonEdition> maisonEditions,
        out List<List<Categorie>> ListCategories, out List<List<TypeLivre>> ListTypeLivres)
    {
        #region Donner une valleur initial aux paramettres
        int range = 0;
        livres = new();
        listAuteurs = new();
        maisonEditions = new();
        ListCategories = new();
        ListTypeLivres = new();
        #endregion
        //Permet l'encodage pour "encoding 1252."
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        //Lire la page excel
        using (var stream = File.Open(url, FileMode.Open, FileAccess.Read))
        {
            // Auto-detect format, supports:
            //  - Binary Excel files (2.0-2003 format; *.xls)
            //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                // Choose one of either 1 or 2:

                // 1. Use the reader methods
                do
                {
                    reader.Read();

                    while (reader.Read())
                    {
                        #region variable de l'entré
                        range++;
                        string id = "Excel " + range;
                        var livre = new Livre() { Id = id };
                        var auteurs = new List<Auteur>();
                        var maisonEdition = new MaisonEdition() { Id = id };
                        var categories = new List<Categorie>();
                        var typeLivres = new List<TypeLivre>();
                        #endregion
                        if (reader.GetValue(0) != null)
                        {
                            #region Titre
                            livre.Titre = reader.GetValue(0) != null ? reader.GetString(0).Trim() : "";
                            #endregion
                            #region Auteur
                            if (reader.GetValue(1) != null)
                                auteurs.Add(new() { Id = id, NomAuteur = reader.GetString(1).Trim() });
                            #endregion
                            #region Edition
                            if (reader.GetValue(2) != null)
                            {
                                maisonEdition.Nom = reader.GetString(2);
                            }
                            #endregion
                            #region Page
                            livre.NbPages = reader.GetValue(3) != null ? (int)reader.GetDouble(3) : 0;
                            #endregion
                            #region ISBN
                            livre.ISBN = reader.GetValue(4) != null ? reader.GetValue(4).ToString().Trim() : "";
                            #endregion
                            #region Couverture
                            livre.Couverture = "";
                            #endregion
                            #region Catégorie
                            if (reader.GetValue(6) != null)
                                categories.Add(new Categorie() { Id = id, Nom = reader.GetString(6), Description = "" });
                            #endregion
                            #region Quantité
                            livre.NbExemplaires = reader.GetValue(9) != null ? (int)reader.GetDouble(9) : 0;
                            #endregion
                            #region Papier
                            if (reader.GetValue(7) != null)
                            {
                                typeLivres.Add(new TypeLivre()
                                {
                                    Id = "Papier " + id,
                                    Nom = "Papier",
                                    Prix = reader.GetValue(7) != null ? reader.GetDouble(8) : 0
                                });
                            }
                            #endregion
                            #region Numérique
                            if (reader.GetValue(10) != null)
                            {
                                typeLivres.Add(new TypeLivre()
                                {
                                    Id = "Numérique " + id,
                                    Nom = "Numérique",
                                    Prix = reader.GetValue(7) != null ? reader.GetDouble(11) : 0
                                });
                            }
                            #endregion
                            livres.Add(livre);
                            listAuteurs.Add(auteurs);
                            maisonEditions.Add(maisonEdition);
                            ListCategories.Add(categories);
                            ListTypeLivres.Add(typeLivres);
                            /*Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                            Console.WriteLine("Titre\tAuteur\tEditeur\tPage\tISBN\tCouverture\tCatégorie\tQuantité\tPapier" +
                                "\tPrix papier\tNumérique\tPrix numérique" +
                                "\n" + reader.GetString(0) + "\t" + reader.GetString(1) + "\t" + reader.GetString(2)
                                + "\t" + reader.GetDouble(3).ToString() + "\t" + reader.GetValue(4).ToString()
                                + "\t" + (reader.GetValue(5) != null ? reader.GetValue(5).ToString() : "")
                                + "\t" + reader.GetString(6) + "\t" + (reader.GetValue(7) != null ? true : false)
                                + "\t" + (reader.GetDouble(8) != null ? reader.GetDouble(8).ToString() : "")
                                + "\t" + reader.GetDouble(9) + "\t" + (reader.GetValue(10) != null ? true : false)
                                + "\t" + (reader.GetDouble(11) != null ? reader.GetDouble(11).ToString() : null)
                                );*/
                        }
                    }
                } while (reader.NextResult());
            }
        }
    }

}