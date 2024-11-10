using Microsoft.EntityFrameworkCore;
using wep_api_learning.Data;
using wep_api_learning.Modules.SocialEvent.DTOs;
using wep_api_learning.Modules.SocialEvent.Interfaces;

namespace wep_api_learning.Modules.SocialEvent.Repositories;

public class SocialEventRepository : ISocialEventRepository
{
    private readonly ApplicationDbContext _context;

    public SocialEventRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<List<Models.SocialEvent>> GetAllAsync()
    {
        return _context.SocialEvents.ToListAsync();
    }

    public async Task<Models.SocialEvent?> GetByIdAsync(long id)
    {
        return await _context.SocialEvents.FindAsync(id);
    }

    public async Task<Models.SocialEvent> CreateAsync(Models.SocialEvent socialEventModel)
    {
        await _context.SocialEvents.AddAsync(socialEventModel);
        await _context.SaveChangesAsync();

        return socialEventModel;
    }

    public async Task<Models.SocialEvent?> UpdateAsync(long id, UpdateSocialEventDto socialEventDto)
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

    public async Task<Models.SocialEvent?> DeleteAsync(long id)
    {
        var socialEventModel = await _context.SocialEvents.FirstOrDefaultAsync(x => x.Id == id);

        if (socialEventModel == null)
            return null;

        _context.SocialEvents.Remove(socialEventModel);
        await _context.SaveChangesAsync();

        return socialEventModel;
    }
}
