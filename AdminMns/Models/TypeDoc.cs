// --- NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
using System; // Pour DateTime, TimeSpan
using System.ComponentModel.DataAnnotations; // Pour [Key]
using System.ComponentModel.DataAnnotations.Schema; // Optionnel, pour [Table] ou [Column] si besoin

namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // Correspond à la table 'type_doc'
    public class TypeDoc
    {
        [Key]
        [MaxLength(50)] 
        public string IdTypeDoc { get; set; } = null!; // Clé primaire Varchar
        [MaxLength(50)]
        public string Description { get; set; } = null!;
    }
}
