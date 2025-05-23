// Dans Models/Candidature.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System; // Pour DateTime si vous l'ajoutez

namespace AdminMns.Models
{
    [Table("candidatures")]
    public class Candidature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidature { get; set; }

        [Required(ErrorMessage = "Un titre ou une référence pour la candidature est requis.")]
        [MaxLength(250)]
        public string TitreOuReference { get; set; } = null!;

        public DateTime? DateSoumission { get; set; } // Optionnel

        // Si une candidature peut mener à plusieurs classes (improbable, généralement 1-1 ou 1-0)
        // ou si une classe est issue d'UNE candidature.
        // Si une classe DOIT avoir une candidature, la relation est dans Classe.cs.
        // Si une candidature PEUT avoir une classe (ou est liée à une classe après coup),
        // vous pourriez avoir une clé étrangère ici aussi, mais c'est moins courant
        // si IdCandidature est dans Classe.cs.

        // public int? IdClasse { get; set; } // Si une candidature est liée à UNE classe spécifique
        // [ForeignKey("IdClasse")]
        // public virtual Classe? Classe { get; set; }
    }
}