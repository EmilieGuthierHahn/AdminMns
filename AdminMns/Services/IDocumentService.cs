
using AdminMns.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminMns.Services
{
    public interface IDocumentService
    {
        Task<List<DocumentViewModel>> RecupererListeDocumentsAsync();
        Task<int> CompterDocumentsARendreAsync();
        Task<int> ObtenirNombreRetardsReelsAsync(); // Pour le compteur de retards
        Task<int> ObtenirNombreAbsencesReellesAsync(); // Pour le compteur d'absences
    }
}