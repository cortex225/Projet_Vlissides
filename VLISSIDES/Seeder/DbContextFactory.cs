using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VLISSIDES.Data;

namespace Seeder;

public class DbContextFactory
{
    public static ApplicationDbContext CreateDbContext()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(Directory.GetCurrentDirectory() + "/appsettings.json")
            .Build();

        //Connection JL
        var connectionStringJL = configuration.GetConnectionString("JLConnection");

        //Connection par Defaut
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

        if (OperatingSystem.IsMacOS())
            builder.UseSqlServer(connectionStringJL);
        builder.UseSqlServer(connectionString);

        return new ApplicationDbContext(builder.Options);
    }
}