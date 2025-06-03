// Fichier: Program.cs
using AdminMns.Components;
using Microsoft.AspNetCore.Components.Authorization;
using AdminMns.Components.Account;
using AdminMns.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure; // Nécessaire pour GetService si utilisé par UseSeeding
using AdminMns.Services; // Pour IDocumentService

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                     throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options
        .UseSqlServer(connectionString)
        /**
         * @see https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding#configuration-options-useseeding-and-useasyncseeding-methods
         * When using this feature, it is recommended to implement both UseSeeding and UseAsyncSeeding methods
         */
        // Ces méthodes sont spécifiques à une bibliothèque de seeding (ex: EntityFrameworkCore.SeedingContainer ou similaire)
        // Elles s'accrochent au cycle de vie du DbContext.
        .UseSeeding((context, _) => context.GetService<DatabaseSeeder>()!.Execute(context))
        .UseAsyncSeeding(async (context, _, cancellationToken) => await context.GetService<DatabaseSeeder>()!.Execute(context, cancellationToken));
});

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

builder.Services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<AppUser>, IdentityNoOpEmailSender>();
builder.Services.AddScoped<DatabaseSeeder>(); // Enregistrement du seeder
builder.Services.AddScoped<IDocumentService, DocumentService>();

var app = builder.Build();

// --- AJOUT IMPORTANT : APPLIQUER LES MIGRATIONS AU DÉMARRAGE ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        // S'assurer que la base de données est migrée vers la dernière version
        context.Database.Migrate();
        // Note : L'appel au seeder est géré par .UseSeeding/.UseAsyncSeeding lors de la configuration du DbContext.
        // Si cette approche ne fonctionne pas comme attendu avec .UseSeeding,
        // vous pourriez commenter .UseSeeding et .UseAsyncSeeding dans AddDbContext
        // et appeler le seeder manuellement ici APRÈS context.Database.Migrate(), par exemple :
        // var userManager = services.GetRequiredService<UserManager<AppUser>>();
        // var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        // var loggerSeeder = services.GetRequiredService<ILogger<DatabaseSeeder>>();
        // var configuration = services.GetRequiredService<IConfiguration>();
        // var seeder = new DatabaseSeeder(loggerSeeder, configuration, userManager, roleManager);
        // await seeder.Execute(context); 
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Une erreur est survenue lors de la migration ou de l'ensemencement initial de la base de données.");
        // Il est souvent préférable de laisser l'application échouer ici si la BDD n'est pas prête,
        // ou de mettre en place une stratégie de nouvelle tentative.
    }
}
// --- FIN DE L'AJOUT POUR LES MIGRATIONS ---

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Assurez-vous que UseStaticFiles est avant UseAntiforgery si vous avez des problèmes avec Antiforgery et les assets statiques
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Adding Piranha
// builder.Services.AddPiranha(); // Assurez-vous que ces lignes sont bien où elles doivent être (avant app.Build() pour les services)

app.MapAdditionalIdentityEndpoints();

app.Run();