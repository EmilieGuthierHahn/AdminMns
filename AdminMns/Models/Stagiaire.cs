// Fichier: AdminMns/Models/Stagiaire.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdminMns.Data;
// Assure-toi d'avoir le using pour AppUser si AppUser.cs est dans un autre namespace (ex: AdminMns.Data)
// using AdminMns.Data;

namespace AdminMns.Models
{
    public class Stagiaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStagiaire { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nom { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Prenom { get; set; } = null!;

        public DateTime DateNaissance { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string EmailStagiaire { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [Phone]
        public string Telephone { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Adresse { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Ville { get; set; } = null!;

        [ForeignKey("AppUser")]
        public string UtilisateurId { get; set; } = null!; // Clé étrangère vers AspNetUsers (AppUser.Id)

        // --- PROPRIÉTÉ DE NAVIGATION MANQUANTE À AJOUTER/VÉRIFIER ---

        // Relations inverses
        public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();
        // public virtual ICollection<Candidature> Candidatures { get; set; } = new List<Candidature>(); // Si tu as une relation Stagiaire -> Candidatures
    }
}