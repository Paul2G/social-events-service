using social_events_manager.Modules.SocialEvents.DTOs;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.SocialEvents.Interfaces;

public interface ISocialEventRepository
{
    Task<List<SocialEvent>> GetAllAsync();
    Task<SocialEvent?> GetByIdAsync(long id);

    Task<SocialEvent> CreateAsync(CreateSocialEventDto socialEventDto);

    Task<SocialEvent?> UpdateAsync(long id, UpdateSocialEventDto socialEventDto);

    Task<SocialEvent?> DeleteAsync(long id);
    Task<bool> ExitsAsync(long id);
}