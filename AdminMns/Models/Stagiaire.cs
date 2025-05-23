// Dans Models/Stagiaire.cs
using AdminMns.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminMns.Models
{
    [Table("stagiaire")]
    public class Stagiaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStagiaire { get; set; }

        [Required(ErrorMessage = "Le nom du stagiaire est requis.")]
        [MaxLength(50)]
        public string Nom { get; set; } = null!;

        [Required(ErrorMessage = "Le prénom du stagiaire est requis.")]
        [MaxLength(50)]
        public string Prenom { get; set; } = null!;

        [Required(ErrorMessage = "La date de naissance est requise.")]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "L'email du stagiaire est requis.")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "Format d'email invalide.")]
        public string EmailStagiaire { get; set; } = null!;

        [Required(ErrorMessage = "Le numéro de téléphone est requis.")]
        [MaxLength(50)]
        public string Telephone { get; set; } = null!;

        [Required(ErrorMessage = "L'adresse est requise.")]
        [MaxLength(50)]
        public string Adresse { get; set; } = null!;

        [Required(ErrorMessage = "La ville est requise.")]
        [MaxLength(50)]
        public string Ville { get; set; } = null!;

        public required virtual AppUser Utilisateur { get; set; }

        // --- NOUVELLES LIGNES À AJOUTER ICI ---
        // Propriété de navigation vers la table de liaison RetardStagiaire
        // Un stagiaire peut avoir plusieurs enregistrements de retard via cette table de liaison.
        public virtual ICollection<RetardStagiaire> RetardStagiaires { get; set; }
        // --- FIN DES NOUVELLES LIGNES ---

        // Constructeur
        public Stagiaire()
        {
            // Initialisez TOUTES vos propriétés de collection ici
            // Si vous aviez d'autres collections (par exemple pour Photo, ClasseStagiaire, etc.), elles seraient initialisées ici aussi.
            // Exemple : Photos = new HashSet<Photo>();

            // --- NOUVELLE LIGNE À AJOUTER DANS LE CONSTRUCTEUR ---
            RetardStagiaires = new HashSet<RetardStagiaire>();
            // --- FIN DE LA NOUVELLE LIGNE DANS LE CONSTRUCTEUR ---
        }
    }
}