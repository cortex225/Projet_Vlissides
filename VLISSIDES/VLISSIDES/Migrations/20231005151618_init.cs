using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdressePrincipaleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoEmploye = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoMembre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdhesion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommandeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomAuteur = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Evenements",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbPlaces = table.Column<int>(type: "int", nullable: false),
                    NbPlacesMembre = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Langues",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaisonEditions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaisonEditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rabais = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LivreId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatutCommande",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatutCommande", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeLivres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLivres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NoCivique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilisateurPrincipalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UtilisateurLivraisonId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_AspNetUsers_UtilisateurLivraisonId",
                        column: x => x.UtilisateurLivraisonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adresses_AspNetUsers_UtilisateurPrincipalId",
                        column: x => x.UtilisateurPrincipalId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvenementId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MembreId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_MembreId",
                        column: x => x.MembreId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Evenements_EvenementId",
                        column: x => x.EvenementId,
                        principalTable: "Evenements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCommande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrixTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MembreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdresseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatutCommandeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commandes_Adresses_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commandes_AspNetUsers_MembreId",
                        column: x => x.MembreId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commandes_StatutCommande_StatutCommandeId",
                        column: x => x.StatutCommandeId,
                        principalTable: "StatutCommande",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Livres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Couverture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbExemplaires = table.Column<int>(type: "int", nullable: false),
                    DateAjout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NbPages = table.Column<int>(type: "int", nullable: false),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaisonEditionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LangueId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CommandeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livres_Commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commandes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Livres_Langues_LangueId",
                        column: x => x.LangueId,
                        principalTable: "Langues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Livres_MaisonEditions_MaisonEditionId",
                        column: x => x.MaisonEditionId,
                        principalTable: "MaisonEditions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<int>(type: "int", nullable: false),
                    DateEvaluation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MembreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivreId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_AspNetUsers_MembreId",
                        column: x => x.MembreId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluations_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favoris",
                columns: table => new
                {
                    MembreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivreId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoris", x => new { x.MembreId, x.LivreId });
                    table.ForeignKey(
                        name: "FK_Favoris_AspNetUsers_MembreId",
                        column: x => x.MembreId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoris_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivreAuteurs",
                columns: table => new
                {
                    LivreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuteurId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivreAuteurs", x => new { x.LivreId, x.AuteurId });
                    table.ForeignKey(
                        name: "FK_LivreAuteurs_Auteurs_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Auteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivreAuteurs_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivreCategories",
                columns: table => new
                {
                    LivreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategorieId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivreCategories", x => new { x.LivreId, x.CategorieId });
                    table.ForeignKey(
                        name: "FK_LivreCategories_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivreCategories_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivreCommandes",
                columns: table => new
                {
                    LivreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommandeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivreCommandes", x => new { x.LivreId, x.CommandeId });
                    table.ForeignKey(
                        name: "FK_LivreCommandes_Commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivreCommandes_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivrePromotions",
                columns: table => new
                {
                    LivresId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PromotionsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrePromotions", x => new { x.LivresId, x.PromotionsId });
                    table.ForeignKey(
                        name: "FK_LivrePromotions_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivrePromotions_Promotions_PromotionsId",
                        column: x => x.PromotionsId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivreTypeLivres",
                columns: table => new
                {
                    LivreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeLivreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivreTypeLivres", x => new { x.LivreId, x.TypeLivreId });
                    table.ForeignKey(
                        name: "FK_LivreTypeLivres_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivreTypeLivres_TypeLivres_TypeLivreId",
                        column: x => x.TypeLivreId,
                        principalTable: "TypeLivres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0", "a2e02ed0-0b7f-4a79-8dcf-05feca2a5ff2", "Employe", "EMPLOYE" },
                    { "1", "2f7b11d6-505c-47a6-898c-d622e13e5bed", "Membre", "MEMBRE" },
                    { "2", "239f406c-2269-469d-83d1-bfd8df65c42f", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0", 0, null, "639651b6-c480-45e4-8938-5df5ace92458", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Admin", "7b8c8fb8-42c4-4bfb-8a42-d3ede70aa79b", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NoEmploye", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "", "0cb94885-3b70-4f7a-ac47-5a7ba62ed48f", "Employe", "employe@employe.com", true, false, null, "007", "EMPLOYE", "EMPLOYE@EMPLOYE.COM", "EMPLOYE@EMPLOYE.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Employe", "39ee626b-5d64-4693-a941-4bfd19f12bea", false, "employe@employe.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "CommandeId", "ConcurrencyStamp", "DateAdhesion", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NoMembre", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "ReservationId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "", null, "75b82484-c39a-4df2-adf0-a9f254d10035", new DateTime(2023, 10, 5, 11, 16, 18, 416, DateTimeKind.Local).AddTicks(8820), "Membre", "membre@membre.com", true, false, null, "123456", "MEMBRE", "MEMBRE@MEMBRE.COM", "MEMBRE@MEMBRE.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Membre", null, "204ba0e9-3d65-4f17-bfaf-4f17ce152e96", false, "membre@membre.com" });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "Id", "NomAuteur" },
                values: new object[,]
                {
                    { "Excel 1", "Antoine de Saint-Exupéry" },
                    { "Excel 10", "René Barjavel" },
                    { "Excel 11", "Giuseppe Tomasi di Lampedusa" },
                    { "Excel 12", "Bernard Werber" },
                    { "Excel 13", "Herman Melville" },
                    { "Excel 14", "Fiodor Dostoïevski" },
                    { "Excel 15", "Mikhaïl Boulgakov" },
                    { "Excel 16", "Patrick Süskind" },
                    { "Excel 17", "Joseph Kessel" },
                    { "Excel 18", "Albert Camus" },
                    { "Excel 19", "Donna Tartt" },
                    { "Excel 2", "J.K. Rowling" },
                    { "Excel 20", "Anne Frank" },
                    { "Excel 22", "Homère" },
                    { "Excel 23", "Ernest Hemingway" },
                    { "Excel 24", "Helen Fielding" },
                    { "Excel 25", "Aldous Huxley" },
                    { "Excel 26", "Paulo Coelho" },
                    { "Excel 27", "Oscar Wilde" },
                    { "Excel 28", "Alexandre Dumas" },
                    { "Excel 3", "George Orwell" },
                    { "Excel 31", "Khaled Hosseini" },
                    { "Excel 32", "Alain-Fournier" },
                    { "Excel 33", "Kurt Cobain" },
                    { "Excel 34", "Charles Baudelaire" },
                    { "Excel 35", "Francis Ponge" },
                    { "Excel 36", "Frères Grimm" },
                    { "Excel 37", "Charles Perrault" },
                    { "Excel 38", "Hans Christian Andersen" },
                    { "Excel 39", "Anonyme (contes populaires)" },
                    { "Excel 4", "J.R.R. Tolkien" },
                    { "Excel 40", "Pierre Gripari" },
                    { "Excel 42", "Catherine Gueguen" },
                    { "Excel 43", "Pierre Rabhi" },
                    { "Excel 44", "Audrey Akoun et Isabelle Pailleau" },
                    { "Excel 45", "Anne Bérubé & Geneviève Racine" }
                });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "Id", "NomAuteur" },
                values: new object[,]
                {
                    { "Excel 46", "Audrey Zucchi" },
                    { "Excel 48", "René Goscinny" },
                    { "Excel 49", "Hergé" },
                    { "Excel 5", "Umberto Eco" },
                    { "Excel 50", "Art Spiegelman" },
                    { "Excel 51", "Marjane Satrapi" },
                    { "Excel 52", "Alan Moore" },
                    { "Excel 6", "Jane Austen" },
                    { "Excel 7", "Boris Vian" },
                    { "Excel 8", "Victor Hugo" },
                    { "Excel 9", "Stendhal" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom", "ParentId" },
                values: new object[,]
                {
                    { "1", "Une section dédiée à l'exploration des chefs-d'œuvre artistiques, des mouvements et des artistes qui ont marqué l'histoire.", "Art", null },
                    { "10", "Engagez-vous dans des réflexions profondes et argumentatives sur des enjeux contemporains.", "Essai", null },
                    { "11", "Explorez le monde naturel, de la canopée de la jungle aux profondeurs des océans.", "Faune – Flore", null },
                    { "12", "Évadez-vous avec des guides de voyage et des récits d'aventuriers des quatre coins du monde.", "Géographie – Voyage", null },
                    { "13", "Démystifiez le monde des affaires, la complexité économique et les arcanes du droit.", "Gestion – Économie – droit", null },
                    { "14", "Conseils et astuces pour naviguer dans la vie quotidienne, du bricolage à la gestion du temps.", "Guide pratique", null },
                    { "15", "Immergez-vous dans les moments clés de l'histoire et les débats politiques actuels. ", "Histoire", null },
                    { "16", "Pour un moment de détente, une collection de recueils drôles et de satires.", "Humour", null },
                    { "17", "Restez à la pointe de la technologie avec des guides sur les logiciels, le codage et les innovations numériques.", "Informatique", null },
                    { "18", "Une riche collection de classiques et de nouvelles œuvres, pour les amateurs de belle lettre.", "Littérature", null },
                    { "19", "Inspirez-vous pour votre prochaine aventure, qu'elle soit en pleine nature ou dans une métropole animée.", "Loisir, Tourisme, Nature", null },
                    { "2", "Plongez dans un monde de bien-être, d'esthétique et d'équilibre pour enrichir votre quotidien.", "Art de vivre", null },
                    { "20", "Des ressources pour les parents et ceux qui aspirent à le devenir, pour une vie familiale épanouie.", "Maternité – Famille", null },
                    { "21", "Laissez-vous emporter par le rythme des vers, l'intensité du théâtre et la profondeur des essais.", "Poésie – Théâtre – Essais", null },
                    { "22", "omprenez mieux la complexité de l'esprit humain et les clés d'une vie saine.", "Psychologie – Santé", null },
                    { "23", "Explorez les croyances spirituelles du monde entier, des textes sacrés aux mystères ésotériques.", "Religion – Ésotérisme", null },
                    { "24", "Voyagez dans des mondes parallèles, où l'imaginaire rencontre souvent la réflexion profonde.", "Roman de science-fiction et fantastique", null },
                    { "25", "Des romans venus de France et d'ailleurs pour vous transporter dans de multiples univers narratifs.", "Roman français et étranger ", null },
                    { "26", "Plongez dans des enquêtes palpitantes, des énigmes à résoudre et des mystères à élucider.", "Roman policier", null },
                    { "27", "Découvrez la richesse de la littérature québécoise, avec ses voix uniques et ses paysages envoûtants.", "Roman québécois", null },
                    { "28", "Éclairez votre curiosité avec des textes scientifiques accessibles et informatifs.", "Savoir Sciences", null },
                    { "29", "De la biologie à la physique, découvrez les dernières découvertes et théories.", "Sciences", null },
                    { "3", "De colorées bandes dessinées aux histoires captivantes pour les plus jeunes, sans oublier une touche d'humour.", "BD, Jeunesse, Humour", null },
                    { "30", "Des textes éclairants pour comprendre et explorer la diversité de la sexualité humaine.", "Sexualité", null },
                    { "31", "Pour les passionnés de sport et les chercheurs d'activités, des histoires inspirantes aux guides pratiques.", "Sport", null },
                    { "4", "Un vaste choix de narrations graphiques, des super-héros aux récits autobiographiques.", "Bandes dessinées", null },
                    { "5", "Découvrez les vies fascinantes des personnalités qui ont façonné le monde.", "Biographie", null },
                    { "6", "Voyagez dans des mondes lointains avec des histoires intemporelles, des fables et des légendes.", "Conte", null },
                    { "7", "Des recettes alléchantes aux guides sommeliers, découvrez les saveurs du monde.", "Cuisine – Vin", null },
                    { "8", "Approfondissez votre compréhension des sociétés contemporaines et de leurs nuances culturelles.", "Culture et Société", null },
                    { "9", "Des ressources pour les linguistes, les étudiants et les éternels apprenants.", "Dictionnaire – Langues – Éducation", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom", "ParentId" },
                values: new object[,]
                {
                    { "Excel 34", "", "Poésie", null },
                    { "Excel 42", "", "Pédagogie", null },
                    { "Excel 43", "", "Maternité", null },
                    { "Excel 48", "", "BD", null }
                });

            migrationBuilder.InsertData(
                table: "Langues",
                columns: new[] { "Id", "Code", "Nom" },
                values: new object[,]
                {
                    { "1", "fr", "Français" },
                    { "2", "en", "Anglais" }
                });

            migrationBuilder.InsertData(
                table: "MaisonEditions",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { "Excel 1", "Gallimard" },
                    { "Excel 10", "Folio" },
                    { "Excel 11", "Gallimard" },
                    { "Excel 12", "Albin Michel" },
                    { "Excel 13", "Penguin Classics" },
                    { "Excel 14", "Le Livre de Poche" },
                    { "Excel 15", "Le Livre de Poche" },
                    { "Excel 16", "Pocket" },
                    { "Excel 17", "Gallimard" },
                    { "Excel 18", "Gallimard" },
                    { "Excel 19", "Plume de Paon" },
                    { "Excel 2", "Gallimard Jeunesse" },
                    { "Excel 20", "Le Livre de Poche" },
                    { "Excel 21", "Folio" },
                    { "Excel 22", "Flammarion" },
                    { "Excel 23", "Folio" },
                    { "Excel 24", "Belfond" },
                    { "Excel 25", "Pocket" },
                    { "Excel 26", "Flammarion" },
                    { "Excel 27", "Livre de Poche Classiques" },
                    { "Excel 28", "Le Livre de Poche" },
                    { "Excel 29", "Christian Bourgois Éditeur" },
                    { "Excel 3", "Secker and Warburg" },
                    { "Excel 30", "Le Livre de Poche" },
                    { "Excel 31", "Belfond" },
                    { "Excel 32", "Le Livre de Poche" },
                    { "Excel 33", "Camion Blanc" },
                    { "Excel 34", "Le Livre de Poche" },
                    { "Excel 35", "Gallimard" },
                    { "Excel 36", "Gallimard" },
                    { "Excel 37", "Le Livre de Poche" },
                    { "Excel 38", "Flammarion" },
                    { "Excel 39", "Le Livre de Poche" },
                    { "Excel 4", "Christian Bourgois Éditeur" },
                    { "Excel 40", "Folio Junior" },
                    { "Excel 42", "Les Arènes" }
                });

            migrationBuilder.InsertData(
                table: "MaisonEditions",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { "Excel 43", "Actes Sud" },
                    { "Excel 44", "Eyrolles" },
                    { "Excel 45", "Nathan" },
                    { "Excel 46", "Eyrolles" },
                    { "Excel 48", "Hachette" },
                    { "Excel 49", "Casterman" },
                    { "Excel 5", "Grasset" },
                    { "Excel 50", "Flammarion" },
                    { "Excel 51", "L'Association" },
                    { "Excel 52", "DC Comics" },
                    { "Excel 6", "Penguin Classics" },
                    { "Excel 7", "Gallimard" },
                    { "Excel 8", "Penguin Classics" },
                    { "Excel 9", "Le Livre de Poche" }
                });

            migrationBuilder.InsertData(
                table: "StatutCommande",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { "1", "En attente" },
                    { "2", "En cours de traitement" },
                    { "3", "En cours de livraison" },
                    { "4", "Livrée" },
                    { "5", "Annulée" }
                });

            migrationBuilder.InsertData(
                table: "TypeLivres",
                columns: new[] { "Id", "Nom", "Prix" },
                values: new object[,]
                {
                    { "Numérique Excel 10", "Numérique", 22.0 },
                    { "Numérique Excel 12", "Numérique", 20.0 },
                    { "Numérique Excel 13", "Numérique", 18.0 },
                    { "Numérique Excel 15", "Numérique", 22.0 },
                    { "Numérique Excel 16", "Numérique", 14.0 },
                    { "Numérique Excel 2", "Numérique", 30.0 },
                    { "Numérique Excel 22", "Numérique", 31.5 },
                    { "Numérique Excel 23", "Numérique", 24.75 },
                    { "Numérique Excel 24", "Numérique", 15.0 },
                    { "Numérique Excel 25", "Numérique", 20.0 },
                    { "Numérique Excel 29", "Numérique", 32.0 },
                    { "Numérique Excel 36", "Numérique", 24.0 },
                    { "Numérique Excel 37", "Numérique", 28.0 },
                    { "Numérique Excel 38", "Numérique", 20.0 },
                    { "Numérique Excel 39", "Numérique", 22.0 },
                    { "Numérique Excel 4", "Numérique", 27.0 },
                    { "Numérique Excel 40", "Numérique", 12.0 },
                    { "Numérique Excel 42", "Numérique", 50.0 },
                    { "Numérique Excel 43", "Numérique", 21.0 },
                    { "Numérique Excel 44", "Numérique", 48.0 },
                    { "Numérique Excel 45", "Numérique", 30.0 },
                    { "Numérique Excel 46", "Numérique", 25.0 },
                    { "Papier Excel 1", "Papier", 22.25 }
                });

            migrationBuilder.InsertData(
                table: "TypeLivres",
                columns: new[] { "Id", "Nom", "Prix" },
                values: new object[,]
                {
                    { "Papier Excel 10", "Papier", 32.0 },
                    { "Papier Excel 11", "Papier", 28.0 },
                    { "Papier Excel 12", "Papier", 26.0 },
                    { "Papier Excel 13", "Papier", 22.0 },
                    { "Papier Excel 14", "Papier", 13.0 },
                    { "Papier Excel 15", "Papier", 24.0 },
                    { "Papier Excel 16", "Papier", 18.0 },
                    { "Papier Excel 17", "Papier", 30.0 },
                    { "Papier Excel 18", "Papier", 18.0 },
                    { "Papier Excel 19", "Papier", 25.0 },
                    { "Papier Excel 2", "Papier", 32.75 },
                    { "Papier Excel 20", "Papier", 19.75 },
                    { "Papier Excel 21", "Papier", 22.0 },
                    { "Papier Excel 22", "Papier", 31.5 },
                    { "Papier Excel 23", "Papier", 24.75 },
                    { "Papier Excel 24", "Papier", 18.25 },
                    { "Papier Excel 25", "Papier", 26.0 },
                    { "Papier Excel 26", "Papier", 18.0 },
                    { "Papier Excel 27", "Papier", 21.0 },
                    { "Papier Excel 28", "Papier", 17.0 },
                    { "Papier Excel 29", "Papier", 36.0 },
                    { "Papier Excel 3", "Papier", 18.0 },
                    { "Papier Excel 30", "Papier", 15.0 },
                    { "Papier Excel 31", "Papier", 16.0 },
                    { "Papier Excel 32", "Papier", 21.0 },
                    { "Papier Excel 33", "Papier", 22.0 },
                    { "Papier Excel 34", "Papier", 19.5 },
                    { "Papier Excel 35", "Papier", 24.0 },
                    { "Papier Excel 36", "Papier", 32.0 },
                    { "Papier Excel 37", "Papier", 36.0 },
                    { "Papier Excel 38", "Papier", 28.0 },
                    { "Papier Excel 39", "Papier", 29.0 },
                    { "Papier Excel 4", "Papier", 29.0 },
                    { "Papier Excel 40", "Papier", 18.0 },
                    { "Papier Excel 42", "Papier", 64.0 },
                    { "Papier Excel 43", "Papier", 21.0 },
                    { "Papier Excel 44", "Papier", 50.0 },
                    { "Papier Excel 45", "Papier", 36.0 },
                    { "Papier Excel 46", "Papier", 25.0 },
                    { "Papier Excel 48", "Papier", 28.0 },
                    { "Papier Excel 49", "Papier", 26.0 },
                    { "Papier Excel 5", "Papier", 19.5 }
                });

            migrationBuilder.InsertData(
                table: "TypeLivres",
                columns: new[] { "Id", "Nom", "Prix" },
                values: new object[,]
                {
                    { "Papier Excel 50", "Papier", 24.0 },
                    { "Papier Excel 51", "Papier", 32.0 },
                    { "Papier Excel 52", "Papier", 31.0 },
                    { "Papier Excel 6", "Papier", 18.75 },
                    { "Papier Excel 7", "Papier", 15.0 },
                    { "Papier Excel 8", "Papier", 21.25 },
                    { "Papier Excel 9", "Papier", 9.75 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "0" },
                    { "0", "1" },
                    { "1", "2" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom", "ParentId" },
                values: new object[,]
                {
                    { "Sous-Catégorie 11-1", "", "Flore", "11" },
                    { "Sous-Catégorie 12-1", "", "Voyage", "12" },
                    { "Sous-Catégorie 13-1", "", "Économie", "13" },
                    { "Sous-Catégorie 13-2", "", "droit", "13" },
                    { "Sous-Catégorie 15-1", "", "Politique", "15" },
                    { "Sous-Catégorie 20-1", "", "Famille", "20" },
                    { "Sous-Catégorie 21-1", "", "Théâtre", "21" },
                    { "Sous-Catégorie 21-2", "", "Essais", "21" },
                    { "Sous-Catégorie 22-1", "", "Santé", "22" },
                    { "Sous-Catégorie 23-1", "", "Ésotérisme", "23" },
                    { "Sous-Catégorie 31-1", "", "Loisirs", "31" },
                    { "Sous-Catégorie 7-1", "", "Vin", "7" },
                    { "Sous-Catégorie 9-1", "", "Langues", "9" },
                    { "Sous-Catégorie 9-2", "", "Éducation", "9" },
                    { "Sous-Catégorie Excel 43-1", "", "Famille", "Excel 43" }
                });

            migrationBuilder.InsertData(
                table: "Livres",
                columns: new[] { "Id", "CommandeId", "Couverture", "DateAjout", "DatePublication", "ISBN", "LangueId", "MaisonEditionId", "NbExemplaires", "NbPages", "Resume", "Titre" },
                values: new object[,]
                {
                    { "Excel 1", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4150), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001193", null, "Excel 1", 24, 96, "", "\"Le Petit Prince\"" },
                    { "Excel 10", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4230), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001202", null, "Excel 10", 32, 464, "", "\"La Nuit des temps\"" },
                    { "Excel 11", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4230), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001203", null, "Excel 11", 2, 256, "", "\"Le Guépard\"" },
                    { "Excel 12", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4240), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001204", null, "Excel 12", 13, 540, "", "\"Les Fourmis\"" },
                    { "Excel 13", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4240), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540102", null, "Excel 13", 62, 720, "", "\"Moby-Dick\"" },
                    { "Excel 14", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4240), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540103", null, "Excel 14", 2, 704, "", "\"Crime et Châtiment\"" },
                    { "Excel 15", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4250), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540104", null, "Excel 15", 2, 480, "", "\"Le Maître et Marguerite\"" },
                    { "Excel 16", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4250), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540105", null, "Excel 16", 14, 255, "", "\"Le Parfum\"" },
                    { "Excel 17", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4250), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540106", null, "Excel 17", 15, 288, "", "\"Le Lion\"" },
                    { "Excel 18", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4250), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540107", null, "Excel 18", 34, 123, "", "\"L'Étranger\"" },
                    { "Excel 19", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4260), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540108", null, "Excel 19", 6, 880, "", "\"Le Chardonneret\"" },
                    { "Excel 2", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4200), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001194", null, "Excel 2", 325, 320, "", "\"Harry Potter à l'école des sorciers\"" },
                    { "Excel 20", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4260), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540109", null, "Excel 20", 2, 384, "", "\"Le Journal d'Anne Frank\"" },
                    { "Excel 21", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4260), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540110", null, "Excel 21", 40, 144, "", "\"La Ferme des Animaux\"" },
                    { "Excel 22", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4270), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540111", null, "Excel 22", 31, 416, "", "\"L'Odyssée\"" },
                    { "Excel 23", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4270), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540112", null, "Excel 23", 20, 128, "", "\"Le Vieil Homme et la Mer\"" },
                    { "Excel 24", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4270), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540113", null, "Excel 24", 21, 320, "", "\"Le Journal de Bridget Jones\"" },
                    { "Excel 25", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4280), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540114", null, "Excel 25", 1, 416, "", "\"Le Meilleur des Mondes\"" },
                    { "Excel 26", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4280), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540115", null, "Excel 26", 15, 192, "", "\"L'Alchimiste\"" },
                    { "Excel 27", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4280), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540116", null, "Excel 27", 4, 384, "", "\"Le Portrait de Dorian Gray\"" },
                    { "Excel 28", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4290), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540118", null, "Excel 28", 6, 1312, "", "\"Le Comte de Monte-Cristo\"" },
                    { "Excel 29", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4290), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540119", null, "Excel 29", 20, 320, "", "\"Le Hobbit\"" },
                    { "Excel 3", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4210), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001195", null, "Excel 3", 3, 328, "", "\"1984\"" },
                    { "Excel 30", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4290), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540120", null, "Excel 30", 21, 704, "", "\"Les Trois Mousquetaires\"" }
                });

            migrationBuilder.InsertData(
                table: "Livres",
                columns: new[] { "Id", "CommandeId", "Couverture", "DateAjout", "DatePublication", "ISBN", "LangueId", "MaisonEditionId", "NbExemplaires", "NbPages", "Resume", "Titre" },
                values: new object[,]
                {
                    { "Excel 31", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4300), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540121", null, "Excel 31", 2, 368, "", "\"Les Cerfs-volants de Kaboul\"" },
                    { "Excel 32", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4300), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540122", null, "Excel 32", 0, 224, "", "\"Le Grand Meaulnes\"" },
                    { "Excel 33", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4300), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540123", null, "Excel 33", 10, 304, "", "\"Le Journal de Kurt Cobain\"" },
                    { "Excel 34", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4310), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "978-2253004229", null, "Excel 34", 0, 288, "", "\"Les Fleurs du Mal\"" },
                    { "Excel 35", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4310), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "978-2070367980", null, "Excel 35", 30, 128, "", "\"Le Parti pris des choses\"" },
                    { "Excel 36", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4310), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140586", null, "Excel 36", 2, 288, "", "Les Contes de Grimm" },
                    { "Excel 37", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4320), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140589", null, "Excel 37", 12, 192, "", "Contes de Perrault" },
                    { "Excel 38", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4320), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140590", null, "Excel 38", 13, 384, "", "Les Contes d'Andersen" },
                    { "Excel 39", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4320), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140591", null, "Excel 39", 50, 832, "", "Contes des Mille et Une Nuits" },
                    { "Excel 4", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4210), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001196", null, "Excel 4", 60, 576, "", "\"Le Seigneur des Anneaux : La Communauté de l'Anneau\"" },
                    { "Excel 40", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4330), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140592", null, "Excel 40", 21, 160, "", "Contes de la Rue Broca" },
                    { "Excel 42", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4330), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140594", null, "Excel 42", 3, 400, "", "\"Pédagogie positive\"" },
                    { "Excel 43", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4340), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140595", null, "Excel 43", 23, 160, "", "\"L'École du Colibri\"" },
                    { "Excel 44", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4340), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140596", null, "Excel 44", 2, 288, "", "\"Apprendre autrement avec la pédagogie positive\"" },
                    { "Excel 45", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4340), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140597", null, "Excel 45", 150, 320, "", "\"Le guide de survie enseignant suppléant\"" },
                    { "Excel 46", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4350), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140598", null, "Excel 46", 3, 192, "", "\"La pédagogie Montessori à la maison\"" },
                    { "Excel 48", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4350), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782012101320", null, "Excel 48", 20, 48, "", "\"Astérix le Gaulois\"" },
                    { "Excel 49", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4360), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001193", null, "Excel 49", 12, 62, "", "\"Tintin au Tibet\"" },
                    { "Excel 5", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4210), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001197", null, "Excel 5", 3, 592, "", "\"Le Nom de la Rose\"" },
                    { "Excel 50", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4360), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782070540102", null, "Excel 50", 2, 296, "", "\"Maus\"" },
                    { "Excel 51", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4360), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782844140587", null, "Excel 51", 6, 352, "", "\"Persepolis\"" },
                    { "Excel 52", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4370), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "978-2-8094-3960-2", null, "Excel 52", 8, 416, "", "\"Watchmen\"" },
                    { "Excel 6", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4220), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001198", null, "Excel 6", 5, 384, "", "\"Orgueil et Préjugés\"" },
                    { "Excel 7", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4220), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001199", null, "Excel 7", 10, 316, "", "\"L'Écume des Jours\"" },
                    { "Excel 8", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4220), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001200", null, "Excel 8", 12, 1232, "", "\"Les Misérables\"" },
                    { "Excel 9", null, "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4220), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9782203001201", null, "Excel 9", 1, 576, "", "\"Le Rouge et le Noir\"" }
                });

            migrationBuilder.InsertData(
                table: "LivreAuteurs",
                columns: new[] { "AuteurId", "LivreId" },
                values: new object[,]
                {
                    { "Excel 1", "Excel 1" },
                    { "Excel 10", "Excel 10" },
                    { "Excel 11", "Excel 11" },
                    { "Excel 12", "Excel 12" },
                    { "Excel 13", "Excel 13" },
                    { "Excel 14", "Excel 14" },
                    { "Excel 15", "Excel 15" },
                    { "Excel 16", "Excel 16" },
                    { "Excel 17", "Excel 17" },
                    { "Excel 18", "Excel 18" },
                    { "Excel 19", "Excel 19" },
                    { "Excel 2", "Excel 2" },
                    { "Excel 20", "Excel 20" },
                    { "Excel 3", "Excel 21" },
                    { "Excel 22", "Excel 22" },
                    { "Excel 23", "Excel 23" },
                    { "Excel 24", "Excel 24" },
                    { "Excel 25", "Excel 25" },
                    { "Excel 26", "Excel 26" },
                    { "Excel 27", "Excel 27" },
                    { "Excel 28", "Excel 28" },
                    { "Excel 4", "Excel 29" },
                    { "Excel 3", "Excel 3" },
                    { "Excel 28", "Excel 30" },
                    { "Excel 31", "Excel 31" },
                    { "Excel 32", "Excel 32" },
                    { "Excel 33", "Excel 33" },
                    { "Excel 34", "Excel 34" },
                    { "Excel 35", "Excel 35" },
                    { "Excel 36", "Excel 36" },
                    { "Excel 37", "Excel 37" },
                    { "Excel 38", "Excel 38" },
                    { "Excel 39", "Excel 39" },
                    { "Excel 4", "Excel 4" },
                    { "Excel 40", "Excel 40" },
                    { "Excel 42", "Excel 42" },
                    { "Excel 43", "Excel 43" },
                    { "Excel 44", "Excel 44" },
                    { "Excel 45", "Excel 45" },
                    { "Excel 46", "Excel 46" },
                    { "Excel 48", "Excel 48" },
                    { "Excel 49", "Excel 49" }
                });

            migrationBuilder.InsertData(
                table: "LivreAuteurs",
                columns: new[] { "AuteurId", "LivreId" },
                values: new object[,]
                {
                    { "Excel 5", "Excel 5" },
                    { "Excel 50", "Excel 50" },
                    { "Excel 51", "Excel 51" },
                    { "Excel 52", "Excel 52" },
                    { "Excel 6", "Excel 6" },
                    { "Excel 7", "Excel 7" },
                    { "Excel 8", "Excel 8" },
                    { "Excel 9", "Excel 9" }
                });

            migrationBuilder.InsertData(
                table: "LivreCategories",
                columns: new[] { "CategorieId", "LivreId" },
                values: new object[,]
                {
                    { "18", "Excel 1" },
                    { "18", "Excel 10" },
                    { "18", "Excel 11" },
                    { "18", "Excel 12" },
                    { "18", "Excel 13" },
                    { "18", "Excel 14" },
                    { "18", "Excel 15" },
                    { "18", "Excel 16" },
                    { "18", "Excel 17" },
                    { "18", "Excel 18" },
                    { "18", "Excel 19" },
                    { "18", "Excel 2" },
                    { "18", "Excel 20" },
                    { "18", "Excel 21" },
                    { "18", "Excel 22" },
                    { "18", "Excel 23" },
                    { "18", "Excel 24" },
                    { "18", "Excel 25" },
                    { "18", "Excel 26" },
                    { "18", "Excel 27" },
                    { "18", "Excel 28" },
                    { "18", "Excel 29" },
                    { "18", "Excel 3" },
                    { "18", "Excel 30" },
                    { "18", "Excel 31" },
                    { "18", "Excel 32" },
                    { "5", "Excel 33" },
                    { "Excel 34", "Excel 34" },
                    { "Excel 34", "Excel 35" },
                    { "6", "Excel 36" },
                    { "6", "Excel 37" },
                    { "6", "Excel 38" },
                    { "6", "Excel 39" },
                    { "18", "Excel 4" }
                });

            migrationBuilder.InsertData(
                table: "LivreCategories",
                columns: new[] { "CategorieId", "LivreId" },
                values: new object[,]
                {
                    { "6", "Excel 40" },
                    { "Excel 42", "Excel 42" },
                    { "Excel 43", "Excel 43" },
                    { "Excel 42", "Excel 44" },
                    { "Excel 42", "Excel 45" },
                    { "Excel 42", "Excel 46" },
                    { "Excel 48", "Excel 48" },
                    { "Excel 48", "Excel 49" },
                    { "18", "Excel 5" },
                    { "Excel 48", "Excel 50" },
                    { "Excel 48", "Excel 51" },
                    { "Excel 48", "Excel 52" },
                    { "18", "Excel 6" },
                    { "18", "Excel 7" },
                    { "18", "Excel 8" },
                    { "18", "Excel 9" }
                });

            migrationBuilder.InsertData(
                table: "LivreTypeLivres",
                columns: new[] { "LivreId", "TypeLivreId", "Prix" },
                values: new object[,]
                {
                    { "Excel 1", "Papier Excel 1", 0m },
                    { "Excel 10", "Numérique Excel 10", 0m },
                    { "Excel 10", "Papier Excel 10", 0m },
                    { "Excel 11", "Papier Excel 11", 0m },
                    { "Excel 12", "Numérique Excel 12", 0m },
                    { "Excel 12", "Papier Excel 12", 0m },
                    { "Excel 13", "Numérique Excel 13", 0m },
                    { "Excel 13", "Papier Excel 13", 0m },
                    { "Excel 14", "Papier Excel 14", 0m },
                    { "Excel 15", "Numérique Excel 15", 0m },
                    { "Excel 15", "Papier Excel 15", 0m },
                    { "Excel 16", "Numérique Excel 16", 0m },
                    { "Excel 16", "Papier Excel 16", 0m },
                    { "Excel 17", "Papier Excel 17", 0m },
                    { "Excel 18", "Papier Excel 18", 0m },
                    { "Excel 19", "Papier Excel 19", 0m },
                    { "Excel 2", "Numérique Excel 2", 0m },
                    { "Excel 2", "Papier Excel 2", 0m },
                    { "Excel 20", "Papier Excel 20", 0m },
                    { "Excel 21", "Papier Excel 21", 0m },
                    { "Excel 22", "Numérique Excel 22", 0m },
                    { "Excel 22", "Papier Excel 22", 0m },
                    { "Excel 23", "Numérique Excel 23", 0m },
                    { "Excel 23", "Papier Excel 23", 0m },
                    { "Excel 24", "Numérique Excel 24", 0m },
                    { "Excel 24", "Papier Excel 24", 0m }
                });

            migrationBuilder.InsertData(
                table: "LivreTypeLivres",
                columns: new[] { "LivreId", "TypeLivreId", "Prix" },
                values: new object[,]
                {
                    { "Excel 25", "Numérique Excel 25", 0m },
                    { "Excel 25", "Papier Excel 25", 0m },
                    { "Excel 26", "Papier Excel 26", 0m },
                    { "Excel 27", "Papier Excel 27", 0m },
                    { "Excel 28", "Papier Excel 28", 0m },
                    { "Excel 29", "Numérique Excel 29", 0m },
                    { "Excel 29", "Papier Excel 29", 0m },
                    { "Excel 3", "Papier Excel 3", 0m },
                    { "Excel 30", "Papier Excel 30", 0m },
                    { "Excel 31", "Papier Excel 31", 0m },
                    { "Excel 32", "Papier Excel 32", 0m },
                    { "Excel 33", "Papier Excel 33", 0m },
                    { "Excel 34", "Papier Excel 34", 0m },
                    { "Excel 35", "Papier Excel 35", 0m },
                    { "Excel 36", "Numérique Excel 36", 0m },
                    { "Excel 36", "Papier Excel 36", 0m },
                    { "Excel 37", "Numérique Excel 37", 0m },
                    { "Excel 37", "Papier Excel 37", 0m },
                    { "Excel 38", "Numérique Excel 38", 0m },
                    { "Excel 38", "Papier Excel 38", 0m },
                    { "Excel 39", "Numérique Excel 39", 0m },
                    { "Excel 39", "Papier Excel 39", 0m },
                    { "Excel 4", "Numérique Excel 4", 0m },
                    { "Excel 4", "Papier Excel 4", 0m },
                    { "Excel 40", "Numérique Excel 40", 0m },
                    { "Excel 40", "Papier Excel 40", 0m },
                    { "Excel 42", "Numérique Excel 42", 0m },
                    { "Excel 42", "Papier Excel 42", 0m },
                    { "Excel 43", "Numérique Excel 43", 0m },
                    { "Excel 43", "Papier Excel 43", 0m },
                    { "Excel 44", "Numérique Excel 44", 0m },
                    { "Excel 44", "Papier Excel 44", 0m },
                    { "Excel 45", "Numérique Excel 45", 0m },
                    { "Excel 45", "Papier Excel 45", 0m },
                    { "Excel 46", "Numérique Excel 46", 0m },
                    { "Excel 46", "Papier Excel 46", 0m },
                    { "Excel 48", "Papier Excel 48", 0m },
                    { "Excel 49", "Papier Excel 49", 0m },
                    { "Excel 5", "Papier Excel 5", 0m },
                    { "Excel 50", "Papier Excel 50", 0m },
                    { "Excel 51", "Papier Excel 51", 0m },
                    { "Excel 52", "Papier Excel 52", 0m }
                });

            migrationBuilder.InsertData(
                table: "LivreTypeLivres",
                columns: new[] { "LivreId", "TypeLivreId", "Prix" },
                values: new object[,]
                {
                    { "Excel 6", "Papier Excel 6", 0m },
                    { "Excel 7", "Papier Excel 7", 0m },
                    { "Excel 8", "Papier Excel 8", 0m },
                    { "Excel 9", "Papier Excel 9", 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_UtilisateurLivraisonId",
                table: "Adresses",
                column: "UtilisateurLivraisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_UtilisateurPrincipalId",
                table: "Adresses",
                column: "UtilisateurPrincipalId",
                unique: true,
                filter: "[UtilisateurPrincipalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_AdresseId",
                table: "Commandes",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_MembreId",
                table: "Commandes",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_StatutCommandeId",
                table: "Commandes",
                column: "StatutCommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_LivreId",
                table: "Evaluations",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_MembreId",
                table: "Evaluations",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoris_LivreId",
                table: "Favoris",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_LivreAuteurs_AuteurId",
                table: "LivreAuteurs",
                column: "AuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_LivreCategories_CategorieId",
                table: "LivreCategories",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_LivreCommandes_CommandeId",
                table: "LivreCommandes",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_LivrePromotions_PromotionsId",
                table: "LivrePromotions",
                column: "PromotionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Livres_CommandeId",
                table: "Livres",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_Livres_LangueId",
                table: "Livres",
                column: "LangueId");

            migrationBuilder.CreateIndex(
                name: "IX_Livres_MaisonEditionId",
                table: "Livres",
                column: "MaisonEditionId");

            migrationBuilder.CreateIndex(
                name: "IX_LivreTypeLivres_TypeLivreId",
                table: "LivreTypeLivres",
                column: "TypeLivreId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_EvenementId",
                table: "Reservations",
                column: "EvenementId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MembreId",
                table: "Reservations",
                column: "MembreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Favoris");

            migrationBuilder.DropTable(
                name: "LivreAuteurs");

            migrationBuilder.DropTable(
                name: "LivreCategories");

            migrationBuilder.DropTable(
                name: "LivreCommandes");

            migrationBuilder.DropTable(
                name: "LivrePromotions");

            migrationBuilder.DropTable(
                name: "LivreTypeLivres");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Livres");

            migrationBuilder.DropTable(
                name: "TypeLivres");

            migrationBuilder.DropTable(
                name: "Evenements");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Langues");

            migrationBuilder.DropTable(
                name: "MaisonEditions");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "StatutCommande");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
