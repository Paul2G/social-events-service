using System.Security.Claims;

namespace social_events_manager.Modules.Auth.Extensions;

public static class ClaimsExtension
{
    public static string GetUsername(this ClaimsPrincipal user)
    {
        return user.Claims
            .SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"))
            .Value;
    }
}