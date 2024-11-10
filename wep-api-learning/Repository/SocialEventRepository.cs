using Microsoft.EntityFrameworkCore;
using wep_api_learning.Data;
using wep_api_learning.Dtos.SocialEvent;
using wep_api_learning.Interfaces;
using wep_api_learning.Models;

namespace wep_api_learning.Repository;

public class SocialEventRepository : ISocialEventRepository
{
    private readonly ApplicationDBContext _context;

    public SocialEventRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public Task<List<SocialEvent>> GetAllAsync()
    {
        return _context.SocialEvents.ToListAsync();
    }

    public async Task<SocialEvent?> GetByIdAsync(int id)
    {
        return await _context.SocialEvents.FindAsync(id);
    }

    public async Task<SocialEvent> CreateAsync(SocialEvent socialEventModel)
    {
        await _context.SocialEvents.AddAsync(socialEventModel);
        await _context.SaveChangesAsync();

        return socialEventModel;
    }

    public async Task<SocialEvent?> UpdateAsync(int id, UpdateSocialEventDto socialEventDto)
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

    public async Task<SocialEvent?> DeleteAsync(int id)
    {
        var socialEventModel = await _context.SocialEvents.FirstOrDefaultAsync(x => x.Id == id);

        if (socialEventModel == null)
            return null;

        _context.SocialEvents.Remove(socialEventModel);
        await _context.SaveChangesAsync();

        return socialEventModel;
    }
}
