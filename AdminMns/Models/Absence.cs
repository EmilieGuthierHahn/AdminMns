// --- NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
using System; // Pour DateTime, TimeSpan
using System.ComponentModel.DataAnnotations; // Pour [Key]
using System.ComponentModel.DataAnnotations.Schema; // Optionnel, pour [Table] ou [Column] si besoin

namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // Correspond à la table 'absence'
    public class Absence
    {
        [Key]
        public int IdAbsence { get; set; }
        public DateTime DateFin { get; set; }
        [MaxLength(50)]
        public string Justificatif { get; set; } = null!; // = null!; pour éviter warning si non-nullable
        public DateTime DateDebut { get; set; }
        public DateTime DateDeclaration { get; set; }

        // Clés étrangères (simples pour l'instant)
        public int IdStagiaire { get; set; }
        public int IdRaisonAbsence { get; set; }

        // Vous pourriez ajouter des propriétés de navigation ici plus tard
        // public virtual Stagiaire Stagiaire { get; set; }
        // public virtual RaisonAbsence RaisonAbsence { get; set; }
    }
}