using web_api_learning.Modules.Auth.Models;

namespace web_api_learning.Modules.Auth.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}