using AdminMns.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System.Net.Http; // Pour HttpClient
using System; // Pour Uri
using AdminMns.Components.Services; // Ajoutez le namespace de votre AuthService si vous l'avez défini


var builder = WebApplication.CreateBuilder(args);

// Ajout des services d'authentification
builder.Services.AddAuthorizationCore(); // Nécessaire pour les fonctionnalités d'autorisation dans Blazor (AuthorizeView)
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>(); // Enregistrez votre implémentation personnalisée
builder.Services.AddBlazoredLocalStorage(); // Enregistre le service pour le stockage local

// Enregistrez votre AuthService pour l'injection de dépendances
builder.Services.AddScoped<AuthService>();

// Configure HttpClient pour toutes les requêtes, en lui donnant l'URL de base de votre API backend.
// CustomAuthenticationStateProvider va définir l'en-tête Authorization
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["BackendApiUrl"]!) });


// Add services to the container. (Ces lignes existaient déjà, assurez-vous qu'elles sont présentes après le code ci-dessus)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build(); // Cette ligne doit exister

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
