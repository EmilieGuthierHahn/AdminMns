// --- NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // Correspond à la table 'cours_intervenants' (Table de liaison Many-to-Many)
    public class CoursIntervenant // Renommé pour clarté (ou PlanningIntervenant)
    {
        // Clés étrangères composant la clé primaire composite
        public int IdPlanning { get; set; }
        public int IdIntervenant { get; set; }

        // Propriétés de navigation optionnelles
        // public virtual Planning Planning { get; set; }
        // public virtual Intervenant Intervenant { get; set; }
    }
}
