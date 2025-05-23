/// ---NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
using System; // Pour DateTime, TimeSpan
using System.ComponentModel.DataAnnotations; // Pour [Key]
using System.ComponentModel.DataAnnotations.Schema; // Optionnel, pour [Table] ou [Column] si besoin
namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    public class Administrateur
    {
        [Key]
        public int IdAdministrateur { get; set; }
        [MaxLength(50)]
        public string Nom { get; set; } = null!;
        [MaxLength(50)]
        public string Prenom { get; set; } = null!;
        [MaxLength(50)]
        public string Email { get; set; } = null!;
        [MaxLength(50)]
        public string Telephone { get; set; } = null!;
        [MaxLength(50)]
        public string Adresse { get; set; } = null!;
        [MaxLength(50)]
        public string Ville { get; set; } = null!;
        [MaxLength(50)]
        public DateTime DateDeNaissance { get; set; }
        public DateTime DateDeCreation { get; set; }

        // Clé étrangère
        public int IdUtilisateur { get; set; }
        // public virtual Utilisateur Utilisateur { get; set; }
    }
}