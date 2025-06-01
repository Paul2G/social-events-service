using Microsoft.EntityFrameworkCore;
using social_events_manager.Data;
using social_events_manager.Modules.Locations.Interfaces;
using social_events_manager.Modules.Locations.Models;

namespace social_events_manager.Modules.Locations;

public class LocationRepository(ApplicationDbContext applicationDbContext) : ILocationRepository
{
    public async Task<List<Location>> FindUserLocations(string userId)
    {
        return await applicationDbContext.Locations.Where(a => a.AppUserId == userId).ToListAsync();
    }

    public async Task<Location?> FindUserLocationById(string userId, long id)
    {
        return await applicationDbContext.Locations.FirstOrDefaultAsync(l =>
            l.Id == id && l.AppUserId == userId
        );
    }

    public async Task<Location> SaveUserLocation(string userId, Location location)
    {
        location.AppUserId = userId;

        var createdLocation = await applicationDbContext.Locations.AddAsync(location);
        await applicationDbContext.SaveChangesAsync();

        return createdLocation.Entity;
    }

    public async Task<Location?> UpdateUserLocation(string userId, Location location)
    {
        var existingLocation = await applicationDbContext.Locations.FirstOrDefaultAsync(l =>
            l.Id == location.Id && l.AppUserId == userId
        );

        if (existingLocation == null)
            return null;

        applicationDbContext.Entry(existingLocation).CurrentValues.SetValues(location);
        existingLocation.AppUserId = userId;

        await applicationDbContext.SaveChangesAsync();

        return existingLocation;
    }

    public async Task<Location?> DeleteUserLocation(string userId, long id)
    {
        var existingLocation = await applicationDbContext.Locations.FirstOrDefaultAsync(l =>
            l.Id == id && l.AppUserId == userId
        );

        if (existingLocation == null)
            return null;

        applicationDbContext.Locations.Remove(existingLocation);
        await applicationDbContext.SaveChangesAsync();

        return existingLocation;
    }

    public async Task<bool> ExistsUserLocation(string userId, long id)
    {
        return await applicationDbContext.Locations.AnyAsync(l =>
            l.Id == id && l.AppUserId == userId
        );
    }
}
