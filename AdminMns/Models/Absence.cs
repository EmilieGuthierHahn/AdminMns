// Fichier: AdminMns/Models/Absence.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminMns.Models
{
    public class Absence // Le nom de la table est "Absences"
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAbsence { get; set; }

        [Required]
        public DateTime DateDebut { get; set; }
        [Required]
        public DateTime DateFin { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Justificatif { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Motif { get; set; }

        public DateTime DateDeclaration { get; set; } = DateTime.Now;
         
        public int IdStagiaire { get; set; } // Clé étrangère

        [ForeignKey("IdStagiaire")]
        public virtual required Stagiaire Stagiaire { get; set; } //Une Absence appartient à UN Stagiaire
    }
}