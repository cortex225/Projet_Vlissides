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
                    AdresseLivraisonId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    LivreId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "Employes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NoEmploye = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employes_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Membres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NoMembre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdhesion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommandeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membres_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
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
                        name: "FK_Commandes_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commandes_StatutCommande_StatutCommandeId",
                        column: x => x.StatutCommandeId,
                        principalTable: "StatutCommande",
                        principalColumn: "Id");
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
                        name: "FK_Reservations_Evenements_EvenementId",
                        column: x => x.EvenementId,
                        principalTable: "Evenements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
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
                    NbExemplaires = table.Column<int>(type: "int", nullable: false),
                    DateAjout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NbPages = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuteurId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaisonEditionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategorieId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeLivreId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangueId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromotionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_Livres_MaisonEditions_MaisonEditionId",
                        column: x => x.MaisonEditionId,
                        principalTable: "MaisonEditions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuteurLivre",
                columns: table => new
                {
                    AuteurId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivresId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuteurLivre", x => new { x.AuteurId, x.LivresId });
                    table.ForeignKey(
                        name: "FK_AuteurLivre_Auteurs_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Auteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuteurLivre_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategorieLivre",
                columns: table => new
                {
                    CategoriesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivresId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieLivre", x => new { x.CategoriesId, x.LivresId });
                    table.ForeignKey(
                        name: "FK_CategorieLivre_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieLivre_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Evaluations_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluations_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
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
                        name: "FK_Favoris_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoris_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LangueLivre",
                columns: table => new
                {
                    LanguesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivresId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangueLivre", x => new { x.LanguesId, x.LivresId });
                    table.ForeignKey(
                        name: "FK_LangueLivre_Langues_LanguesId",
                        column: x => x.LanguesId,
                        principalTable: "Langues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LangueLivre_Livres_LivresId",
                        column: x => x.LivresId,
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
                name: "LivreTypeLivre",
                columns: table => new
                {
                    LivresId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypesLivreId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivreTypeLivre", x => new { x.LivresId, x.TypesLivreId });
                    table.ForeignKey(
                        name: "FK_LivreTypeLivre_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivreTypeLivre_TypeLivres_TypesLivreId",
                        column: x => x.TypesLivreId,
                        principalTable: "TypeLivres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0", "73ed39da-de3a-4404-992a-83e893250025", "Employe", "EMPLOYE" },
                    { "1", "1b36f216-6176-473c-b34c-74be55b89fc0", "Membre", "MEMBRE" },
                    { "2", "223c403f-7399-456a-8755-f5b2232ff529", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdresseLivraisonId", "AdressePrincipaleId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0", 0, null, null, "c52aff9c-5bec-44fc-8f7e-5c0db01b93f0", "admin@admin.com", true, false, null, "ADMIN", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Admin", "aa69f16b-eedc-4d5c-ad6e-80dc0fe6c686", false, "admin@admin.com" },
                    { "1", 0, null, "", "a396df39-c77b-4c7c-b3c1-4f51f5e0d89a", "employe@employe.com", true, false, null, "EMPLOYE", "EMPLOYE@EMPLOYE.COM", "EMPLOYE@EMPLOYE.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Employe", "b97722dc-1096-4926-9f1f-68c7e8eddfd0", false, "employe@employe.com" },
                    { "2", 0, null, "", "cc5cb50a-bcd1-4226-9fa8-4e91edcb4e31", "membre@membre.com", true, false, null, "MEMBRE", "MEMBRE@MEMBRE.COM", "MEMBRE@MEMBRE.COM", "AQAAAAEAACcQAAAAEP5A0+Sh49GqZJZev/DKqD7yieTvqVejrmGV0mV6PL5KNos4tLJnJL1tHceX7HezGA==", null, false, "Membre", "fa819313-5278-4f41-9277-f7c980f96df8", false, "membre@membre.com" }
                });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "Id", "NomAuteur" },
                values: new object[] { "0", "Tony" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[,]
                {
                    { "1", "Une section dédiée à l'exploration des chefs-d'œuvre artistiques, des mouvements et des artistes qui ont marqué l'histoire.", "Art" },
                    { "10", "Engagez-vous dans des réflexions profondes et argumentatives sur des enjeux contemporains.", "Essai" },
                    { "11", "Explorez le monde naturel, de la canopée de la jungle aux profondeurs des océans.", "Faune – Flore" },
                    { "12", "Évadez-vous avec des guides de voyage et des récits d'aventuriers des quatre coins du monde.", "Géographie – Voyage" },
                    { "13", "Démystifiez le monde des affaires, la complexité économique et les arcanes du droit.", "Gestion – Économie – droit" },
                    { "14", "Conseils et astuces pour naviguer dans la vie quotidienne, du bricolage à la gestion du temps.", "Guide pratique" },
                    { "15", "Immergez-vous dans les moments clés de l'histoire et les débats politiques actuels. ", "Histoire - Politique" },
                    { "16", "Pour un moment de détente, une collection de recueils drôles et de satires.", "Humour" },
                    { "17", "Restez à la pointe de la technologie avec des guides sur les logiciels, le codage et les innovations numériques.", "Informatique" },
                    { "18", "Une riche collection de classiques et de nouvelles œuvres, pour les amateurs de belle lettre.", "Littérature" },
                    { "19", "Inspirez-vous pour votre prochaine aventure, qu'elle soit en pleine nature ou dans une métropole animée.", "Loisir, Tourisme, Nature" },
                    { "2", "Plongez dans un monde de bien-être, d'esthétique et d'équilibre pour enrichir votre quotidien.", "Art de vivre" },
                    { "20", "Des ressources pour les parents et ceux qui aspirent à le devenir, pour une vie familiale épanouie.", "Maternité – Famille" },
                    { "21", "Laissez-vous emporter par le rythme des vers, l'intensité du théâtre et la profondeur des essais.", "Poésie – Théâtre – Essais" },
                    { "22", "omprenez mieux la complexité de l'esprit humain et les clés d'une vie saine.", "Psychologie – Santé" },
                    { "23", "Explorez les croyances spirituelles du monde entier, des textes sacrés aux mystères ésotériques.", "Religion – Ésotérisme" },
                    { "24", "Voyagez dans des mondes parallèles, où l'imaginaire rencontre souvent la réflexion profonde.", "Roman de science-fiction et fantastique" },
                    { "25", "Des romans venus de France et d'ailleurs pour vous transporter dans de multiples univers narratifs.", "Roman français et étranger " },
                    { "26", "Plongez dans des enquêtes palpitantes, des énigmes à résoudre et des mystères à élucider.", "Roman policier" },
                    { "27", "Découvrez la richesse de la littérature québécoise, avec ses voix uniques et ses paysages envoûtants.", "Roman québécois" },
                    { "28", "Éclairez votre curiosité avec des textes scientifiques accessibles et informatifs.", "Savoir Sciences" },
                    { "29", "De la biologie à la physique, découvrez les dernières découvertes et théories.", "Sciences" },
                    { "3", "De colorées bandes dessinées aux histoires captivantes pour les plus jeunes, sans oublier une touche d'humour.", "BD, Jeunesse, Humour" },
                    { "30", "Des textes éclairants pour comprendre et explorer la diversité de la sexualité humaine.", "Sexualité" },
                    { "31", "Pour les passionnés de sport et les chercheurs d'activités, des histoires inspirantes aux guides pratiques.", "Sport - Loisirs" },
                    { "4", "Un vaste choix de narrations graphiques, des super-héros aux récits autobiographiques.", "Bandes dessinées" },
                    { "5", "Découvrez les vies fascinantes des personnalités qui ont façonné le monde.", "Biographie" },
                    { "6", "Voyagez dans des mondes lointains avec des histoires intemporelles, des fables et des légendes.", "Conte" },
                    { "7", "Des recettes alléchantes aux guides sommeliers, découvrez les saveurs du monde.", "Cuisine – Vin" },
                    { "8", "Approfondissez votre compréhension des sociétés contemporaines et de leurs nuances culturelles.", "Culture et Société" },
                    { "9", "Des ressources pour les linguistes, les étudiants et les éternels apprenants.", "Dictionnaire – Langues – Éducation" }
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
                values: new object[] { "0", "Maison d'édition par défaut" });

            migrationBuilder.InsertData(
                table: "StatutCommande",
                columns: new[] { "Id", "Nom" },
                values: new object[] { "1", "En attente" });

            migrationBuilder.InsertData(
                table: "StatutCommande",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
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
                    { "1", "Neuf" },
                    { "2", "Numérique" }
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
                table: "Employes",
                columns: new[] { "Id", "NoEmploye" },
                values: new object[] { "1", "007" });

            migrationBuilder.InsertData(
                table: "Membres",
                columns: new[] { "Id", "CommandeId", "DateAdhesion", "NoMembre", "ReservationId" },
                values: new object[] { "2", null, new DateTime(2023, 9, 21, 10, 16, 42, 968, DateTimeKind.Local).AddTicks(4523), "123456", null });

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
                name: "IX_AuteurLivre_LivresId",
                table: "AuteurLivre",
                column: "LivresId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieLivre_LivresId",
                table: "CategorieLivre",
                column: "LivresId");

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
                name: "IX_LangueLivre_LivresId",
                table: "LangueLivre",
                column: "LivresId");

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
                name: "IX_Livres_MaisonEditionId",
                table: "Livres",
                column: "MaisonEditionId");

            migrationBuilder.CreateIndex(
                name: "IX_LivreTypeLivre_TypesLivreId",
                table: "LivreTypeLivre",
                column: "TypesLivreId");

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
                name: "AuteurLivre");

            migrationBuilder.DropTable(
                name: "CategorieLivre");

            migrationBuilder.DropTable(
                name: "Employes");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Favoris");

            migrationBuilder.DropTable(
                name: "LangueLivre");

            migrationBuilder.DropTable(
                name: "LivreCommandes");

            migrationBuilder.DropTable(
                name: "LivrePromotions");

            migrationBuilder.DropTable(
                name: "LivreTypeLivre");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Langues");

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
                name: "MaisonEditions");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Membres");

            migrationBuilder.DropTable(
                name: "StatutCommande");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
