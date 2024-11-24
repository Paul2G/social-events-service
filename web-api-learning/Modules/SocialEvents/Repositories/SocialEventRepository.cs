using Microsoft.EntityFrameworkCore;
using web_api_learning.Data;
using web_api_learning.Modules.SocialEvents.DTOs;
using web_api_learning.Modules.SocialEvents.Interfaces;
using web_api_learning.Modules.SocialEvents.Models;

namespace web_api_learning.Modules.SocialEvents.Repositories;

public class SocialEventRepository(ApplicationDbContext context) : ISocialEventRepository
{
    public async Task<List<SocialEvent>> GetAllAsync()
    {
        return await context
            .SocialEvents.Include(c => c.Attendees)
            .Include(c => c.Location)
            .ToListAsync();
    }

    public async Task<SocialEvent?> GetByIdAsync(long id)
    {
        return await context
            .SocialEvents.Include(c => c.Attendees)
            .Include(c => c.Location)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<SocialEvent> CreateAsync(SocialEvent socialEventModel)
    {
        await context.SocialEvents.AddAsync(socialEventModel);
        await context.SaveChangesAsync();

        return socialEventModel;
    }

    public async Task<SocialEvent?> UpdateAsync(long id, UpdateSocialEventDto socialEventDto)
    {
        var socialEventModel = await context.SocialEvents.FirstOrDefaultAsync(x => x.Id == id);

        if (socialEventModel == null)
            return null;

        socialEventModel.Name = socialEventDto.Name;
        socialEventModel.Description = socialEventDto.Description;
        socialEventModel.LocationId = socialEventDto.LocationId;
        socialEventModel.StartTime = socialEventDto.StartTime;
        socialEventModel.EndTime = socialEventDto.EndTime;

        await context.SaveChangesAsync();

        return socialEventModel;
    }

    public async Task<SocialEvent?> DeleteAsync(long id)
    {
        var socialEventModel = await context.SocialEvents.FirstOrDefaultAsync(x => x.Id == id);

        if (socialEventModel == null)
            return null;

        context.SocialEvents.Remove(socialEventModel);
        await context.SaveChangesAsync();

        return socialEventModel;
    }

    public async Task<bool> ExitsAsync(long id)
    {
        return await context.SocialEvents.AnyAsync(s => s.Id == id);
    }
}