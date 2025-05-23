// Dans Models/RaisonRetard.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminMns.Models
{
    [Table("raisons_retard")] // Nom conventionnel pour la table
    public class RaisonRetard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // L'ID est auto-généré par la BDD
        public int IdRaisonRetard { get; set; }

        [Required(ErrorMessage = "Le motif du retard est requis.")]
        [MaxLength(150, ErrorMessage = "Le motif ne peut pas dépasser 150 caractères.")] // Augmenté à 100 pour plus de flexibilité
        public string Motif { get; set; } = null!;
    }
}