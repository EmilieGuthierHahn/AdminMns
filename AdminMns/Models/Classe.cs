// Dans Models/Classe.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminMns.Models // Assurez-vous que ce namespace correspond à votre projet
{
    [Table("classes")] // Nom de la table dans la base de données (conventionnel au pluriel et minuscules)
    public class Classe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indique que la BDD génère la valeur
        public int IdClasse { get; set; }

        [Required(ErrorMessage = "Le nom de la classe est requis.")]
        [MaxLength(100, ErrorMessage = "Le nom de la classe ne peut pas dépasser 100 caractères.")]
        public string Nom { get; set; } = null!; // null! pour indiquer que ce sera initialisé (par EF Core ou constructeur)

        [Required(ErrorMessage = "L'année de la classe est requise.")]
        // Exemple de validation de plage pour l'année, à adapter selon vos besoins
        [Range(2000, 2100, ErrorMessage = "L'année doit être entre 2000 et 2100.")]
        public int Annee { get; set; }

        // Clé étrangère vers la table Candidatures
        // Si une classe est TOUJOURS liée à une candidature :
        [Required(ErrorMessage = "L'ID de la candidature est requis.")]
        public int? IdCandidature { get; set; } // null pour indiquer que la valeur peut être absente

        // Propriété de navigation vers Candidature (optionnelle mais recommandée pour les opérations complexes)
        // Assurez-vous que la classe Candidature est définie et que vous avez un DbSet<Candidature> dans votre DbContext.
        // Si vous n'avez pas encore le modèle Candidature ou si la liaison est optionnelle,
        // vous pouvez commenter ou ajuster cette partie.
        [ForeignKey("IdCandidature")]
        public virtual Candidature? Candidature { get; set; } // Le '?' le rend optionnel au chargement si pas toujours inclus

        // Si une classe peut avoir plusieurs stagiaires (Many-to-Many via ClasseStagiaire)
        // ou plusieurs photos, etc., vous ajouteriez des propriétés de collection ici :
        // public virtual ICollection<Photo>? Photos { get; set; }
        // public virtual ICollection<ClasseStagiaire>? ClasseStagiaires { get; set; }
        // public virtual ICollection<PlanningClasse>? PlanningClasses { get; set; }

        // Constructeur pour initialiser les collections si vous les ajoutez
        // public Classe()
        // {
        //     Photos = new HashSet<Photo>();
        //     ClasseStagiaires = new HashSet<ClasseStagiaire>();
        //     PlanningClasses = new HashSet<PlanningClasse>();
        // }
    }
}