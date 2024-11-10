using wep_api_learning.Modules.SocialEvent.DTOs;

namespace wep_api_learning.Modules.SocialEvent.Interfaces;

public interface ISocialEventRepository
{
    Task<List<Models.SocialEvent>> GetAllAsync();
    Task<Models.SocialEvent?> GetByIdAsync(long id);
    Task<Models.SocialEvent> CreateAsync(Models.SocialEvent socialEventModel);
    Task<Models.SocialEvent?> UpdateAsync(long id, UpdateSocialEventDto socialEventDto);
    Task<Models.SocialEvent?> DeleteAsync(long id);
}
