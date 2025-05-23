// --- NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
using AdminMns.Data;
using System.ComponentModel.DataAnnotations; // Pour [Key]

namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // Correspond à la table 'intervenant'


    public class Intervenant
    {
        [Key]
        public int IdIntervenant { get; set; }
        [MaxLength(50)]
        public string Nom { get; set; } = null!;
        [MaxLength(50)]
        public string Prenom { get; set; } = null!;
        [MaxLength(50)]
        public string Email { get; set; } = null!;
        [MaxLength(250)]
        public string Specialite { get; set; } = null!;
        [MaxLength(50)]
        public string Telephone { get; set; } = null!;
        [MaxLength(250)]
        public string Adresse { get; set; } = null!;
        [MaxLength(50)]
        public string Ville { get; set; } = null!;
        public DateTime? DateDeNaissance { get; set; } // Nullable dans SQL
        public DateTime DateDeCreation { get; set; }

        public required virtual AppUser Utilisateur { get; set; }
    }
}
