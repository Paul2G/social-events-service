using Microsoft.EntityFrameworkCore;
using social_events_manager.Data;
using social_events_manager.Modules.SocialEvents.Interfaces;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.SocialEvents;

public class SocialEventRepository(ApplicationDbContext applicationDbContext)
    : ISocialEventRepository
{
    public async Task<List<SocialEvent>> FindUserSocialEvents(string userId)
    {
        return await applicationDbContext
            .SocialEvents.Where(s => s.AppUserId == userId)
            .Include(c => c.Attendees)
            .Include(c => c.Location)
            .ToListAsync();
    }

    public async Task<SocialEvent?> FindUserSocialEventById(string userId, long id)
    {
        return await applicationDbContext
            .SocialEvents.Include(c => c.Attendees)
            .Include(c => c.Location)
            .FirstOrDefaultAsync(c => c.Id == id && c.AppUserId == userId);
    }

    public async Task<SocialEvent> SaveUserSocialEvent(string userId, SocialEvent socialEvent)
    {
        socialEvent.AppUserId = userId;

        await applicationDbContext.SocialEvents.AddAsync(socialEvent);
        await applicationDbContext.SaveChangesAsync();

        return socialEvent;
    }

    public async Task<SocialEvent?> UpdateUserSocialEvent(string userId, SocialEvent socialEvent)
    {
        var existingSocialEvent = await applicationDbContext.SocialEvents.FirstOrDefaultAsync(s =>
            s.Id == socialEvent.Id && s.AppUserId == userId
        );

        if (existingSocialEvent == null)
            return null;

        applicationDbContext.Entry(existingSocialEvent).CurrentValues.SetValues(socialEvent);
        existingSocialEvent.AppUserId = userId;

        await applicationDbContext.SaveChangesAsync();

        return existingSocialEvent;
    }

    public async Task<SocialEvent?> DeleteUserSocialEvent(string userId, long id)
    {
        var existingSocialEvent = await applicationDbContext.SocialEvents.FirstOrDefaultAsync(x =>
            x.Id == id && x.AppUserId == userId
        );

        if (existingSocialEvent == null)
            return null;

        applicationDbContext.SocialEvents.Remove(existingSocialEvent);
        await applicationDbContext.SaveChangesAsync();

        return existingSocialEvent;
    }

    public async Task<bool> ExitsUserSocialEvent(string userId, long id)
    {
        return await applicationDbContext.SocialEvents.AnyAsync(s =>
            s.Id == id && s.AppUserId == userId
        );
    }
}
