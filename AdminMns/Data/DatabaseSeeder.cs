using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

/**
 * TODO: Migrer tous les anciens seeds ici
 * TODO: Supprimer les commentaires de seed dans ApplicatioDbContext à terme
 * TODO: Supprimer __Migrations à terme
 */
namespace AdminMns.Data
{
    public class DatabaseSeeder
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<DatabaseSeeder> logger;
        private readonly UserManager<AppUser> userManager; // Nécéssaire pour ajouter des utilisateurs en base
        private readonly RoleManager<IdentityRole> roleManager; // Nécéssaire pour ajouter des rôles en base

        public DatabaseSeeder(
            ILogger<DatabaseSeeder> logger,
            IConfiguration config,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            this.logger = logger;
            this.configuration = config;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // Version synchrone pour UseSeeding
        public void Execute(DbContext context)
        {
            if (!CheckIfDatabaseExists(context)) return;
            Task.WaitAll([SeedDatas()]);
        }

        // Version asynchrone pour UseAsyncSeeding
        public async Task Execute(DbContext context, CancellationToken? cancellationToken = null)
        {
            if (!CheckIfDatabaseExists(context)) return;
            await SeedDatas();
        }

        private bool CheckIfDatabaseExists(DbContext context)
        {
            return ((RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>()).Exists();
        }

        private async Task SeedDatas()
        {
            logger.LogInformation("Seeding...");

            if (roleManager.Roles.Count() == 0)
            {
                logger.LogInformation("Seeding roles...");

                List<IdentityRole> roles = new List<IdentityRole>() {
                    new IdentityRole("Admin"),
                    new IdentityRole("Candidat"),
                    new IdentityRole("Stagiaire"),
                    new IdentityRole("Intervenant"),
                };

                foreach (IdentityRole role in roles)
                {
                    await roleManager.CreateAsync(role);
                }

            }

            if (userManager.Users.Count() == 0)
            {
                logger.LogInformation("Seeding users...");

                await userManager.CreateAsync(new AppUser { UserName = "MickeyMouse", Email = "mickey.mouse@disney.com" }, "MickeyPass123!");
                await userManager.CreateAsync(new AppUser { UserName = "MinnieMouse", Email = "minnie.mouse@disney.com" }, "MiniePass123!");
                await userManager.CreateAsync(new AppUser { UserName = "DonaldDuck", Email = "donald.duck@disney.com" }, "DonaldPass123!");
                await userManager.CreateAsync(new AppUser { UserName = "ElseArendelle", Email = "elsa.arendelle@disney.com" }, "ElsaPass123!");
                await userManager.CreateAsync(new AppUser { UserName = "SimbaLion", Email = "simba.lion@disney.com" }, "SimbaPass123!");
            }
        }
    }
}
