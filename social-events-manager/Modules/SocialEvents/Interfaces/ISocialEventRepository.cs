using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.SocialEvents.Interfaces;

public interface ISocialEventRepository
{
    Task<List<SocialEvent>> FindSocialEvents();
    Task<List<SocialEvent>> FindSocialEventsPaginated(int limit, int offset);
    Task<SocialEvent?> FindSocialEventById(long id);

    Task<SocialEvent> SaveSocialEvent(SocialEvent socialEvent);

    Task<SocialEvent?> UpdateSocialEvent(SocialEvent socialEvent);

    Task<SocialEvent?> DeleteSocialEvent(long id);
    Task<bool> ExitsSocialEvent(long id);
    Task<int> CountSocialEvents();
}
