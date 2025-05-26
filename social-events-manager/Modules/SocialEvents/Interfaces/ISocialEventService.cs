using social_events_manager.Modules.SocialEvents.DTOs;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.SocialEvents.Interfaces;

public interface ISocialEventService
{
    Task<List<ReadSocialEventDto>> GetAllAsync();
    Task<ReadSocialEventDto?> GetByIdAsync(long id);

    Task<ReadSocialEventDto> CreateAsync(CreateSocialEventDto socialEventDto);

    Task<ReadSocialEventDto?> UpdateAsync(long id, UpdateSocialEventDto socialEventDto);

    Task<ReadSocialEventDto?> DeleteAsync(long id);
    Task<bool> ExitsAsync(long id);
}