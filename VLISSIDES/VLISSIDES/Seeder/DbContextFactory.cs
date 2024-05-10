using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stripe;
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
        StripeConfiguration.ApiKey = "sk_test_51O3gRDAIrJUcHyNnZxFOOXj7BU4fydHMbsMvSGoA33X1DrKBSBnDswvi5cqwoCLEGmd5WCPOEc5bUORrTRM0U7Vt00yyd5Gmyk";

        if (OperatingSystem.IsMacOS()) builder.UseSqlServer(configuration.GetConnectionString("JLConnection"));
        else builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        return new ApplicationDbContext(builder.Options);
    }
}