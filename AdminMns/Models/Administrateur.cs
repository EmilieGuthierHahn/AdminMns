/// ---NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
using AdminMns.Data;
using System.ComponentModel.DataAnnotations; // Pour [Key]
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

        public required virtual AppUser Utilisateur { get; set; }
    }
}