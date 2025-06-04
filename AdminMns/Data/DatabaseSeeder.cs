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

            // --- APPEL À LA NOUVELLE MÉTHODE DE SEEDING ---
            await SeedRaisonsRetardAsync(context, cancellationToken);

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

        // --- NOUVELLE MÉTHODE POUR LES RAISONS DE RETARD ---
        private async Task SeedRaisonsRetardAsync(ApplicationDbContext context, CancellationToken cancellationToken)
        {
            // Vérifie si le DbSet existe et s'il y a déjà des données
            if (context.RaisonsRetard != null && !await context.RaisonsRetard.AnyAsync(cancellationToken))
            {
                _logger.LogInformation("Ensemencement des Raisons de Retard...");
                var raisons = new List<RaisonRetard>
            {
                // Les ID seront auto-générés si tu n'as pas spécifié .HasData avec des ID fixes dans OnModelCreating
                // Si tu as utilisé .HasData dans OnModelCreating, tu n'as pas besoin de seeder ici,
                // sauf si tu veux ajouter PLUS de raisons que celles du OnModelCreating.
                // Pour cet exemple, je suppose que les ID sont auto-incrémentés par la base de données
                // ou que tu n'as PAS utilisé .HasData pour ces raisons spécifiques dans OnModelCreating.
                // Si tu as des ID spécifiques à cause de .HasData, tu dois les fournir ici aussi.
                new RaisonRetard { Libelle = "Panne de réveil (le Gremlin a encore frappé)" },
                new RaisonRetard { Libelle = "Problèmes de transport (bus dévoré par un Grue)" },
                new RaisonRetard { Libelle = "Embouteillages (invasion de TIE Fighters)" },
                new RaisonRetard { Libelle = "Rendez-vous médical (contrôle anti-Spectre)" },
                new RaisonRetard { Libelle = "Mise à jour système inopinée (Windows, évidemment...)" },
                new RaisonRetard { Libelle = "Chat coincé dans l'imprimante 3D (ne demandez pas)" },
                new RaisonRetard { Libelle = "Perdu dans les limbes d'un JDR trop immersif" },
                new RaisonRetard { Libelle = "Autre (à préciser en détails galactiques)" }
            };

                context.RaisonsRetard.AddRange(raisons);
                try
                {
                    await context.SaveChangesAsync(cancellationToken);
                    _logger.LogInformation("{Count} raisons de retard ont été ensemencées.", raisons.Count);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erreur lors de l'ensemencement des raisons de retard.");
                }
            }
            else if (context.RaisonsRetard == null)
            {
                _logger.LogWarning("DbSet RaisonsRetard est null. Impossible d'ensemencer les raisons de retard.");
            }
            else
            {
                _logger.LogInformation("Les Raisons de Retard existent déjà ou le DbSet est null, pas d'ensemencement nécessaire.");
            }
        }
    }
}