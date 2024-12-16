using Microsoft.EntityFrameworkCore;
using social_events_manager.Data;
using social_events_manager.Modules.Auth.Models;
using social_events_manager.Modules.SocialEvents.DTOs;
using social_events_manager.Modules.SocialEvents.Interfaces;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.SocialEvents;

public class SocialEventRepository(ApplicationDbContext context) : ISocialEventRepository
{
    public async Task<List<SocialEvent>> GetAllAsync(AppUser appUser)
    {
        return await context
            .SocialEvents.Where(s => s.AppUserId == appUser.Id)
            .Include(c => c.Attendees)
            .Include(c => c.Location)
            .ToListAsync();
    }

    public async Task<SocialEvent?> GetByIdAsync(AppUser appUser, long id)
    {
        return await context
            .SocialEvents.Where(s => s.AppUserId == appUser.Id)
            .Include(c => c.Attendees)
            .Include(c => c.Location)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<SocialEvent> CreateAsync(AppUser appUser, CreateSocialEventDto socialEventDto)
    {
        var socialEventModel = socialEventDto.ToSocialEvent(appUser.Id);

        await context.SocialEvents.AddAsync(socialEventModel);
        await context.SaveChangesAsync();

        return socialEventModel;
    }

    public async Task<SocialEvent?> UpdateAsync(AppUser appUser, long id, UpdateSocialEventDto socialEventDto)
    {
        var socialEventModel = await context.SocialEvents
            .Where(s => s.AppUserId == appUser.Id)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (socialEventModel == null)
            return null;

        socialEventModel.ParseFromUpdateSocialEventDto(socialEventDto);
        await context.SaveChangesAsync();

        return socialEventModel;
    }

    public async Task<SocialEvent?> DeleteAsync(AppUser appUser, long id)
    {
        var socialEventModel = await context.SocialEvents
            .Where(s => s.AppUserId == appUser.Id)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (socialEventModel == null)
            return null;

        context.SocialEvents.Remove(socialEventModel);
        await context.SaveChangesAsync();

        return socialEventModel;
    }

    public async Task<bool> ExitsAsync(AppUser appUser, long id)
    {
        return await context.SocialEvents.Where(s => s.AppUserId == appUser.Id).AnyAsync(s => s.Id == id);
    }
}