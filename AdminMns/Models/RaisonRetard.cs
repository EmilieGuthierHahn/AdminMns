// Fichier: AdminMns/Models/RaisonRetard.cs
using System.Collections.Generic; // Pour ICollection
using System.ComponentModel.DataAnnotations;

namespace AdminMns.Models
{
    public class RaisonRetard
    {
        [Key]
        public int IdRaisonRetard { get; set; }

        [Required(ErrorMessage = "Le libellé de la raison est requis.")]
        [MaxLength(250)]
        public string Libelle { get; set; } = string.Empty;
    }
}