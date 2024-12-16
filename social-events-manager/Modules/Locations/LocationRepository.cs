using Microsoft.EntityFrameworkCore;
using social_events_manager.Data;
using social_events_manager.Modules.Auth.Models;
using social_events_manager.Modules.Locations.DTOs;
using social_events_manager.Modules.Locations.Interfaces;
using social_events_manager.Modules.Locations.Models;

namespace social_events_manager.Modules.Locations;

public class LocationRepository(ApplicationDbContext context) : ILocationRepository
{
    public async Task<List<Location>> GetAllAsync(AppUser appUser)
    {
        return await context.Locations.Where(a => a.AppUserId == appUser.Id).ToListAsync();
    }

    public async Task<Location?> GetByIdAsync(AppUser appUser, long id)
    {
        return await context.Locations.Where(a => a.AppUserId == appUser.Id).FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<Location> CreateAsync(AppUser appUser, CreateLocationDto locationDto)
    {
        var locationModel = locationDto.ToLocation(appUser.Id);
        await context.Locations.AddAsync(locationModel);
        await context.SaveChangesAsync();

        return locationModel;
    }

    public async Task<Location?> UpdateAsync(AppUser appUser, long id, UpdateLocationDto locationDto)
    {
        var locationModel = await context.Locations
            .Where(a => a.AppUserId == appUser.Id)
            .FirstOrDefaultAsync(l => l.Id == id);

        if (locationModel == null) return null;

        locationModel.ParseFromUpdateLocationDto(locationDto);
        await context.SaveChangesAsync();

        return locationModel;
    }

    public async Task<Location?> DeleteAsync(AppUser appUser, long id)
    {
        var locationModel = await context.Locations
            .Where(a => a.AppUserId == appUser.Id)
            .FirstOrDefaultAsync(l => l.Id == id);

        if (locationModel == null) return null;

        context.Locations.Remove(locationModel);
        await context.SaveChangesAsync();

        return locationModel;
    }

    public Task<bool> ExistsAsync(AppUser appUser, long id)
    {
        return context.Locations.Where(a => a.AppUserId == appUser.Id).AnyAsync(l => l.Id == id);
    }
}