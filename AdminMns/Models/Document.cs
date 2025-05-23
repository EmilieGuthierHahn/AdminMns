// --- NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
using System; // Pour DateTime, TimeSpan
using System.ComponentModel.DataAnnotations; // Pour [Key]
using System.ComponentModel.DataAnnotations.Schema; // Optionnel, pour [Table] ou [Column] si besoin

namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // Correspond à la table 'document'
  

    public class Document
    {
        [Key]
        public int IdDocument { get; set; }
        [MaxLength(50)]
        public string Nom { get; set; } = null!;

        // Clés étrangères (IdTypeDoc est varchar dans SQL)
        [MaxLength(100)]
        public string IdTypeDoc { get; set; } = null!;
        public int IdCandidature { get; set; }
        // public virtual TypeDoc TypeDoc { get; set; }
        // public virtual Candidature Candidature { get; set; }
    }
}