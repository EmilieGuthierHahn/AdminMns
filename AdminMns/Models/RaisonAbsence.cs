// Dans Models/RaisonAbsence.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminMns.Models
{
    [Table("raisons_absence")] // Nom conventionnel pour la table
    public class RaisonAbsence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // L'ID est auto-généré par la BDD
        public int IdRaisonAbsence { get; set; }

        [Required(ErrorMessage = "Le motif de l'absence est requis.")]
        [MaxLength(150, ErrorMessage = "Le motif ne peut pas dépasser 150 caractères.")] // Augmenté pour plus de flexibilité
        public string Motif { get; set; } = null!;
    }
}