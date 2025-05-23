// --- NECESSAIRE EN HAUT DE CHAQUE FICHIER ---
namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // Correspond à la table 'entretenir' (Table de liaison Many-to-Many)
    public class Entretien // Renommé pour clarté
    {
        // Clés étrangères composant la clé primaire composite
        public int IdUtilisateur { get; set; }
        public int IdRendezVous { get; set; }
    }
}