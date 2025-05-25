using System.Security.Claims;
using social_events_manager.Modules.Auth.Interfaces;

namespace social_events_manager.Modules.Auth.Services;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUserName()
    {
        return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.GivenName)?.Value!;
    }

    public string GetUserId()
    {
        return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
    }
}