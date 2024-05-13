﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stripe;
using VLISSIDES.Models;

namespace VLISSIDES.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


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

    public DbSet<Promotion> Promotions { get; set; }

    public DbSet<LivreTypeLivre> LivreTypeLivres { get; set; }

    public DbSet<Don> Dons { get; set; }
    public DbSet<LivrePanier> LivrePanier { get; set; }

    public DbSet<Adresse> Adresses { get; set; }
    public DbSet<LivreCategorie> LivreCategories { get; set; }

    public DbSet<LivreAuteur> LivreAuteurs { get; set; }

    public DbSet<DemandeNotification> DemandesNotifications { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        #region configuration

        // Configuration des entités
        builder.ApplyConfiguration(new StatutCommandeConfiguration());
        builder.ApplyConfiguration(new TypeLivreConfiguration());
        builder.ApplyConfiguration(new CategorieConfiguration());
        builder.ApplyConfiguration(new LangueConfiguration());
        builder.ApplyConfiguration(new AuteurConfiguration());
        builder.ApplyConfiguration(new MaisonEditionsConfiguration());
        builder.ApplyConfiguration(new LivreConfiguration());
        builder.ApplyConfiguration(new LivreAuteurConfiguration());
        builder.ApplyConfiguration(new LivreCategorieConfiguration());
        builder.ApplyConfiguration(new LivreTypeLivreConfiguration());

        #endregion

        #region Favorie

        // Configuration pour les adresses de livraison car un utilisateur peut avoir plusieurs adresses de livraison
        builder.Entity<ApplicationUser>()
            .HasMany(a => a.AdressesLivraison)
            .WithOne(a => a.UtilisateurLivraison)
            .HasForeignKey(a => a.UtilisateurLivraisonId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuration pour le panier car un utilisateur peut avoir plusieurs LivrePanier
        builder.Entity<ApplicationUser>()
            .HasMany(a => a.Panier)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
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

        #endregion

        #region Livre

        //Un livre a un éditeur et un éditeur a plusieurs livres
        builder.Entity<Livre>()
            .HasOne(l => l.MaisonEdition)
            .WithMany(me => me.Livres);
        //Un livre peut avoir plusiseurs évaluation et une évaluation peut avoir qu'un livre
        builder.Entity<Livre>()
            .HasMany(l => l.Evaluations)
            .WithOne(e => e.Livre)
            .HasForeignKey(e => e.LivreId);
        //Un livre peut avoir une langue et une langue peut avoir plusieurs livres
        builder.Entity<Livre>()
            .HasOne(l => l.Langue)
            .WithMany(l => l.Livres);

        #endregion

        #region Livre Commandé

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

        #endregion

        #region Livre Panier

        //Un livre peut être dans plusieurs paniers
        builder.Entity<LivrePanier>()
            .HasOne(lp => lp.Livre)
            .WithMany(l => l.LivrePanier)
            .HasForeignKey(lp => lp.LivreId);

        //Un user peut avoir plusieurs LivresPaniers
        builder.Entity<LivrePanier>()
            .HasOne(lp => lp.User)
            .WithMany(p => p.Panier)
            .HasForeignKey(lp => lp.UserId);

        #endregion

        #region ApplicationUser

        //Création des différent comptes
        //var password = new PasswordHasher<ApplicationUser>();
        var UserAdmin = new ApplicationUser
        {
            Id = "0",
            Nom = "ADMIN",
            Prenom = "Admin",
            Email = "Admin@LaFourmiAilee.com",
            UserName = "Admin",
            NormalizedEmail = "Admin@LaFourmiAilee.com".ToUpper(),
            NormalizedUserName = "Admin".ToUpper(),
            EmailConfirmed = true,
            IsBanned = false
        };
        var password = new PasswordHasher<ApplicationUser>();
        var adminHasher = password.HashPassword(UserAdmin, "FourmiAilee1!");
        UserAdmin.PasswordHash = adminHasher;

        //UserAdmin.PasswordHash = "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==";
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
            AdressePrincipaleId = "",
            IsBanned = false
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
            AdressePrincipaleId = "",
            IsBanned = false
        };
        // var employeHasher = password.HashPassword(UserEmploye, "Jaimelaprog1!");
        UserMembre.PasswordHash =
            "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==";
        builder.Entity<Membre>().HasData(UserMembre);
        //Marcel Gosselin
        var UserMarcelGosselin = new Membre
        {
            Id = Guid.NewGuid().ToString(),
            Nom = "Gosselin",
            Prenom = "Marcel",
            NoMembre = Guid.NewGuid().ToString(),
            Email = "MGosselin@gmail.com",
            NormalizedEmail = "MGosselin@gmail.com".ToUpper(),
            UserName = "MGosselin@gmail.com",
            NormalizedUserName = "MGosselin@gmail.com".ToUpper(),
            EmailConfirmed = true,
            DateAdhesion = DateTime.Now,
            IsBanned = false,
            DateNaissance = new DateTime(2001, 4, 21),


        };
        var stripeCustomerId = CreateStripeCustomer(UserMarcelGosselin.Email,
                $"{UserMarcelGosselin.Prenom} {UserMarcelGosselin.Nom}");
        // Stocker l'ID de client Stripe dans votre base de données
        ((Membre)UserMarcelGosselin).StripeCustomerId = stripeCustomerId;
        UserMarcelGosselin.PasswordHash = password.HashPassword(UserMarcelGosselin, "MGosselin11!");
        builder.Entity<Membre>().HasData(UserMarcelGosselin);
        //Stephane Fallu
        var UserStephaneFallu = new Membre
        {
            Id = Guid.NewGuid().ToString(),
            Nom = "Fallu",
            Prenom = "Stephane",
            NoMembre = Guid.NewGuid().ToString(),
            Email = "SFallu@gmail.com",
            NormalizedEmail = "SFallu@gmail.com".ToUpper(),
            UserName = "SFallu@gmail.com",
            NormalizedUserName = "SFallu@gmail.com".ToUpper(),
            EmailConfirmed = true,
            DateAdhesion = DateTime.Now,
            IsBanned = false,
            DateNaissance = new DateTime(1993, 12, 6),


        };
        stripeCustomerId = CreateStripeCustomer(UserStephaneFallu.Email,
               $"{UserStephaneFallu.Prenom} {UserStephaneFallu.Nom}");
        ((Membre)UserStephaneFallu).StripeCustomerId = stripeCustomerId;
        UserStephaneFallu.PasswordHash = password.HashPassword(UserStephaneFallu, "SFallu11!");
        builder.Entity<Membre>().HasData(UserStephaneFallu);
        //Sylvie Demers
        var UserSylvieDemers = new Membre
        {
            Id = Guid.NewGuid().ToString(),
            Nom = "Demers",
            Prenom = "Sylvie",
            NoMembre = Guid.NewGuid().ToString(),
            Email = "SDemers@gmail.com",
            NormalizedEmail = "SDemers@gmail.com".ToUpper(),
            UserName = "SDemers@gmail.com",
            NormalizedUserName = "SDemers@gmail.com".ToUpper(),
            EmailConfirmed = true,
            DateAdhesion = DateTime.Now,
            IsBanned = false,
            DateNaissance = new DateTime(2002, 12, 7),


        };
        stripeCustomerId = CreateStripeCustomer(UserSylvieDemers.Email,
                $"{UserSylvieDemers.Prenom} {UserSylvieDemers.Nom}");
        ((Membre)UserSylvieDemers).StripeCustomerId = stripeCustomerId;

        UserSylvieDemers.PasswordHash = password.HashPassword(UserSylvieDemers, "SDemers11!");
        builder.Entity<Membre>().HasData(UserSylvieDemers);
        //Tony Huynh
        var UserTonyHuynh = new Membre
        {
            Id = Guid.NewGuid().ToString(),
            Nom = "Huynh",
            Prenom = "Tony",
            NoMembre = Guid.NewGuid().ToString(),
            Email = "tonyhuynh0412@gmail.com",
            NormalizedEmail = "tonyhuynh0412@gmail.com".ToUpper(),
            UserName = "tonyhuynh0412@gmail.com",
            NormalizedUserName = "tonyhuynh0412@gmail.com".ToUpper(),
            EmailConfirmed = true,
            DateAdhesion = DateTime.Now,
            IsBanned = false,
            DateNaissance = new DateTime(2004, 04, 12),
            PasswordHash = "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA=="
        };
        stripeCustomerId = CreateStripeCustomer(UserTonyHuynh.Email,
               $"{UserTonyHuynh.Prenom} {UserTonyHuynh.Nom}");
        // Stocker l'ID de client Stripe dans votre base de données
        ((Membre)UserTonyHuynh).StripeCustomerId = stripeCustomerId;
        builder.Entity<Membre>().HasData(UserTonyHuynh);
        //Julien Landry
        var UserJulienLandry = new Membre
        {
            Id = Guid.NewGuid().ToString(),
            Nom = "Landry",
            Prenom = "Julien",
            NoMembre = Guid.NewGuid().ToString(),
            Email = "julien.landry1800@gmail.com",
            NormalizedEmail = "julien.landry1800@gmail.com".ToUpper(),
            UserName = "julien.landry1800@gmail.com",
            NormalizedUserName = "julien.landry1800@gmail.com".ToUpper(),
            EmailConfirmed = true,
            DateAdhesion = DateTime.Now,
            IsBanned = false,
            DateNaissance = new DateTime(2004, 04, 12),
            PasswordHash = "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA=="
        };
        stripeCustomerId = CreateStripeCustomer(UserJulienLandry.Email,
                $"{UserJulienLandry.Prenom} {UserJulienLandry.Nom}");
        // Stocker l'ID de client Stripe dans votre base de données
        ((Membre)UserJulienLandry).StripeCustomerId = stripeCustomerId;
        builder.Entity<Membre>().HasData(UserJulienLandry);
        //Jean-luc
        var UserJeanLuc = new Membre
        {
            Id = Guid.NewGuid().ToString(),
            Nom = "JEAN-LUC GOUAHO",
            Prenom = "Deto",
            NoMembre = Guid.NewGuid().ToString(),
            Email = "jlgouaho@gmail.com",
            NormalizedEmail = "jlgouaho@gmail.com".ToUpper(),
            UserName = "jlgouaho@gmail.com",
            NormalizedUserName = "jlgouaho@gmail.com".ToUpper(),
            EmailConfirmed = true,
            DateAdhesion = DateTime.Now,
            IsBanned = false,
            DateNaissance = new DateTime(2004, 04, 12),
            PasswordHash = "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA=="
        };
        stripeCustomerId = CreateStripeCustomer(UserJeanLuc.Email,
                $"{UserJeanLuc.Prenom} {UserJeanLuc.Nom}");
        // Stocker l'ID de client Stripe dans votre base de données
        ((Membre)UserJeanLuc).StripeCustomerId = stripeCustomerId;
        builder.Entity<Membre>().HasData(UserJeanLuc);
        //Connecte les rôles aux users pré-créés
        //Roles de l'application
        var roleEmploye = new IdentityRole { Id = "0", Name = "Employe", NormalizedName = "Employe".ToUpper() };
        var roleMembre = new IdentityRole { Id = "1", Name = "Membre", NormalizedName = "Membre".ToUpper() };
        var roleAdmin = new IdentityRole { Id = "2", Name = "Admin", NormalizedName = "Admin".ToUpper() };
        builder.Entity<IdentityRole>().HasData(roleEmploye, roleMembre, roleAdmin);

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = roleEmploye.Id, UserId = UserEmploye.Id },
            new IdentityUserRole<string> { RoleId = roleMembre.Id, UserId = UserMembre.Id },
            new IdentityUserRole<string> { RoleId = roleAdmin.Id, UserId = UserAdmin.Id },
            new IdentityUserRole<string> { RoleId = roleMembre.Id, UserId = UserMarcelGosselin.Id },
            new IdentityUserRole<string> { RoleId = roleMembre.Id, UserId = UserStephaneFallu.Id },
            new IdentityUserRole<string> { RoleId = roleMembre.Id, UserId = UserSylvieDemers.Id },
            new IdentityUserRole<string> { RoleId = roleMembre.Id, UserId = UserTonyHuynh.Id },
            new IdentityUserRole<string> { RoleId = roleMembre.Id, UserId = UserJeanLuc.Id },
            new IdentityUserRole<string> { RoleId = roleMembre.Id, UserId = UserJulienLandry.Id }
        );
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


        #endregion

        #region Livre Auteur

        // Configuration des relation de livreAuteur
        builder.Entity<LivreAuteur>()
            .HasKey(la => new { la.LivreId, la.AuteurId });

        #endregion

        #region Livre Catégorie

        // Configuration des relation de livreCatégorie
        builder.Entity<LivreCategorie>()
            .HasKey(la => new { la.LivreId, la.CategorieId });

        #endregion

        #region Livre TypeLivre

        // Configuration des relations de LivreTypeLivre
        builder.Entity<LivreTypeLivre>()
            .HasKey(la => new { la.LivreId, la.TypeLivreId });

        #endregion

        #region Promotion

        //Une promotion peut avoir une seule maison d'édition et une maison d'édtion peut avoir plusieurs promotions
        builder.Entity<Promotion>()
            .HasOne(p => p.MaisonEdition)
            .WithMany(me => me.Promotions);
        //Une promotion peut avoir un seul auteur et un auteur peut avoir plusieurs promotions
        builder.Entity<Promotion>()
            .HasOne(p => p.Auteur)
            .WithMany(a => a.Promotions);
        //Une promotion peut avoir une seule categorie et une categorie peut avoir plusieurs promotions
        builder.Entity<Promotion>()
            .HasOne(p => p.Categorie)
            .WithMany(c => c.Promotions);

        //Creation d'une promoition d'anniversaire par défaut
        builder.Entity<Promotion>().HasData(
            new Promotion
            {
                Id = "0",
                Nom = "Promotion Anniversaire",
                Description = "Ce code promo est uniquement valide durant votre mois d'anniversaire.",
                DateDebut = DateTime.Now,
                DateFin = DateTime.Now.AddYears(1),
                TypePromotion = "pourcentage",
                PourcentageRabais = 10,
                Image = "/img/images_Promo/birthday.jpg",

                CodePromo = "BIRTHDAY"
            }
        );

        //liaison entre les promotions et les commandes
        builder.Entity<Promotion>()
            .HasMany(p => p.Commandes)
            .WithOne(c => c.Promotion)
            .HasForeignKey(c => c.PromotionId);

        //Liaison entre les promotions et les livres dans le panier
        builder.Entity<Promotion>()
            .HasMany(p => p.LivrePaniers)
            .WithOne(lp => lp.Promotion)
            .HasForeignKey(lp => lp.PromotionId);



        #endregion
    }
    public string CreateStripeCustomer(string email, string name)
    {
        var options = new CustomerCreateOptions
        {
            Email = email,
            Name = name
        };
        var service = new CustomerService();
        var customer = service.Create(options);
        return customer.Id.ToString();

    }
}