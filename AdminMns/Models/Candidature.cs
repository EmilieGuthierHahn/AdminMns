// Dans Models/Candidature.cs
using System; // Pour DateTime si vous l'ajoutez
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdminMns.Data;

namespace AdminMns.Models
{
    public class Candidature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidature { get; set; }

        [Required(ErrorMessage = "Un titre ou une référence pour la candidature est requis.")]
        [MaxLength(250)]
        public string TitreOuReference { get; set; } = null!;

        public DateTime? DateSoumission { get; set; } // Optionnel

        [Required] // À rendre nullable si une candidature peut exister sans utilisateur lié au début
        public string UtilisateurId { get; set; } = null!; // Clé étrangère vers AspNetUsers.Id
        [ForeignKey("UtilisateurId")]
        public virtual AppUser? AppUser { get; set; } // Utilise ton AppUser.cs

        // Propriété de navigation inverse (bonne pratique)
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}