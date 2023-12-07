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
                    { "0", "110cb6d3-0b4a-4ff6-b8b6-e6dedd983598", "Employe", "EMPLOYE" },
                    { "1", "3021d7ce-ad34-400f-8d36-259707b75658", "Membre", "MEMBRE" },
                    { "2", "7e363143-d17f-4ee7-b56e-b8c44c7a430a", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "ConcurrencyStamp", "CoverImageUrl", "DateNaissance", "DerniereUtilisationPromoAnniversaire", "Discriminator", "Email", "EmailConfirmed", "IsBanned", "LockoutEnabled", "LockoutEnd", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0", 0, null, "d1d41154-228b-45cf-aa6f-e1cff6731c57", null, null, null, "ApplicationUser", "Admin@LaFourmiAilee.com", true, false, false, null, "ADMIN", "ADMIN@LAFOURMIAILEE.COM", "ADMIN", "AQAAAAEAACcQAAAAEArmaxuP2j3GApIrP3Wd6eEoEu4qUPeHIzwT5yu3YYvYhNWf/QV7GzbbJ2x5YmkURw==", null, false, "Admin", "e3bcb8bd-2d2c-49ff-be19-21162db81d5b", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "ConcurrencyStamp", "CoverImageUrl", "DateNaissance", "DerniereUtilisationPromoAnniversaire", "Discriminator", "Email", "EmailConfirmed", "IsBanned", "LockoutEnabled", "LockoutEnd", "NoEmploye", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "", "08658480-40d2-4f1a-86ad-8b88580d801a", null, null, null, "Employe", "employe@employe.com", true, false, false, null, "007", "EMPLOYE", "EMPLOYE@EMPLOYE.COM", "EMPLOYE@EMPLOYE.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Employe", "ffd56fe5-e7c4-4859-af11-53c6c6e9e004", false, "employe@employe.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressePrincipaleId", "CommandeId", "ConcurrencyStamp", "CoverImageUrl", "DateAdhesion", "DateNaissance", "DerniereUtilisationPromoAnniversaire", "Discriminator", "Email", "EmailConfirmed", "IsBanned", "LockoutEnabled", "LockoutEnd", "NoMembre", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "ReservationId", "SecurityStamp", "StripeCustomerId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1cc3577d-0bf6-40f1-b616-c899aaba10b4", 0, null, null, "db7b3e9c-1e5c-48d5-9a2d-835e6bff5591", null, new DateTime(2023, 12, 6, 17, 10, 13, 909, DateTimeKind.Local).AddTicks(9598), new DateTime(2001, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "MGosselin@gmail.com", true, false, false, null, "812d8ca1-16f7-424f-b2dd-f291b4d3cacf", "Gosselin", "MGOSSELIN@GMAIL.COM", "MGOSSELIN@GMAIL.COM", "AQAAAAEAACcQAAAAEB21x2Sh38TgcRSlUPs3RXI+cc7d8m6g+tDNDHgVzklfn2QsONshFVqJAWizWZHOXA==", null, false, "Marcel", null, "279680b1-2880-49d6-b2a5-afd3c8918b3f", "cus_P8knZ1kGW0sz3H", false, "MGosselin@gmail.com" },
                    { "2", 0, "", null, "952d981a-9e7f-40d6-a839-13f9fc633d45", null, new DateTime(2023, 12, 6, 17, 10, 13, 909, DateTimeKind.Local).AddTicks(9524), null, null, "Membre", "membre@membre.com", true, false, false, null, "123456", "MEMBRE", "MEMBRE@MEMBRE.COM", "MEMBRE@MEMBRE.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Membre", null, "e9c61617-e753-4003-9839-2583c919b43e", null, false, "membre@membre.com" },
                    { "630a12a4-2f1b-48f0-9962-92cb14b52864", 0, null, null, "11dd8c99-f85c-46fc-87e4-347994a00cab", null, new DateTime(2023, 12, 6, 17, 10, 15, 20, DateTimeKind.Local).AddTicks(4767), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "julien.landry1800@gmail.com", true, false, false, null, "aabc24df-25c4-4eed-9ec0-3b00d08e4ef5", "Landry", "JULIEN.LANDRY1800@GMAIL.COM", "JULIEN.LANDRY1800@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Julien", null, "ffd09dc2-d3c1-4400-9147-33cc5b4f14e4", "cus_P8knvna8W2zmbt", false, "julien.landry1800@gmail.com" },
                    { "864256e7-58e6-4e0d-b930-59cb013daed4", 0, null, null, "932edc7c-2fb1-40b5-9b05-03397e62037a", null, new DateTime(2023, 12, 6, 17, 10, 14, 744, DateTimeKind.Local).AddTicks(1451), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "tonyhuynh0412@gmail.com", true, false, false, null, "88c8ebe3-4950-47ac-86ba-078f4665dbe7", "Huynh", "TONYHUYNH0412@GMAIL.COM", "TONYHUYNH0412@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Tony", null, "9c98a089-17b0-45d7-8d06-369c376c425c", "cus_P8knhUwfzckmBX", false, "tonyhuynh0412@gmail.com" },
                    { "8fb2569c-a542-4a03-9933-8431f135d50f", 0, null, null, "842876f8-eed7-4c2f-a26e-85260a18e8d6", null, new DateTime(2023, 12, 6, 17, 10, 15, 301, DateTimeKind.Local).AddTicks(4577), new DateTime(2004, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "jlgouaho@gmail.com", true, false, false, null, "e60d8c30-c55d-4f18-866c-82aa6e2a5bb9", "JEAN-LUC GOUAHO", "JLGOUAHO@GMAIL.COM", "JLGOUAHO@GMAIL.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Deto", null, "b20f7db2-832a-42a4-b106-e581637121e0", "cus_P8knXLFm8XLzyv", false, "jlgouaho@gmail.com" },
                    { "c46a0013-3c64-4e20-b850-11500033ca48", 0, null, null, "b7abd779-bd2b-4f9c-b5ad-59e8354eb577", null, new DateTime(2023, 12, 6, 17, 10, 14, 469, DateTimeKind.Local).AddTicks(3062), new DateTime(2002, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SDemers@gmail.com", true, false, false, null, "840a0751-eb47-422b-9de2-e7a09835947b", "Demers", "SDEMERS@GMAIL.COM", "SDEMERS@GMAIL.COM", "AQAAAAEAACcQAAAAEJDaJIqws1VmbIOvRfVYqthTRY6ZJF/4rM6Pls/z++v/0jLlTtqWlWDEypZZRKGc7w==", null, false, "Sylvie", null, "b35c3def-6569-49a6-bd2e-c88ba67e62be", "cus_P8kn4syNS9uDRE", false, "SDemers@gmail.com" },
                    { "e74f0492-8c65-4ff5-8b9f-0672c3184388", 0, null, null, "e72e1414-2aa5-4c81-8b59-48b43b68c9d0", null, new DateTime(2023, 12, 6, 17, 10, 14, 177, DateTimeKind.Local).AddTicks(624), new DateTime(1993, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Membre", "SFallu@gmail.com", true, false, false, null, "dac0f285-cd07-4f21-a716-231ba49aabf6", "Fallu", "SFALLU@GMAIL.COM", "SFALLU@GMAIL.COM", "AQAAAAEAACcQAAAAEE3A6mxzhnQthl+1YkF3q5nIE4afFRFlKJUyQQtyYuEbEUCDbc7eQzVpgMKPAuIfnA==", null, false, "Stephane", null, "24b412cf-1751-4f9b-9542-fb3438af71e8", "cus_P8knyK9oBalz9v", false, "SFallu@gmail.com" }
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
                values: new object[] { "0", null, null, "BIRTHDAY", null, new DateTime(2023, 12, 6, 17, 10, 15, 565, DateTimeKind.Local).AddTicks(1036), new DateTime(2024, 12, 6, 17, 10, 15, 565, DateTimeKind.Local).AddTicks(1138), "Ce code promo est uniquement valide durant votre mois d'anniversaire.", "/img/images_Promo/birthday.jpg", null, null, null, null, "Promotion Anniversaire", 10, "pourcentage" });

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
                    { "0", "1" },
                    { "1", "1cc3577d-0bf6-40f1-b616-c899aaba10b4" },
                    { "1", "2" },
                    { "1", "630a12a4-2f1b-48f0-9962-92cb14b52864" },
                    { "1", "864256e7-58e6-4e0d-b930-59cb013daed4" },
                    { "1", "8fb2569c-a542-4a03-9933-8431f135d50f" },
                    { "1", "c46a0013-3c64-4e20-b850-11500033ca48" },
                    { "1", "e74f0492-8c65-4ff5-8b9f-0672c3184388" }
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
