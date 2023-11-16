using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionPromotions
{
    public class AjouterPromotionVM
    {
        public AjouterPromotionVM()
        {
        }
        public string Action { get; set; }

        public string Id { get; set; }

        [Display(Name = "Nom de la promotion")] public string Nom { get; set; }
        [Display(Name = "Description")] public string Description { get; set; }

        [Display(Name = "Début de la promotion")] public DateTime DateDebut { get; set; }
        [Display(Name = "Fin de la promotion")] public DateTime DateFin { get; set; }

        public string? ImageUrl { get; set; }
        [Display(Name = "Image de la promotion")] public IFormFile? CoverPhoto { get; set; }
        [Display(Name = "Auteur")] public string Auteur { get; set; }
        [Display(Name = "Auteur")] public List<string> Auteurs { get; set; }

        [Display(Name = "Catégorie")] public string Categorie { get; set; }
        [Display(Name = "Catégorie")] public List<string> Categories { get; set; }

        [Display(Name = "Maison d'édition")] public string MaisonEdition { get; set; }
        [Display(Name = "Maison d'édition")] public List<string> MaisonEditions { get; set; }

        [Display(Name = "Type de promotion")] public string TypePromotion { get; set; }
        [Display(Name = "Type de promotion")] public List<string> TypePromotions { get; set; }

        [Display(Name = "Livres à acheter")] public int LivresAcheter { get; set; }
        [Display(Name = "Livres gratuits")] public int LivresGratuits { get; set; }

        [Display(Name = "Pourcentage du rabais")] public int PourcentageRabais { get; set; }

        [Display(Name = "Code promo")] public string CodePromo { get; set; }

        public AjouterPromotionVM(Promotions promotion = null, List<Auteur> auteurs = null,
            List<Categorie> categories = null, List<MaisonEdition> maisonEditions = null, List<string> typePromotions = null)
        {
            if (promotion == null)
            {
                Action = "Ajouter";
                Id = "";
                Nom = "";
                Description = "";
                DateDebut = DateTime.UtcNow;
                DateFin = DateTime.UtcNow;
                ImageUrl = "";
                Auteur = "";
                Auteurs = new List<string>();
                Categorie = "";
                Categories = new List<string>();
                MaisonEdition = "";
                MaisonEditions = new List<string>();
                TypePromotion = "";
                TypePromotions = typePromotions ?? new();
                LivresAcheter = 1;
                LivresGratuits = 1;
                PourcentageRabais = 1;
                CodePromo = "";
            }
            else
            {
                Action = "";
                Id = promotion.Id;
                Nom = promotion.Nom;
                Description = promotion.Description;
                DateDebut = promotion.DateDebut;
                DateFin = promotion.DateFin;
                ImageUrl = promotion.Image;
                Auteur = promotion.Auteur.NomAuteur;
                Auteurs = auteurs.Select(a => a.NomAuteur).ToList();
                Categorie = promotion.Categorie.Nom;
                Categories = categories.Select(c => c.Nom).ToList();
                MaisonEdition = promotion.MaisonEdition.Nom;
                MaisonEditions = maisonEditions.Select(me => me.Nom).ToList();
                TypePromotion = promotion.TypePromotion;
                TypePromotions = typePromotions ?? new();
                LivresAcheter = promotion.LivresAcheter ?? 1;
                LivresGratuits = promotion.LivresGratuits ?? 1;
                PourcentageRabais = promotion.PourcentageRabais ?? 1;
                CodePromo = promotion.CodePromo;
            }
        }
    }
}
