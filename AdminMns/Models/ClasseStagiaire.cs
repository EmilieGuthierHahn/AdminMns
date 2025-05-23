// --- NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
using System; // Pour DateTime, TimeSpan
using System.ComponentModel.DataAnnotations; // Pour [Key]
using System.ComponentModel.DataAnnotations.Schema; // Optionnel, pour [Table] ou [Column] si besoin

namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // Correspond à la table 'classe_stagiaire' (Table de liaison Many-to-Many)
    // EF Core peut gérer cela implicitement si vous définissez les navigations
    // dans Classe et Stagiaire, mais vous pouvez aussi la définir explicitement.
    // Pour une configuration explicite, la clé est composite.
    public class ClasseStagiaire
    {
        // Clés étrangères composant la clé primaire composite
        public int IdStagiaire { get; set; }
        public int IdClasse { get; set; }

        // Propriétés de navigation optionnelles
        // public virtual Stagiaire Stagiaire { get; set; }
        // public virtual Classe Classe { get; set; }
    }
}
