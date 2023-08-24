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
    
}