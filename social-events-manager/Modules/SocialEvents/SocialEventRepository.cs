using Microsoft.EntityFrameworkCore;
using social_events_manager.Data;
using social_events_manager.Modules.Auth.Interfaces;
using social_events_manager.Modules.SocialEvents.DTOs;
using social_events_manager.Modules.SocialEvents.Interfaces;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.SocialEvents;

public class SocialEventRepository : ISocialEventRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IUserService _userService;

    public SocialEventRepository(
        ApplicationDbContext applicationDbContext,
        IUserService userService)
    {
        _applicationDbContext = applicationDbContext;
        _userService = userService;
    }

    public async Task<List<SocialEvent>> GetAllAsync()
    {
        return await _applicationDbContext
            .SocialEvents.Where(s =>
                s.AppUserId == _userService.GetUserId())
            .Include(c => c.Attendees)
            .Include(c => c.Location)
            .ToListAsync();
    }

    public async Task<SocialEvent?> GetByIdAsync(long id)
    {
        return await _applicationDbContext
            .SocialEvents.Where(s => s.AppUserId == _userService.GetUserId())
            .Include(c => c.Attendees)
            .Include(c => c.Location)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<SocialEvent> CreateAsync(CreateSocialEventDto socialEventDto)
    {
        var socialEventModel = socialEventDto.ToSocialEvent(_userService.GetUserId());

        await _applicationDbContext.SocialEvents.AddAsync(socialEventModel);
        await _applicationDbContext.SaveChangesAsync();

        return socialEventModel;
    }

    public async Task<SocialEvent?> UpdateAsync(long id, UpdateSocialEventDto socialEventDto)
    {
        var socialEventModel = await _applicationDbContext.SocialEvents
            .Where(s => s.AppUserId == _userService.GetUserId())
            .FirstOrDefaultAsync(x => x.Id == id);

        if (socialEventModel == null)
            return null;

        socialEventModel.ParseFromUpdateSocialEventDto(socialEventDto);
        await _applicationDbContext.SaveChangesAsync();

        return socialEventModel;
    }

    public async Task<SocialEvent?> DeleteAsync(long id)
    {
        var socialEventModel = await _applicationDbContext.SocialEvents
            .Where(s => s.AppUserId == _userService.GetUserId())
            .FirstOrDefaultAsync(x => x.Id == id);

        if (socialEventModel == null)
            return null;

        _applicationDbContext.SocialEvents.Remove(socialEventModel);
        await _applicationDbContext.SaveChangesAsync();

        return socialEventModel;
    }

    public async Task<bool> ExitsAsync(long id)
    {
        return await _applicationDbContext.SocialEvents.Where(s => s.AppUserId == _userService.GetUserId())
            .AnyAsync(s => s.Id == id);
    }
}