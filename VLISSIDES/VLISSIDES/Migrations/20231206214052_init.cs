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
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false),
                    DerniereUtilisationPromoAnniversaire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoEmploye = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoMembre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdhesion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommandeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StripeCustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "DemandesNotifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivreId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MembreId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationEnvoyee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandesNotifications", x => x.Id);
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
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NbPlacesReservees = table.Column<int>(type: "int", nullable: true)
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
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    NoApartement = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Dons",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montant = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dons_AspNetUsers_UserId",
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
                    MembreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    prixAchat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDemandeAnnuler = table.Column<bool>(type: "bit", nullable: true),
                    Quantite = table.Column<int>(type: "int", nullable: false)
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
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuteurId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategorieId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaisonEditionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TypePromotion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LivresAcheter = table.Column<int>(type: "int", nullable: true),
                    LivresGratuits = table.Column<int>(type: "int", nullable: true),
                    PourcentageRabais = table.Column<int>(type: "int", nullable: true),
                    CodePromo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommandeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivrePanierId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Auteurs_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Auteurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Promotions_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Promotions_MaisonEditions_MaisonEditionId",
                        column: x => x.MaisonEditionId,
                        principalTable: "MaisonEditions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCommande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrixTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MembreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdresseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatutCommandeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDemandeAnnulation = table.Column<bool>(type: "bit", nullable: false),
                    PromotionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commandes_Adresses_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Commandes_AspNetUsers_MembreId",
                        column: x => x.MembreId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commandes_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Commandes_StatutCommande_StatutCommandeId",
                        column: x => x.StatutCommandeId,
                        principalTable: "StatutCommande",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Couverture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlNumerique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbExemplaires = table.Column<int>(type: "int", nullable: false),
                    DateAjout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NbPages = table.Column<int>(type: "int", nullable: false),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaisonEditionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LangueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    PrixAchat = table.Column<double>(type: "float", nullable: false),
                    EnDemandeRetourner = table.Column<bool>(type: "bit", nullable: false),
                    QuantiteARetourner = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeLivreId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_LivreCommandes_TypeLivres_TypeLivreId",
                        column: x => x.TypeLivreId,
                        principalTable: "TypeLivres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LivrePanier",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeLivreId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantite = table.Column<int>(type: "int", nullable: true),
                    PrixOriginal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrixApresPromotion = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PromotionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrePanier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivrePanier_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LivrePanier_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivrePanier_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LivrePanier_TypeLivres_TypeLivreId",
                        column: x => x.TypeLivreId,
                        principalTable: "TypeLivres",
                        principalColumn: "Id");
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
                    { "0", "a5a51af8-8a9d-4e56-ba9b-9785481f7bc4", "Employe", "EMPLOYE" },
                    { "1", "5214457a-12fe-4fa2-a341-3ba5ad36c651", "Membre", "MEMBRE" },
                    { "2", "0754827d-73d8-4f92-a5c2-999a8c41fd47", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "ConcurrencyStamp", "CoverImageUrl", "DateNaissance", "DerniereUtilisationPromoAnniversaire", "Discriminator", "Email", "EmailConfirmed", "IsBanned", "LockoutEnabled", "LockoutEnd", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0", 0, null, "8435c566-ab22-4aa9-b8b4-5e85fabe9ae4", null, null, null, "ApplicationUser", "Admin@LaFourmiAilee.com", true, false, false, null, "ADMIN", "ADMIN@LAFOURMIAILEE.COM", "ADMIN", "AQAAAAEAACcQAAAAEF43OL2o51Yi6zRBnpl0RXloMapVIPngv3SLbD4Xt5WF7mUXEcSIGyMjEDaMUPC/JA==", null, false, "Admin", "c94d61f2-302c-43e0-97cb-cc54fe5d4302", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "ConcurrencyStamp", "CoverImageUrl", "DateNaissance", "DerniereUtilisationPromoAnniversaire", "Discriminator", "Email", "EmailConfirmed", "IsBanned", "LockoutEnabled", "LockoutEnd", "NoEmploye", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "", "5eecdf0d-640d-4f94-b4a9-2c109fde31bf", null, null, null, "Employe", "employe@employe.com", true, false, false, null, "007", "EMPLOYE", "EMPLOYE@EMPLOYE.COM", "EMPLOYE@EMPLOYE.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Employe", "52ae3d4c-3ce5-4033-bc4b-48e749b6f8d5", false, "employe@employe.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "CommandeId", "ConcurrencyStamp", "CoverImageUrl", "DateAdhesion", "DateNaissance", "DerniereUtilisationPromoAnniversaire", "Discriminator", "Email", "EmailConfirmed", "IsBanned", "LockoutEnabled", "LockoutEnd", "NoMembre", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "ReservationId", "SecurityStamp", "StripeCustomerId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d343967-cb36-4514-a5d8-d64b248f3eb9", 0, null, null, "e6d37166-df75-4cfd-93bd-64bc194f3c2d", null, new DateTime(2023, 12, 6, 16, 40, 51, 514, DateTimeKind.Local).AddTicks(3995), new DateTime(2002, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SDemers@gmail.com", true, false, false, null, "67b12e0e-468a-40c3-aedd-35154c510b97", "Demers", "SDEMERS@GMAIL.COM", "SDEMERS@GMAIL.COM", "AQAAAAEAACcQAAAAEFEpbbZ9PAEtOSFhF9QxUt0RwHYPZV9H1Im54l9xvjpEHc5sdrTyMQoTnhPM+3QfbQ==", null, false, "Sylvie", null, "3cb0ba8e-1bb4-4159-b106-7c34fafb5c86", "9", false, "SDemers@gmail.com" },
                    { "2", 0, "", null, "4322384b-6996-4e6b-9383-fd42fe798a27", null, new DateTime(2023, 12, 6, 16, 40, 51, 497, DateTimeKind.Local).AddTicks(2413), null, null, "Membre", "membre@membre.com", true, false, false, null, "123456", "MEMBRE", "MEMBRE@MEMBRE.COM", "MEMBRE@MEMBRE.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Membre", null, "4926566b-d912-4fcd-85d7-fca08e3faf8e", null, false, "membre@membre.com" },
                    { "73f2b3b0-f352-49d3-9e96-92e48e0f2841", 0, null, null, "342168d2-2d5e-4c03-b90a-f6f4c6c87dc9", null, new DateTime(2023, 12, 6, 16, 40, 51, 521, DateTimeKind.Local).AddTicks(3098), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "julien.landry1800@gmail.com", true, false, false, null, "a9a9740f-c061-47eb-9b99-0ffd25fd11d1", "Landry", "JULIEN.LANDRY1800@GMAIL.COM", "JULIEN.LANDRY1800@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Julien", null, "fd28ee8b-4328-41b9-b55c-3aec0508211d", "11", false, "julien.landry1800@gmail.com" },
                    { "79130d7a-bfd4-4597-870c-acb98eabcee8", 0, null, null, "44967a35-7803-4dbc-95aa-a82b99e6f71c", null, new DateTime(2023, 12, 6, 16, 40, 51, 521, DateTimeKind.Local).AddTicks(4916), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "jlgouaho@gmail.com", true, false, false, null, "62006175-c9dd-4f84-8e11-0d624ac5655d", "JEAN-LUC GOUAHO", "JLGOUAHO@GMAIL.COM", "JLGOUAHO@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Deto", null, "1f3b3332-1ada-4bf6-9da8-156ff6183f80", "12", false, "jlgouaho@gmail.com" },
                    { "85761bd9-65e9-4568-9290-ceab2d36498d", 0, null, null, "85f22082-b25a-44e4-b0be-eab28852e678", null, new DateTime(2023, 12, 6, 16, 40, 51, 520, DateTimeKind.Local).AddTicks(9510), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "tonyhuynh0412@gmail.com", true, false, false, null, "d07230f0-cd95-40e4-9942-6339dc0c0ec8", "Huynh", "TONYHUYNH0412@GMAIL.COM", "TONYHUYNH0412@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Tony", null, "cf649511-c90c-47aa-a000-0467a168c8db", "10", false, "tonyhuynh0412@gmail.com" },
                    { "ae645e99-7c97-42c4-a2db-0cee813b8c39", 0, null, null, "5e6b4e14-5c79-4224-92c5-19da9fca9441", null, new DateTime(2023, 12, 6, 16, 40, 51, 508, DateTimeKind.Local).AddTicks(130), new DateTime(1993, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SFallu@gmail.com", true, false, false, null, "bc64fbbd-3696-4515-b1ec-7fde44cff778", "Fallu", "SFALLU@GMAIL.COM", "SFALLU@GMAIL.COM", "AQAAAAEAACcQAAAAEB++GAtnX8MB2kP+Fb8vawUXYbE6fOijAeJWXravAgF1RT3cG+qKBEVJ7Y0pN3iH/A==", null, false, "Stephane", null, "653a88ff-7402-4f11-be43-b36a9f59d0c3", "8", false, "SFallu@gmail.com" },
                    { "c7d81843-cbe3-4709-abd3-d619f8b4d61c", 0, null, null, "68503647-6230-42e0-849b-83e38546993c", null, new DateTime(2023, 12, 6, 16, 40, 51, 497, DateTimeKind.Local).AddTicks(2486), new DateTime(2001, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "MGosselin@gmail.com", true, false, false, null, "1649ec0c-b9d3-4c6d-9fef-67c0c75fb3a7", "Gosselin", "MGOSSELIN@GMAIL.COM", "MGOSSELIN@GMAIL.COM", "AQAAAAEAACcQAAAAEG2FxypOmlwt8wBJ15Lix0ildkx06PGGh8lshSRZV4mL5/gSYSsvDQjjmhhae5AQtA==", null, false, "Marcel", null, "54af64b0-5fb3-4e79-aa15-dd7274e3c064", "7", false, "MGosselin@gmail.com" }
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
                    { "15", "Immergez-vous dans les moments clés de l'histoire et les débats politiques actuels. ", "Histoire - Politique", null },
                    { "16", "Pour un moment de détente, une collection de recueils drôles et de satires.", "Humour", null },
                    { "17", "Restez à la pointe de la technologie avec des guides sur les logiciels, le codage et les innovations numériques.", "Informatique", null },
                    { "18", "Une riche collection de classiques et de nouvelles œuvres, pour les amateurs de belle lettre.", "Littérature", null },
                    { "19", "Inspirez-vous pour votre prochaine aventure, qu'elle soit en pleine nature ou dans une métropole animée.", "Loisir - Tourisme - Nature", null },
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
                    { "3", "De colorées bandes dessinées aux histoires captivantes pour les plus jeunes, sans oublier une touche d'humour.", "BD - Jeunesse - Humour", null },
                    { "30", "Des textes éclairants pour comprendre et explorer la diversité de la sexualité humaine.", "Sexualité", null },
                    { "31", "Pour les passionnés de sport et les chercheurs d'activités, des histoires inspirantes aux guides pratiques.", "Sport - Loisirs", null },
                    { "4", "Un vaste choix de narrations graphiques, des super-héros aux récits autobiographiques.", "Bandes dessinées", null },
                    { "5", "Découvrez les vies fascinantes des personnalités qui ont façonné le monde.", "Biographie", null },
                    { "6", "Voyagez dans des mondes lointains avec des histoires intemporelles, des fables et des légendes.", "Conte", null },
                    { "7", "Des recettes alléchantes aux guides sommeliers, découvrez les saveurs du monde.", "Cuisine – Vin", null },
                    { "8", "Approfondissez votre compréhension des sociétés contemporaines et de leurs nuances culturelles.", "Culture et Société", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom", "ParentId" },
                values: new object[] { "9", "Des ressources pour les linguistes, les étudiants et les éternels apprenants.", "Dictionnaire – Langues – Éducation", null });

            migrationBuilder.InsertData(
                table: "Langues",
                columns: new[] { "Id", "Code", "Nom" },
                values: new object[,]
                {
                    { "1", "fr", "Français" },
                    { "2", "en", "Anglais" }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "AuteurId", "CategorieId", "CodePromo", "CommandeId", "DateDebut", "DateFin", "Description", "Image", "LivrePanierId", "LivresAcheter", "LivresGratuits", "MaisonEditionId", "Nom", "PourcentageRabais", "TypePromotion" },
                values: new object[] { "0", null, null, "BIRTHDAY", null, new DateTime(2023, 12, 6, 16, 40, 51, 523, DateTimeKind.Local).AddTicks(8484), new DateTime(2024, 12, 6, 16, 40, 51, 523, DateTimeKind.Local).AddTicks(8500), "Ce code promo est uniquement valide durant votre mois d'anniversaire.", "/img/images_Promo/birthday.jpg", null, null, null, null, "Promotion Anniversaire", 10, "pourcentage" });

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
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { "1", "Papier" },
                    { "2", "Numérique" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "0" },
                    { "1", "0d343967-cb36-4514-a5d8-d64b248f3eb9" },
                    { "0", "1" },
                    { "1", "2" },
                    { "1", "73f2b3b0-f352-49d3-9e96-92e48e0f2841" },
                    { "1", "79130d7a-bfd4-4597-870c-acb98eabcee8" },
                    { "1", "85761bd9-65e9-4568-9290-ceab2d36498d" },
                    { "1", "ae645e99-7c97-42c4-a2db-0cee813b8c39" },
                    { "1", "c7d81843-cbe3-4709-abd3-d619f8b4d61c" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom", "ParentId" },
                values: new object[,]
                {
                    { "11-2", "", "Flore", "11" },
                    { "12-2", "", "Voyage", "12" },
                    { "13-2", "", "Économie", "13" },
                    { "13-3", "", "droit", "13" },
                    { "15-2", "", "Politique", "15" },
                    { "19-2", "", "Tourisme", "19" },
                    { "19-3", "", "Nature", "19" },
                    { "20-2", "", "Famille", "20" },
                    { "21-2", "", "Théâtre", "21" },
                    { "21-3", "", "Essais", "21" },
                    { "22-2", "", "Santé", "22" },
                    { "23-2", "", "Ésotérisme", "23" },
                    { "3-2", "", "Jeunesse", "3" },
                    { "31-2", "", "Loisirs", "31" },
                    { "7-2", "", "Vin", "7" },
                    { "9-2", "", "Langues", "9" },
                    { "9-3", "", "Éducation", "9" }
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
                name: "IX_Commandes_PromotionId",
                table: "Commandes",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_StatutCommandeId",
                table: "Commandes",
                column: "StatutCommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dons_UserId",
                table: "Dons",
                column: "UserId");

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
                name: "IX_LivreCommandes_TypeLivreId",
                table: "LivreCommandes",
                column: "TypeLivreId");

            migrationBuilder.CreateIndex(
                name: "IX_LivrePanier_LivreId",
                table: "LivrePanier",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_LivrePanier_PromotionId",
                table: "LivrePanier",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_LivrePanier_TypeLivreId",
                table: "LivrePanier",
                column: "TypeLivreId");

            migrationBuilder.CreateIndex(
                name: "IX_LivrePanier_UserId",
                table: "LivrePanier",
                column: "UserId");

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
                name: "IX_Promotions_AuteurId",
                table: "Promotions",
                column: "AuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_CategorieId",
                table: "Promotions",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_MaisonEditionId",
                table: "Promotions",
                column: "MaisonEditionId");

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
                name: "DemandesNotifications");

            migrationBuilder.DropTable(
                name: "Dons");

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
                name: "LivrePanier");

            migrationBuilder.DropTable(
                name: "LivreTypeLivres");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "StatutCommande");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "MaisonEditions");
        }
    }
}
