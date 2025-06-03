// --- NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
using System; // Pour DateTime
using System.ComponentModel.DataAnnotations; // Pour [Key], [MaxLength]
using System.ComponentModel.DataAnnotations.Schema; // Pour [ForeignKey] (si nécessaire, mais souvent implicite avec EF Core)

namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // Correspond à la table 'document'

    public class Document
    {
     
        [Key]
        public int IdDocument { get; set; }

 
        [MaxLength(50)] // Contrainte de longueur pour la base de données
        public required string NomDocument { get; set; }

        [MaxLength(100)] // Contrainte de longueur pour la base de données
        public required string TypeDossier { get; set; }

        public required string Statut { get; set; }
        public required string StatutAffichage { get; set; }

        [MaxLength(50)]
        public required string IdTypeDoc { get; set; }

        [ForeignKey("IdTypeDoc")] // Lie cette navigation à la propriété IdTypeDoc
        public virtual TypeDoc TypeDoc { get; set; } // TypeDoc peut être null si non chargé ou non existant

        public required int IdCandidature { get; set; } // Supposons qu'il est toujours requis

        [ForeignKey("IdCandidature")] // Lie cette navigation à la propriété IdCandidature
        public virtual Candidature? Candidature { get; set; } // Candidature peut être null si non chargée ou non existante

        public Document()
        {
            
        }
    }
 
}