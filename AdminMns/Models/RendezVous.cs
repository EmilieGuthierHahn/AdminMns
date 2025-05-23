// --- NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
using System; // Pour DateTime, TimeSpan
using System.ComponentModel.DataAnnotations; // Pour [Key]
using System.ComponentModel.DataAnnotations.Schema; // Optionnel, pour [Table] ou [Column] si besoin

namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // Correspond à la table 'rendez_vous'


    public class RendezVous
    {
        [Key]
        public int IdRendezVous { get; set; }
        public DateTime JourRdv { get; set; }
        public TimeSpan HeureRdv { get; set; }
        [MaxLength(50)]
        public string? Sujet { get; set; } // Nullable dans SQL
    }
}