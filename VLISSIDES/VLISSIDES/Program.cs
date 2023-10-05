using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VLISSIDES.Data;
using VLISSIDES.Helpers;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;
using VLISSIDES.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Connection JL
var connectionStringJL = builder.Configuration.GetConnectionString("JLConnection");

//Connection par Defaut
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (OperatingSystem.IsMacOS())
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionStringJL));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Implementation du service SendGridEmail par l'interface ISendGridEmail
builder.Services.AddTransient<ISendGridEmail, SendGridEmail>();
//Permet de ne pas utiliser la configuration de base mais plutot de configurer les option de recupération de AuthMessageSenderOptions
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("SendGrid"));

//Permet de ne pas utiliser la configuration de base mais plutot de configurer les option de recupération de AuthMessageSenderOptions
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);


var app = builder.Build();

// Configure le HTTP request pipeline.
app.UseSession();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Accueil/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "/{controller=Accueil}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();