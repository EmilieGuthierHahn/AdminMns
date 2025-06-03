// Fichier: AdminMns/Services/DocumentService.cs
using AdminMns.Data;
using AdminMns.Models;
using AdminMns.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMns.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly ApplicationDbContext _context;

        public DocumentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentViewModel>> RecupererListeDocumentsAsync()
        {
            var documentsFromDb = await _context.Documents
                                          .Include(doc => doc.TypeDoc)     // Charger TypeDoc
                                          .Include(doc => doc.Candidature) // Charger Candidature
                                          .OrderByDescending(doc => doc.Candidature != null ? doc.Candidature.DateSoumission : DateTime.MinValue) // Tri par date de soumission si dispo
                                          .ThenBy(doc => doc.NomDocument) // Puis par nom
                                          .ToListAsync();

            var viewModels = documentsFromDb.Select(doc =>
            {
                // Type de Dossier: Utilise la propriété Description de l'entité TypeDoc.
                string typeDossierAffichage = doc.TypeDoc?.Description ?? doc.IdTypeDoc ?? "Type Inconnu";

                // Date d'Affichage: Utilise DateSoumission de Candidature (qui est nullable).
                DateTime? datePourAffichage = doc.Candidature?.DateSoumission;

                // --- Début: LOGIQUE DE STATUT À PERSONNALISER PAR VOUS ---
                // Cette logique est un exemple. Adaptez-la à VOS règles métier !
                string statut;
                bool estRecu;

                if (datePourAffichage.HasValue) // Si une date de soumission existe
                {
                    // Exemple: si le TypeDoc est "CONTRAT" et une date existe, c'est "Signé"
                    if (doc.TypeDoc?.Description?.ToUpper().Contains("CONTRAT") == true)
                    {
                        statut = "Signé";
                        estRecu = true;
                    }
                    else
                    {
                        statut = "Reçu";
                        estRecu = true;
                    }
                }
                else // Pas de date de soumission
                {
                    statut = "En attente";
                    estRecu = false;
                }
                // --- Fin: LOGIQUE DE STATUT À PERSONNALISER PAR VOUS ---

                return new DocumentViewModel
                {
                    IdDocument = doc.IdDocument,
                    NomDocument = doc.NomDocument,
                    TypeDossier = typeDossierAffichage,
                    DateAffichage = datePourAffichage, // Reste nullable ici
                    StatutAffichage = statut,
                    EstRecu = estRecu
                };
            }).ToList();

            return viewModels;
        }

        public async Task<int> CompterDocumentsARendreAsync()
        {
            // Un document est "à rendre" si, par exemple, il n'a pas de DateSoumission.
            // Adaptez cette condition à votre logique métier.
            return await _context.Documents
                .Include(d => d.Candidature) // Nécessaire si la condition dépend de Candidature
                .Where(d => d.Candidature == null || !d.Candidature.DateSoumission.HasValue)
                .CountAsync();
        }

        public async Task<int> ObtenirNombreRetardsReelsAsync()
        {
            // Logique à implémenter pour compter les retards réels.
            // Par exemple, en interrogeant votre table 'Retards'.
            // return await _context.Retards.CountAsync(r => r.EstJustifie == false); // Exemple
            return await _context.Retards.CountAsync(); // Compte tous les retards pour l'instant
        }

        public async Task<int> ObtenirNombreAbsencesReellesAsync()
        {
            // Logique à implémenter pour compter les absences réelles.
            // Par exemple, en interrogeant votre table 'Absences'.
            // return await _context.Absences.CountAsync(a => a.EstJustifie == false); // Exemple
            return await _context.Absences.CountAsync(); // Compte toutes les absences pour l'instant
        }
    }
} 