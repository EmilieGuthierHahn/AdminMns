// Models/Status.cs (version pour l'exemple d'alimentation de données)
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Requis pour [Table]

namespace AdminMns.Models
{
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indique que la BDD génère la valeur
        public int IdStatus { get; set; }

        [Required(ErrorMessage = "Le type de statut est requis.")]
        [MaxLength(50)]
        public string Type { get; set; } = null!;
    }
}