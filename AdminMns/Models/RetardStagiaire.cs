// Dans Models/RetardStagiaire.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdminMns.Models
{
    [Table("retard_stagiaire")] // Nom de la table de liaison
    public class RetardStagiaire
    {
        // Clé primaire composite, configurée dans OnModelCreating
        public int IdRetard { get; set; }
        public int IdStagiaire { get; set; }

        // Propriétés de navigation vers les entités principales
        [ForeignKey("IdRetard")]
        public virtual Retard Retard { get; set; } = null!;

        [ForeignKey("IdStagiaire")]
        public virtual Stagiaire Stagiaire { get; set; } = null!;
    }
}