using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt; // Pour décoder le JWT
using System.Security.Claims;
using System.Net.Http;
using System.Net.Http.Json; // Pour ReadFromJsonAsync
using System.Threading.Tasks;
using System.Collections.Generic; // Pour List<string>
using System; // Pour Exception

// Ces classes DTO doivent être au même niveau que AuthService ou dans un namespace accessible
// Pour la simplicité, je les définis ici. Vous pouvez les déplacer dans un dossier "Models" du côté Blazor.
public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string MotDePasse { get; set; } = string.Empty;
}

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public int IdUtilisateur { get; set; }
    public string Email { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = new List<string>();
}

public class LoginResult
{
    public bool Successful { get; set; }
    public string Error { get; set; } = string.Empty;
}

namespace AdminMns.Components.Services // Adaptez le namespace à votre structure de projet Blazor
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider; // Votre CustomAuthenticationStateProvider sera injecté ici

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        // Tente de connecter l'utilisateur en envoyant les identifiants à l'API
        public async Task<LoginResult> Login(LoginRequest loginRequest)
        {
            try
            {
                // Envoie une requête POST JSON à l'endpoint de connexion de l'API
                var response = await _httpClient.PostAsJsonAsync("api/Auth/login", loginRequest);

                if (response.IsSuccessStatusCode) // Si la requête API a réussi (HTTP 2xx)
                {
                    var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>(); // Désérialise la réponse JSON
                    if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.Token))
                    {
                        await _localStorage.SetItemAsync("authToken", loginResponse.Token); // Stocke le token dans le stockage local du navigateur
                        // Notifie Blazor que l'état d'authentification a changé
                        ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginResponse.Token);
                        return new LoginResult { Successful = true }; // Retourne un succès
                    }
                }

                // Si la requête API n'a pas réussi ou le token est manquant
                var errorContent = await response.Content.ReadAsStringAsync(); // Lit le contenu de l'erreur
                return new LoginResult { Successful = false, Error = $"Erreur de connexion: {response.ReasonPhrase} - {errorContent}" };
            }
            catch (HttpRequestException ex)
            {
                // Gère les erreurs liées au réseau (serveur non démarré, URL incorrecte, problème de connexion)
                return new LoginResult { Successful = false, Error = $"Erreur réseau lors de la connexion: {ex.Message}" };
            }
            catch (Exception ex)
            {
                // Gère toute autre erreur inattendue lors du processus de connexion
                return new LoginResult { Successful = false, Error = $"Une erreur inattendue est survenue: {ex.Message}" };
            }
        }

        // Gère la déconnexion de l'utilisateur
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken"); // Supprime le token du stockage local
            // Notifie Blazor que l'utilisateur est déconnecté
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null; // Supprime l'en-tête d'autorisation pour toutes les futures requêtes HttpClient
        }
    }
}