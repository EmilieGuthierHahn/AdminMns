// Fichier: AdminMns/Data/DatabaseSeeder.cs
using AdminMns.Models; // Pour Document, TypeDoc, Candidature, AppUser, RaisonAbsence, RaisonRetard
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace AdminMns.Data
{
    public class DatabaseSeeder
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DatabaseSeeder> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(
            ILogger<DatabaseSeeder> logger,
            IConfiguration config,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _configuration = config;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Execute(DbContext context)
        {
            if (!CheckIfDatabaseExists(context)) return;
            if (context is ApplicationDbContext appContext)
            {
                SeedDatasAsync(appContext).GetAwaiter().GetResult();
            }
            else
            {
                _logger.LogError("Le contexte fourni à DatabaseSeeder.Execute n'est pas un ApplicationDbContext.");
            }
        }

        public async Task Execute(DbContext context, CancellationToken? cancellationToken = null)
        {
            if (!CheckIfDatabaseExists(context)) return;
            if (context is ApplicationDbContext appContext)
            {
                await SeedDatasAsync(appContext, cancellationToken ?? CancellationToken.None);
            }
            else
            {
                _logger.LogError("Le contexte fourni à DatabaseSeeder.ExecuteAsync n'est pas un ApplicationDbContext.");
            }
        }

        private bool CheckIfDatabaseExists(DbContext context)
        {
            try
            {
                return context.Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator && databaseCreator.Exists();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la vérification de l'existence de la base de données.");
                return false;
            }
        }

        private async Task SeedDatasAsync(ApplicationDbContext context, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Début de l'ensemencement des données...");

            await SeedRolesAsync();
            await SeedUsersAsync();
            
            // TODO: Corriger le seeding, un des modèles a une erreur

            //await SeedTypeDocsAsync(context, cancellationToken);
            //await SeedCandidaturesAsync(context, cancellationToken);
            //await SeedDocumentsAsync(context, cancellationToken);

            _logger.LogInformation("Ensemencement des données terminé.");
        }

        private async Task SeedRolesAsync()
        {
            if (!_roleManager.Roles.Any())
            {
                _logger.LogInformation("Ensemencement des rôles...");
                List<IdentityRole> roles = new List<IdentityRole>() {
                    new IdentityRole("Admin"),
                    new IdentityRole("Candidat"),
                    new IdentityRole("Stagiaire"),
                    new IdentityRole("Intervenant"),
                };
                foreach (IdentityRole role in roles)
                {
                    var result = await _roleManager.CreateAsync(role);
                    if (!result.Succeeded) _logger.LogError($"Erreur lors de la création du rôle {role.Name}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
            else
            {
                _logger.LogInformation("Les rôles existent déjà, pas d'ensemencement nécessaire.");
            }
        }

        private async Task SeedUsersAsync()
        {
            if (!_userManager.Users.Any())
            {
                _logger.LogInformation("Ensemencement des utilisateurs...");
                var usersToSeed = new List<(AppUser user, string password, string[]? roles)>
                {
                    (new AppUser { UserName = "MickeyMouse", Email = "mickey.mouse@disney.com", EmailConfirmed = true }, "MickeyPass123!", new [] { "Admin", "Candidat" }),
                    (new AppUser { UserName = "MinnieMouse", Email = "minnie.mouse@disney.com", EmailConfirmed = true }, "MiniePass123!", new [] { "Candidat" }),
                    (new AppUser { UserName = "DonaldDuck", Email = "donald.duck@disney.com", EmailConfirmed = true }, "DonaldPass123!", new [] { "Intervenant" }),
                    (new AppUser { UserName = "ElseArendelle", Email = "elsa.arendelle@disney.com", EmailConfirmed = true }, "ElsaPass123!", new [] { "Stagiaire" }),
                    (new AppUser { UserName = "SimbaLion", Email = "simba.lion@disney.com", EmailConfirmed = true }, "SimbaPass123!", new [] { "Stagiaire", "Candidat" })
                };

                foreach (var userData in usersToSeed)
                {
                    var creationResult = await _userManager.CreateAsync(userData.user, userData.password);
                    if (creationResult.Succeeded)
                    {
                        if (userData.roles != null && userData.roles.Any())
                        {
                            var assignmentResult = await _userManager.AddToRolesAsync(userData.user, userData.roles);
                            if (!assignmentResult.Succeeded) _logger.LogError($"Erreur lors de l'assignation des rôles à {userData.user.UserName}: {string.Join(", ", assignmentResult.Errors.Select(e => e.Description))}");
                        }
                    }
                    else
                    {
                        _logger.LogError($"Erreur lors de la création de l'utilisateur {userData.user.UserName}: {string.Join(", ", creationResult.Errors.Select(e => e.Description))}");
                    }
                }
            }
            else
            {
                _logger.LogInformation("Les utilisateurs existent déjà, pas d'ensemencement nécessaire.");
            }
        }

        private async Task SeedTypeDocsAsync(ApplicationDbContext context, CancellationToken cancellationToken)
        {
            if (!await context.TypeDocs.AnyAsync(cancellationToken))
            {
                _logger.LogInformation("Ensemencement des TypeDocs...");
                context.TypeDocs.AddRange(
                    new TypeDoc { IdTypeDoc = "CV", Description = "Curriculum Vitae" },
                    new TypeDoc { IdTypeDoc = "LM", Description = "Lettre de Motivation" },
                    new TypeDoc { IdTypeDoc = "CONTRAT", Description = "Contrat de Stage/Apprentissage" },
                    new TypeDoc { IdTypeDoc = "FICHE_RENS", Description = "Fiche de Renseignements" },
                    new TypeDoc { IdTypeDoc = "JUSTIF_ABS", Description = "Justificatif d'Absence" }
                );
                await context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                _logger.LogInformation("Les TypeDocs existent déjà, pas d'ensemencement nécessaire.");
            }
        }

        private async Task SeedCandidaturesAsync(ApplicationDbContext context, CancellationToken cancellationToken)
        {
            if (!await context.Candidatures.AnyAsync(cancellationToken))
            {
                _logger.LogInformation("Ensemencement des Candidatures...");
                context.Candidatures.AddRange(
                    new Candidature { TitreOuReference = "Candidature Spontanée - Dev Web 2025", DateSoumission = new DateTime(2025, 1, 15) },
                    new Candidature { TitreOuReference = "Candidature Programme IA - Hiver 2025", DateSoumission = new DateTime(2025, 2, 1) },
                    new Candidature { TitreOuReference = "Candidature Réponse Offre #XYZ789", DateSoumission = null },
                    new Candidature { TitreOuReference = "Candidature Master Design UX", DateSoumission = new DateTime(2024, 12, 5) }
                );
                await context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                _logger.LogInformation("Les Candidatures existent déjà, pas d'ensemencement nécessaire.");
            }
        }

        private async Task SeedDocumentsAsync(ApplicationDbContext context, CancellationToken cancellationToken)
        {
            if (context.Documents != null && !await context.Documents.AnyAsync(cancellationToken))
            {
                _logger.LogInformation("Ensemencement des Documents...");

                var typeCv = await context.TypeDocs.FindAsync(new object[] { "CV" }, cancellationToken);
                var typeLm = await context.TypeDocs.FindAsync(new object[] { "LM" }, cancellationToken);
                var typeContrat = await context.TypeDocs.FindAsync(new object[] { "CONTRAT" }, cancellationToken);
                var typeFicheRens = await context.TypeDocs.FindAsync(new object[] { "FICHE_RENS" }, cancellationToken);

                var candDevWeb = await context.Candidatures.FirstOrDefaultAsync(c => c.TitreOuReference == "Candidature Spontanée - Dev Web 2025", cancellationToken);
                var candIA = await context.Candidatures.FirstOrDefaultAsync(c => c.TitreOuReference == "Candidature Programme IA - Hiver 2025", cancellationToken);
                var candOffreXYZ = await context.Candidatures.FirstOrDefaultAsync(c => c.TitreOuReference == "Candidature Réponse Offre #XYZ789", cancellationToken);
                var candMasterUX = await context.Candidatures.FirstOrDefaultAsync(c => c.TitreOuReference == "Candidature Master Design UX", cancellationToken);

                var documentsToAdd = new List<Document>();

                if (typeCv != null && candDevWeb != null)
                {
                    documentsToAdd.Add(new Document
                    {
                        NomDocument = "CV Développeur Web",
                        IdTypeDoc = typeCv.IdTypeDoc,
                        IdCandidature = candDevWeb.IdCandidature,
                        TypeDossier = typeCv.Description,
                        Statut = "Soumis",
                        StatutAffichage = "CV Reçu"
                    });
                }

                if (typeLm != null && candDevWeb != null)
                {
                    documentsToAdd.Add(new Document
                    {
                        NomDocument = "Lettre Motivation Dev Web",
                        IdTypeDoc = typeLm.IdTypeDoc,
                        IdCandidature = candDevWeb.IdCandidature,
                        TypeDossier = typeLm.Description,
                        Statut = "Soumis",
                        StatutAffichage = "LM Reçue"
                    });
                }

                if (typeCv != null && candIA != null)
                {
                    documentsToAdd.Add(new Document
                    {
                        NomDocument = "CV Spécialiste IA",
                        IdTypeDoc = typeCv.IdTypeDoc,
                        IdCandidature = candIA.IdCandidature,
                        TypeDossier = typeCv.Description,
                        Statut = "Soumis",
                        StatutAffichage = "CV Reçu"
                    });
                }

                if (typeFicheRens != null && candIA != null)
                {
                    documentsToAdd.Add(new Document
                    {
                        NomDocument = "Fiche IA",
                        IdTypeDoc = typeFicheRens.IdTypeDoc,
                        IdCandidature = candIA.IdCandidature,
                        TypeDossier = typeFicheRens.Description,
                        Statut = "Soumis",
                        StatutAffichage = "Fiche Reçue"
                    });
                }

                if (typeContrat != null && candOffreXYZ != null)
                {
                    documentsToAdd.Add(new Document
                    {
                        NomDocument = "Contrat pour Offre XYZ",
                        IdTypeDoc = typeContrat.IdTypeDoc,
                        IdCandidature = candOffreXYZ.IdCandidature,
                        TypeDossier = typeContrat.Description,
                        Statut = "Brouillon",
                        StatutAffichage = "Contrat en préparation"
                    });
                }

                if (typeCv != null && candMasterUX != null)
                {
                    documentsToAdd.Add(new Document
                    {
                        NomDocument = "CV Design UX",
                        IdTypeDoc = typeCv.IdTypeDoc,
                        IdCandidature = candMasterUX.IdCandidature,
                        TypeDossier = typeCv.Description,
                        Statut = "Soumis",
                        StatutAffichage = "CV Reçu"
                    });
                }

                if (typeLm != null && candMasterUX != null)
                {
                    documentsToAdd.Add(new Document
                    {
                        NomDocument = "Motivation Master UX",
                        IdTypeDoc = typeLm.IdTypeDoc,
                        IdCandidature = candMasterUX.IdCandidature,
                        TypeDossier = typeLm.Description,
                        Statut = "Soumis",
                        StatutAffichage = "LM Reçue"
                    });
                }

                if (documentsToAdd.Any())
                {
                    context.Documents.AddRange(documentsToAdd);
                    await context.SaveChangesAsync(cancellationToken);
                }
            }
            else if (context.Documents == null)
            {
                _logger.LogWarning("DbSet Documents est null. Impossible d'ensemencer les documents.");
            }
            else
            {
                _logger.LogInformation("Les Documents existent déjà, pas d'ensemencement nécessaire.");
            }
        }
    }
}