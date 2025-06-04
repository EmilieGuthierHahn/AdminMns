// Fichier: AdminMns/Models/Retard.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminMns.Models
{
    public class Retard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID auto-généré
        public int IdRetard { get; set; }

        public DateTime? DateArrivee { get; set; }

        [MaxLength(500)]
        public string? Justificatif { get; set; } // Stockera le CHEMIN du fichier, pas le fichier lui-même

        [Required]
        [MaxLength(250)]
        public required string Motif { get; set; }

        [Required]
        [MaxLength(1000)] // Choisissez une longueur appropriée
        public required string Details { get; set; }

        public int IdStagiaire { get; set; } // Clé étrangère

        [ForeignKey("IdStagiaire")]
        public virtual required Stagiaire Stagiaire { get; set; }
    }
}