using social_events_manager.Modules.Auth.Models;

namespace social_events_manager.Modules.Auth.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}