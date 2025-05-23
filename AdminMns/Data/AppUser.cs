
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace AdminMns.Data
{
   
    public class AppUser : IdentityUser
    {
        [PersonalData]
        [StringLength(100, ErrorMessage = "Le {0} doit être au moins {2} et au maximum {1} caractères.", MinimumLength = 2)]
        public string Nom { get; set; } = string.Empty;

        [PersonalData]
        [StringLength(100, ErrorMessage = "Le {0} doit être au moins {2} et au maximum {1} caractères.", MinimumLength = 2)]
        public string Prenom { get; set; } = string.Empty;

        [PersonalData]
        [StringLength(10, ErrorMessage = "Le {0} doit être au moins {2} et au maximum {1} caractères.", MinimumLength = 1)]
        public string NumeroRue { get; set; } = string.Empty;

        [PersonalData]
        [StringLength(200, ErrorMessage = "Le {0} doit être au moins {2} et au maximum {1} caractères.", MinimumLength = 2)]
        public string NomRue { get; set; } = string.Empty;

        [PersonalData]
        [StringLength(100, ErrorMessage = "Le {0} doit être au moins {2} et au maximum {1} caractères.", MinimumLength = 2)]
        public string Ville { get; set; } = string.Empty;

        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; } = DateTime.MinValue; // Ou DateTime.Today si tu préfères une valeur par défaut

        [PersonalData]
        [Phone(ErrorMessage = "Le numéro de téléphone est invalide.")]
        [StringLength(20, ErrorMessage = "Le {0} doit être au moins {2} et au maximum {1} caractères.", MinimumLength = 10)]
        public string Telephone { get; set; } = string.Empty;

        [PersonalData]
      
        public string Statut { get; set; } = string.Empty;

        [PersonalData]
        [StringLength(50, ErrorMessage = "Le {0} doit être au moins {2} et au maximum {1} caractères.", MinimumLength = 1)]
        public string NumeroEtudiant { get; set; } = string.Empty;

      
    }
}