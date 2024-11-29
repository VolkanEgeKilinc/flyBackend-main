using System.Security.Claims;

namespace BilethubApi.Core.Extensions;

public static class ClaimsPrincipalExtension{

    public static Claim? GetPrimaryClaim(this ClaimsPrincipal user, string type) => (user.Identity as ClaimsIdentity)?.FindFirst(type);
}