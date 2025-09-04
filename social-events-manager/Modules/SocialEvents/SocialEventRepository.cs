using Microsoft.EntityFrameworkCore;
using social_events_manager.Data;
using social_events_manager.Modules.SocialEvents.Interfaces;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.SocialEvents;

public class SocialEventRepository(ApplicationDbContext applicationDbContext)
    : ISocialEventRepository
{
    public async Task<List<SocialEvent>> FindSocialEvents()
    {
        return await applicationDbContext.SocialEvents.ToListAsync();
    }

    public async Task<List<SocialEvent>> FindSocialEventsPaginated(int limit, int offset)
    {
        return await applicationDbContext
            .SocialEvents.Include(c => c.Attendees)
            .Include(c => c.Location)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<SocialEvent?> FindSocialEventById(long id)
    {
        return await applicationDbContext
            .SocialEvents.Include(c => c.Attendees)
            .Include(c => c.Location)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<SocialEvent> SaveSocialEvent(SocialEvent socialEvent)
    {
        await applicationDbContext.SocialEvents.AddAsync(socialEvent);
        await applicationDbContext.SaveChangesAsync();

        return socialEvent;
    }

    public async Task<SocialEvent?> UpdateSocialEvent(SocialEvent socialEvent)
    {
        var existingSocialEvent = await applicationDbContext.SocialEvents.FirstOrDefaultAsync(s =>
            s.Id == socialEvent.Id
        );

        if (existingSocialEvent == null)
            return null;

        socialEvent.AppUserId = existingSocialEvent.AppUserId;
        applicationDbContext.Entry(existingSocialEvent).CurrentValues.SetValues(socialEvent);

        await applicationDbContext.SaveChangesAsync();

        return existingSocialEvent;
    }

    public async Task<SocialEvent?> DeleteSocialEvent(long id)
    {
        var existingSocialEvent = await applicationDbContext.SocialEvents.FirstOrDefaultAsync(x =>
            x.Id == id
        );

        if (existingSocialEvent == null)
            return null;

        applicationDbContext.SocialEvents.Remove(existingSocialEvent);
        await applicationDbContext.SaveChangesAsync();

        return existingSocialEvent;
    }

    public Task<bool> ExitsSocialEvent(long id)
    {
        return applicationDbContext.SocialEvents.AnyAsync(s => s.Id == id);
    }

    public Task<int> CountSocialEvents()
    {
        return applicationDbContext.SocialEvents.CountAsync();
    }
}
