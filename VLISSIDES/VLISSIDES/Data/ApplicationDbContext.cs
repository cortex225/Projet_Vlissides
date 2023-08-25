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
    
    public DbSet<Membre> Membres { get; set; }
    
    public DbSet<Reservation> Reservations { get; set; }
    
    public DbSet<Evenement> Evenements { get; set; }
    
    public DbSet<Commentaire> Commentaires { get; set; }
    
    public DbSet<Livre> Livres { get; set; }
    
    public DbSet<Categorie> Categories { get; set; }
    
    public DbSet<LivreCommande> LivreCommandes { get; set; }
    
    public DbSet<StatutCommande> StatutCommandes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        base.OnModelCreating(builder);
        builder.Entity<Adresse>().ToTable("Adresses");
        builder.Entity<Commande>().ToTable("Commandes");
        builder.Entity<Employe>().ToTable("Employes");
        builder.Entity<Membre>().ToTable("Membres");
        builder.Entity<Reservation>().ToTable("Reservations");
        builder.Entity<Evenement>().ToTable("Evenements");
        builder.Entity<Commentaire>().ToTable("Commentaires");
        builder.Entity<Livre>().ToTable("LivreS");
        builder.Entity<Categorie>().ToTable("Categorie");
        builder.Entity<LivreCommande>().ToTable("LivreCommande");
        builder.Entity<StatutCommande>().ToTable("StatutCommande");
    }
}