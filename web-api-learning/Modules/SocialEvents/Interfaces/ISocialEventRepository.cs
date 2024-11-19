using web_api_learning.Modules.SocialEvents.DTOs;
using web_api_learning.Modules.SocialEvents.Models;

namespace web_api_learning.Modules.SocialEvents.Interfaces;

public interface ISocialEventRepository
{
    Task<List<SocialEvent>> GetAllAsync();
    Task<SocialEvent?> GetByIdAsync(long id);

    Task<SocialEvent> CreateAsync(SocialEvent socialEventModel);

    Task<SocialEvent?> UpdateAsync(long id, UpdateSocialEventDto socialEventDto);

    Task<SocialEvent?> DeleteAsync(long id);
    Task<bool> ExitsAsync(long id);
}