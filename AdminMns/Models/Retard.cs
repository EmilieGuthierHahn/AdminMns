// Dans Models/Retard.cs
using System;
using System.Collections.Generic; // <-- Assurez-vous que ce using est présent
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminMns.Models
{
    [Table("retards")]
    public class Retard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRetard { get; set; }

        [Display(Name = "Date d'arrivée")]
        public DateTime? DateArrivee { get; set; }

        [MaxLength(500, ErrorMessage = "Le justificatif ne peut pas dépasser 500 caractères.")]
        public string? Justificatif { get; set; }

        [Required(ErrorMessage = "La raison du retard est requise.")]
        public int IdRaisonRetard { get; set; }

        [ForeignKey("IdRaisonRetard")]
        public virtual RaisonRetard? RaisonRetard { get; set; }

        // --- LIGNES AJOUTÉES ---
        // Propriété de navigation vers la table de liaison RetardStagiaire
        // Un retard peut concerner plusieurs stagiaires.
        public virtual ICollection<RetardStagiaire> RetardStagiaires { get; set; }
        // --- FIN DES LIGNES AJOUTÉES ---

        // Constructeur
        public Retard()
        {
            // Si vous avez d'autres collections à initialiser pour l'entité Retard, faites-le ici.

            // --- LIGNE AJOUTÉE DANS LE CONSTRUCTEUR ---
            RetardStagiaires = new HashSet<RetardStagiaire>();
            // --- FIN DE LA LIGNE AJOUTÉE DANS LE CONSTRUCTEUR ---
        }
    }
}