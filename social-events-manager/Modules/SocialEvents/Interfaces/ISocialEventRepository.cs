using social_events_manager.Modules.Auth.Models;
using social_events_manager.Modules.SocialEvents.DTOs;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.SocialEvents.Interfaces;

public interface ISocialEventRepository
{
    Task<List<SocialEvent>> GetAllAsync(AppUser appUser);
    Task<SocialEvent?> GetByIdAsync(AppUser appUser, long id);

    Task<SocialEvent> CreateAsync(AppUser appUser, CreateSocialEventDto socialEventDto);

    Task<SocialEvent?> UpdateAsync(AppUser appUser, long id, UpdateSocialEventDto socialEventDto);

    Task<SocialEvent?> DeleteAsync(AppUser appUser, long id);
    Task<bool> ExitsAsync(AppUser appUser, long id);
}