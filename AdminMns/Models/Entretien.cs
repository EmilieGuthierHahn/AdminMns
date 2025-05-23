// --- NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
using System; // Pour DateTime, TimeSpan
using System.ComponentModel.DataAnnotations; // Pour [Key]
using System.ComponentModel.DataAnnotations.Schema; // Optionnel, pour [Table] ou [Column] si besoin

namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // Correspond à la table 'entretenir' (Table de liaison Many-to-Many)
    public class Entretien // Renommé pour clarté
    {
        // Clés étrangères composant la clé primaire composite
        public int IdUtilisateur { get; set; }
        public int IdRendezVous { get; set; }

        // Propriétés de navigation optionnelles
        // public virtual Utilisateur Utilisateur { get; set; }
        // public virtual RendezVous RendezVous { get; set; }
    }
}