// Dans Models/Planning.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminMns.Models
{
    [Table("plannings")] // Assurez-vous du nom de la table si différent
    public class Planning
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPlanning { get; set; }

        [Required(ErrorMessage = "Le jour du planning est requis.")]
        public DateTime Jour { get; set; } // Sera mappé à un type DATE ou DATETIME dans MySQL

        [Required(ErrorMessage = "L'heure du planning est requise.")]
        public TimeSpan Heure { get; set; } // Sera mappé à un type TIME dans MySQL

        [Required(ErrorMessage = "La salle est requise.")]
        // [Range(1, 999, ErrorMessage = "Le numéro de salle doit être valide.")] // Exemple de validation
        public int Salle { get; set; }
    }
}