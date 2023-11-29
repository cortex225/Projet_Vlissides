using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;
using VLISSIDES.Data;
using VLISSIDES.Helpers;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;
using VLISSIDES.Services;

var builder = WebApplication.CreateBuilder(args);


StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe_Test:SecretKey").Value;


// Add services to the container.

//Connection pour Jean-Luc
if (OperatingSystem.IsMacOS())
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("JLConnection")));
else
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.FromSeconds(1);
});
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Implementation du service SendGridEmail par l'interface ISendGridEmail
builder.Services.AddTransient<ISendGridEmail, SendGridEmail>();
builder.Services.AddTransient<ISendGridEmailAdvance, SendGridEmailAdvance>();
//Permet de ne pas utiliser la configuration de base mais plutot de configurer les option de recupération de AuthMessageSenderOptions
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("SendGrid"));

//Permet de ne pas utiliser la configuration de base mais plutot de configurer les option de recupération de AuthMessageSenderOptions
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

//Service qui permet d'envoyer un mail d'anniversaire
builder.Services.AddHostedService<BirthdayService>();


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