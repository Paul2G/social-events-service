using web_api_learning.Modules.Auth.Models;
using web_api_learning.Modules.SocialEvents.DTOs;
using web_api_learning.Modules.SocialEvents.Models;

namespace web_api_learning.Modules.SocialEvents.Interfaces;

public interface ISocialEventRepository
{
    Task<List<SocialEvent>> GetAllAsync(AppUser appUser);
    Task<SocialEvent?> GetByIdAsync(AppUser appUser, long id);

    Task<SocialEvent> CreateAsync(AppUser appUser, CreateSocialEventDto socialEventDto);

    Task<SocialEvent?> UpdateAsync(AppUser appUser, long id, UpdateSocialEventDto socialEventDto);

    Task<SocialEvent?> DeleteAsync(AppUser appUser, long id);
    Task<bool> ExitsAsync(AppUser appUser, long id);
}