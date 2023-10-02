using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

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

    public DbSet<LivreTypeLivre> LivreTypeLivres { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.Entity<Employe>().ToTable("Employes");
        builder.Entity<Membre>().ToTable("Membres");

        //Ajout des statuts des commandes à la bd
        builder.ApplyConfiguration(new StatutCommandeConfiguration());

        //Ajout des types de livres à la bd
        builder.ApplyConfiguration(new TypeLivreConfiguration());

        //Ajout des catégories des livres à la bd
        builder.ApplyConfiguration(new CategorieLivreConfiguration());

        //Ajout des langues des livres à la bd
        builder.ApplyConfiguration(new LangueConfiguration());

        //Roles de l'application
        var roleEmploye = new IdentityRole { Id = "0", Name = "Employe", NormalizedName = "Employe".ToUpper() };
        var roleMembre = new IdentityRole { Id = "1", Name = "Membre", NormalizedName = "Membre".ToUpper() };
        var roleAdmin = new IdentityRole { Id = "2", Name = "Admin", NormalizedName = "Admin".ToUpper() };
        builder.Entity<IdentityRole>().HasData(roleEmploye, roleMembre, roleAdmin);

        // Configuration pour l' adresse principale car un utilisateur peut avoir une adresse principale
        builder.Entity<ApplicationUser>()
            .HasOne(a => a.AdressePrincipale)
            .WithOne(a => a.UtilisateurPrincipal)
            .HasForeignKey<Adresse>(a => a.UtilisateurPrincipalId)
            .OnDelete(DeleteBehavior.Restrict);


        // Configuration pour les adresses de livraison car un utilisateur peut avoir plusieurs adresses de livraison
        builder.Entity<ApplicationUser>()
            .HasMany(a => a.AdressesLivraison)
            .WithOne(a => a.UtilisateurLivraison)
            .HasForeignKey(a => a.UtilisateurLivraisonId)
            .OnDelete(DeleteBehavior.Restrict);


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

        builder.Entity<Livre>()
            .HasMany(l => l.Auteurs)
            .WithMany(a => a.Livres)
            .UsingEntity(j => j.ToTable("LivreAuteur"));

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
    }
}