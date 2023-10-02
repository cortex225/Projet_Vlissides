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
    #endregion

    public DbSet<LivreTypeLivre> LivreTypeLivres { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        #region configuration
        #region Prendre les données de la feuille excel
        List<string> titres = new();
        List<string> auteurs = new();
        List<string> auteurIds = new();
        List<string> maisonEditions = new();
        List<string> maisonEditionIds = new();
        List<int> pages = new();
        List<string> ISBNs = new();
        List<string> couvertures = new();
        List<string> categories = new();
        List<string> categorieIds = new();
        List<int> quantites = new();
        List<string> typeLivres = new();
        List<string> typeLivreIds = new();
        List<double> prix = new();
        ReadExcel("Data/DonneesLivres.xlsx", out titres, out auteurs, out auteurIds, out maisonEditions, out maisonEditionIds, out pages,
            out ISBNs, out couvertures, out categories, out categorieIds, out quantites, out typeLivres, out typeLivreIds, out prix);
        #endregion



        //Ajout des statuts des commandes à la bd
        builder.ApplyConfiguration(new StatutCommandeConfiguration());

        //Ajout des types de livres à la bd
        builder.ApplyConfiguration(new TypeLivreConfiguration());

        //Ajout des catégories des livres à la bd
        builder.ApplyConfiguration(new CategorieLivreConfiguration(categories, categorieIds));

        //Ajout des langues des livres à la bd
        builder.ApplyConfiguration(new LangueConfiguration());
        //Ajout des livres à la bd
        builder.ApplyConfiguration(new AuteurConfiguration(auteurs, auteurIds));
        //Ajout des livres à la bd
        builder.ApplyConfiguration(new MaisonEditionsConfiguration(maisonEditions, maisonEditionIds));
        //Ajout des livres à la bd
        builder.ApplyConfiguration(new LivreConfiguration(titres, auteurIds, pages, ISBNs, couvertures, quantites, typeLivreIds, prix));
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
            .HasMany(l => l.Auteurs)
            .WithMany(a => a.Livres);
        //Un livre a un éditeur et un éditeur a plusieurs livres
        builder.Entity<Livre>()
            .HasOne(l => l.MaisonEdition)
            .WithMany(me => me.Livres)
            .HasForeignKey(l => l.MaisonEditionId);
        //Un livre peut avoir plusiseurs catégories et une catégorie peut avoir plusieurs livres
        builder.Entity<Livre>()
            .HasMany(l => l.Categories)
            .WithMany(c => c.Livres);
        //Un livre peut avoir un type de livre et un type de livre peut avoir plusieurs livres
        builder.Entity<Livre>()
            .HasOne(l => l.TypesLivre)
            .WithMany(tl => tl.Livres)
            .HasForeignKey(l => l.TypeLivreId);
        //Un livre peut avoir plusiseurs évaluation et une évaluation peut avoir qu'un livre
        builder.Entity<Livre>()
            .HasMany(l => l.Evaluations)
            .WithOne(e => e.Livre)
            .HasForeignKey(e => e.LivreId);
        //Un livre peut avoir une langue et une langue peut avoir plusieurs livres
        builder.Entity<Livre>()
            .HasOne(l => l.Langue)
            .WithMany(l => l.Livres)
            .HasForeignKey(l => l.LangueId);
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
            .WithMany(l => l.LivreTypeLivres)
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

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = roleEmploye.Id, UserId = UserEmploye.Id },
            new IdentityUserRole<string> { RoleId = roleMembre.Id, UserId = UserMembre.Id },
            new IdentityUserRole<string> { RoleId = roleAdmin.Id, UserId = UserAdmin.Id }
        );
        #endregion
    }
    public void ReadExcel(string url, out List<string> titres, out List<string> auteurs, out List<string> auteurIds,
        out List<string> maisonEditions, out List<string> maisonEditionIds, out List<int> pages, out List<string> ISBNs,
        out List<string> couvertures, out List<string> categories, out List<string> categorieIds, out List<int> quantites,
        out List<string> typeLivres, out List<string> typeLivreIds, out List<double> prix)
    {
        #region Donner une valleur initial aux paramettres
        int range = 0;
        titres = new();
        auteurs = new();
        auteurIds = new();
        maisonEditions = new();
        maisonEditionIds = new();
        pages = new();
        ISBNs = new();
        couvertures = new();
        categories = new();
        categorieIds = new();
        quantites = new();
        typeLivres = new();
        typeLivreIds = new();
        prix = new();

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
                        range++;
                        if (reader.GetValue(0) != null)
                        {
                            Console.WriteLine("-----------------------------------------------------------------");
                            #region Titre
                            Console.WriteLine("-Titre-----------------------------------------------------------\n" + reader.GetString(0));
                            titres.Add(reader.GetValue(0) != null ? reader.GetString(0).Trim() : "");
                            #endregion
                            #region Auteur
                            Console.WriteLine("\n-Auteur----------------------------------------------------------\n" + reader.GetString(1));
                            auteurs.Add(reader.GetValue(1) != null ? reader.GetString(1).Trim() : "");
                            /*f (auteurs.Where(a => a.Equals(reader.GetString(1))).Count() > 1)
                                auteurIds.Add(auteurIds[auteurs.FindIndex(a => a.Equals(reader.GetValue(1) != null ?
                                    reader.GetString(1) : ""))]);
                            else*/
                            auteurIds.Add("Excel " + range);
                            #endregion
                            #region Edition
                            Console.WriteLine("\n-Edition---------------------------------------------------------\n" + reader.GetString(2));
                            if (reader.GetValue(2) != null)
                            {
                                maisonEditions.Add(reader.GetString(2).Trim());
                                maisonEditionIds.Add("Excel " + range);
                            }
                            #endregion
                            #region Page
                            Console.WriteLine("\n-Page---------------------------------------------------------\n" + reader.GetDouble(3));
                            pages.Add(reader.GetValue(3) != null ? (int)reader.GetDouble(3) : 0);
                            #endregion
                            #region ISBN
                            Console.WriteLine("\n-Isbns--------------------------------------------------------\n"
                                + reader.GetValue(4));
                            ISBNs.Add(reader.GetValue(4) != null ? reader.GetValue(4).ToString().Trim() : "");
                            #endregion
                            #region Couverture
                            Console.WriteLine("\n-Couverture---------------------------------------------------\n");
                            //Console.WriteLine(reader.GetFieldType(5));
                            couvertures.Add(reader.GetValue(5) != null ? "" : "");/*reader.GetValue(5)*/
                            #endregion
                            #region Catégorie
                            Console.WriteLine("\n-Catégorie----------------------------------------------------\n" + reader.GetString(6));
                            categories.Add(reader.GetValue(6) != null ? reader.GetString(6) : "");
                            if (categories.Where(c => c.Equals(reader.GetString(6))).Count() > 1)
                                categorieIds.Add(categorieIds[categories.FindIndex(c => c.Equals(reader.GetValue(6) != null ?
                                    reader.GetString(6) : ""))]);
                            else
                                categorieIds.Add("Excel " + range);
                            #endregion
                            #region Qunatité
                            Console.WriteLine("\n-Quantité-----------------------------------------------------\n" + reader.GetDouble(9));
                            quantites.Add(reader.GetValue(9) != null ? (int)reader.GetDouble(9) : 0);
                            #endregion
                            #region Papier
                            Console.WriteLine("\n-Papier-------------------------------------------------------");
                            Console.WriteLine(reader.GetValue(7) != null ? true : false);
                            if (reader.GetValue(7) != null)
                            {
                                typeLivres.Add("Papier");
                                typeLivreIds.Add("1");
                                Console.WriteLine("\n-Prix papier--------------------------------------------------\n" + reader.GetDouble(8));
                                prix.Add(reader.GetValue(7) != null ? reader.GetDouble(8) : 0);
                            }
                            #endregion
                            #region Numérique
                            Console.WriteLine("\n-Numérique----------------------------------------------------");
                            Console.WriteLine(reader.GetValue(10) != null ? true : false);
                            if (reader.GetValue(10) != null)
                            {
                                typeLivres.Add("Numérique");
                                typeLivreIds.Add("2");
                                Console.WriteLine("\n-Prix numérique-----------------------------------------------\n" + reader.GetDouble(11));
                                prix.Add(reader.GetValue(10) != null ? reader.GetDouble(11) : 0);
                            }
                            #endregion
                        }
                    }
                } while (reader.NextResult());
            }
        }
    }

}