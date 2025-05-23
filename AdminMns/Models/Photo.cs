// --- NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
using System; // Pour DateTime, TimeSpan
using System.ComponentModel.DataAnnotations; // Pour [Key]
using System.ComponentModel.DataAnnotations.Schema; // Optionnel, pour [Table] ou [Column] si besoin


namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // Correspond à la table 'photo'


    public class Photo
    {
        [Key]
        [StringLength(50)]
        public string IdPhoto { get; set; } = null!; // Clé primaire Varchar

        // Clés étrangères
        public int IdClasse { get; set; }
        public int IdStagiaire { get; set; }
        // public virtual Classe Classe { get; set; }
        // public virtual Stagiaire Stagiaire { get; set; }
    }
}