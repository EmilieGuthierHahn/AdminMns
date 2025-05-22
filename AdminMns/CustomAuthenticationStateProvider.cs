using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt; // Pour décoder le JWT
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic; // Pour List<Claim>
using System.Linq; // Pour .Select
using System.Net.Http; // Pour HttpClient
using System; // Pour Convert, Exception, DateTime
using System.Text.Json; // Pour JsonSerializer

// Vous pouvez ajuster le namespace si vous placez ce fichier dans un sous-dossier, par exemple:
// namespace AdminMns.Components.Authentication
// {
public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _httpClient; // HttpClient est nécessaire pour manipuler l'en-tête d'autorisation

    public CustomAuthenticationStateProvider(ILocalStorageService localStorage, HttpClient httpClient)
    {
        _localStorage = localStorage;
        _httpClient = httpClient;
    }

    // Cette méthode est appelée par Blazor pour obtenir l'état d'authentification actuel
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken"); // Récupère le token du stockage local du navigateur
        var identity = new ClaimsIdentity(); // Crée une identité vide par défaut (utilisateur non authentifié)

        // Réinitialise l'en-tête d'autorisation de HttpClient. C'est important pour éviter d'envoyer
        // un token périmé ou invalide lors des requêtes si l'état change ou si le token a été effacé.
        _httpClient.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrEmpty(token)) // Si un token est trouvé
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token); // Tente de lire (décoder) le JWT

                // Vérifier la date d'expiration du token
                var expirationDate = jwtToken.ValidTo;
                if (expirationDate < DateTime.UtcNow) // Si le token est expiré
                {
                    await _localStorage.RemoveItemAsync("authToken"); // Supprime le token périmé
                    token = null; // Marque le token comme invalide pour créer une ClaimsIdentity vide
                }
                else // Si le token est valide et non expiré
                {
                    // Crée une ClaimsIdentity en parsant les claims du token
                    identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
                    // Définit l'en-tête d'autorisation pour que HttpClient inclue le token dans les futures requêtes
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
            }
            catch (Exception ex)
            {
                // Gère les erreurs si le JWT est malformé ou ne peut pas être lu
                Console.WriteLine($"Erreur de décodage ou de validation JWT: {ex.Message}");
                await _localStorage.RemoveItemAsync("authToken"); // Supprime le token invalide
                token = null; // Marque le token comme invalide
            }
        }

        // Retourne un AuthenticationState qui représente l'état actuel de l'utilisateur
        var user = new ClaimsPrincipal(identity);
        return new AuthenticationState(user);
    }

    // Méthode appelée par AuthService pour signaler qu'un utilisateur est authentifié
    public void MarkUserAsAuthenticated(string token)
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
        // Définit l'en-tête d'autorisation immédiatement après une connexion réussie
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        // Notifie tous les composants Blazor qui observent l'état d'authentification
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(authenticatedUser)));
    }

    // Méthode appelée par AuthService pour signaler qu'un utilisateur est déconnecté
    public void MarkUserAsLoggedOut()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        // Notifie tous les composants Blazor que l'état d'authentification a changé
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
    }

    // Méthode utilitaire pour extraire les claims du payload d'un JWT
    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var claims = new List<Claim>();
        var payload = jwt.Split('.')[1]; // Le payload est la deuxième partie du JWT

        // Décode le payload Base64 (qui peut ne pas avoir de padding standard)
        var jsonBytes = ParseBase64WithoutPadding(payload);
        // Désérialise le JSON du payload en un dictionnaire de paires clé-valeur
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        // Gère spécifiquement le claim de rôle, car il peut être une chaîne unique ou un tableau de chaînes
        keyValuePairs!.TryGetValue(ClaimTypes.Role, out object? roles);

        if (roles != null)
        {
            if (roles.ToString()!.Trim().StartsWith("[")) // Si c'est un tableau JSON de rôles
            {
                var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString()!);
                claims.AddRange(parsedRoles!.Select(role => new Claim(ClaimTypes.Role, role)));
            }
            else // Si c'est une seule chaîne de rôle
            {
                claims.Add(new Claim(ClaimTypes.Role, roles.ToString()!));
            }
            keyValuePairs.Remove(ClaimTypes.Role); // Supprime le claim de rôle du dictionnaire pour éviter les doublons
        }

        // Ajoute tous les autres claims restants
        claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!)));
        return claims;
    }

    // Méthode utilitaire pour décoder une chaîne Base64 qui pourrait manquer de padding
    private byte[] ParseBase64WithoutPadding(string base64)
    {
        // Ajoute le padding manquant si nécessaire
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}
// } // Fin du namespace si vous en avez un