// --- NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
using System; // Pour DateTime, TimeSpan
using System.ComponentModel.DataAnnotations; // Pour [Key]
using System.ComponentModel.DataAnnotations.Schema; // Optionnel, pour [Table] ou [Column] si besoin

namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // Correspond à la table 'planifier' (Table de liaison Many-to-Many)
    public class PlanningClasse // Renommé pour clarté
    {
        // Clés étrangères composant la clé primaire composite
        public int IdPlanning { get; set; }
        public int IdClasse { get; set; }

        // Propriétés de navigation optionnelles
        // public virtual Planning Planning { get; set; }
        // public virtual Classe Classe { get; set; }
    }
}