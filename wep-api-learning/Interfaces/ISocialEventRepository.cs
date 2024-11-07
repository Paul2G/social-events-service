using wep_api_learning.Dtos.SocialEvent;
using wep_api_learning.Models;

namespace wep_api_learning.Interfaces;

public interface ISocialEventRepository
{
    Task<List<SocialEvent>> GetAllAsync();
    Task<SocialEvent?> GetByIdAsync(int id);
    Task<SocialEvent> CreateAsync(SocialEvent socialEventModel);
    Task<SocialEvent?> UpdateAsync(int id, UpdateSocialEventRequestDto socialEventDto);
    Task<SocialEvent?> DeleteAsync(int id);
}
