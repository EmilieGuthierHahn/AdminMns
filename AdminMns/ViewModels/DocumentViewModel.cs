
namespace AdminMns.ViewModels
{
    public class DocumentViewModel
    {
        public int IdDocument { get; set; }
        public string? NomDocument { get; set; }
        public string? TypeDossier { get; set; }    // Va utiliser TypeDoc.Description
        public DateTime? DateAffichage { get; set; } // Va utiliser Candidature.DateSoumission (nullable)
        public string? StatutAffichage { get; set; }
        public bool EstRecu { get; set; }
        public DateTime Date { get; set; } 
        public string? Statut { get; set; } 
    }
}