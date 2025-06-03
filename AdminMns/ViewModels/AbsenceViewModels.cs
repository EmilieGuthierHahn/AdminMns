using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace AdminMns.ViewModels
{
    public class AbsenceViewModel
    {
        [Required(ErrorMessage = "La raison de l'absence est requise.")]
        public string RaisonAbsence { get; set; } = string.Empty;

        public string TextAreaAbsence { get; set; } = string.Empty;

        [Required(ErrorMessage = "Merci d'entrer une date de début")]
        public DateTime? DateDebutAbsence { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Merci d'entrer une date de fin")]
        public DateTime? DateFinAbsence { get; set; } = DateTime.Today;

        public IBrowserFile? JustificatifFile { get; set; }
    }
}
