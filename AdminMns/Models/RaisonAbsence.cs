// Fichier: AdminMns/Models/RaisonAbsence.cs/ Nécessaire pour ICollection et HashSet
using System.ComponentModel.DataAnnotations;

namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // [Table("raisons_absence")] // Décommentez si vous voulez un nom de table spécifique
    public class RaisonAbsence
    {
        [Key]
        public int IdRaisonAbsence { get; set; }

        [Required(ErrorMessage = "Le libellé de la raison d'absence est requis.")]
        [MaxLength(150, ErrorMessage = "Le libellé ne peut pas dépasser 150 caractères.")]
        public string Libelle { get; set; } = string.Empty;
    }
}