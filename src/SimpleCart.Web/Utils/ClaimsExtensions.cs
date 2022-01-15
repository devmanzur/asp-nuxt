using System.Security.Claims;

namespace SimpleCart.Web.Utils;

public static class ClaimsExtensions
{
    public static string? GetIdentityClaimValue(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        return claimsPrincipal.Identities.FirstOrDefault()?.Claims?.FirstOrDefault(x => x.Type == claimType)?.Value;
    }
}