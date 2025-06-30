using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.SocialEvents.Interfaces;

public interface ISocialEventRepository
{
    Task<List<SocialEvent>> FindUserSocialEvents(string userId);
    Task<List<SocialEvent>> FindUserSocialEventsPaginated(string userId, int limit, int offset);
    Task<SocialEvent?> FindUserSocialEventById(string userId, long id);

    Task<SocialEvent> SaveUserSocialEvent(string userId, SocialEvent socialEvent);

    Task<SocialEvent?> UpdateUserSocialEvent(string userId, SocialEvent socialEvent);

    Task<SocialEvent?> DeleteUserSocialEvent(string userId, long id);
    Task<bool> ExitsUserSocialEvent(string userId, long id);
    Task<int> CountUserSocialEvents(string userId);
}
