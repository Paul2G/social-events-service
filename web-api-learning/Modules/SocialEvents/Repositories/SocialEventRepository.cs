using Microsoft.EntityFrameworkCore;
using web_api_learning.Data;
using web_api_learning.Modules.SocialEvents.DTOs;
using web_api_learning.Modules.SocialEvents.Interfaces;
using web_api_learning.Modules.SocialEvents.Models;

namespace web_api_learning.Modules.SocialEvents.Repositories;

public class SocialEventRepository : ISocialEventRepository
{
    private readonly ApplicationDbContext _context;

    public SocialEventRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SocialEvent>> GetAllAsync()
    {
        return await _context.SocialEvents.Include(c => c.Attendees).ToListAsync();
    }

    public async Task<SocialEvent?> GetByIdAsync(long id)
    {
        return await _context.SocialEvents.Include(c => c.Attendees).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<SocialEvent> CreateAsync(SocialEvent socialEventModel)
    {
        await _context.SocialEvents.AddAsync(socialEventModel);
        await _context.SaveChangesAsync();

        return socialEventModel;
    }

    public async Task<SocialEvent?> UpdateAsync(long id, UpdateSocialEventDto socialEventDto)
    {
        var socialEventModel = await _context.SocialEvents.FirstOrDefaultAsync(x => x.Id == id);

        if (socialEventModel == null)
            return null;

        socialEventModel.Name = socialEventDto.Name;
        socialEventModel.Description = socialEventDto.Description;
        socialEventModel.Location = socialEventDto.Location;
        socialEventModel.StartTime = socialEventDto.StartTime;
        socialEventModel.EndTime = socialEventDto.EndTime;

        await _context.SaveChangesAsync();

        return socialEventModel;
    }

    public async Task<SocialEvent?> DeleteAsync(long id)
    {
        var socialEventModel = await _context.SocialEvents.FirstOrDefaultAsync(x => x.Id == id);

        if (socialEventModel == null)
            return null;

        _context.SocialEvents.Remove(socialEventModel);
        await _context.SaveChangesAsync();

        return socialEventModel;
    }
}