// AdminMns/Services/CustomUserClaimsPrincipalFactory.cs
using AdminMns.Data; // Pour votre AppUser
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;


public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, IdentityRole>
{
    public CustomUserClaimsPrincipalFactory(
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
    {
        
        var identity = await base.GenerateClaimsAsync(user);

       
        if (!string.IsNullOrWhiteSpace(user.Nom)) 
        {
            identity.AddClaim(new Claim("Nom", user.Nom));
        }

        if (!string.IsNullOrWhiteSpace(user.Prenom)) 
        {
            identity.AddClaim(new Claim("Prenom", user.Prenom));
        }


        identity.AddClaim(new Claim("Organization", "AdminMnsCorp"));

        return identity;
    }
}