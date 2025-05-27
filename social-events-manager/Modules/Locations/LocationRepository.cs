using Microsoft.EntityFrameworkCore;
using social_events_manager.Data;
using social_events_manager.Modules.Locations.Interfaces;
using social_events_manager.Modules.Locations.Models;

namespace social_events_manager.Modules.Locations;

public class LocationRepository : ILocationRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public LocationRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Location>> FindUserLocations(string userId)
    {
        return await _applicationDbContext
            .Locations.Where(a => a.AppUserId == userId)
            .ToListAsync();
    }

    public async Task<Location?> FindUserLocationById(string userId, long id)
    {
        return await _applicationDbContext.Locations.FirstOrDefaultAsync(l =>
            l.Id == id && l.AppUserId == userId
        );
    }

    public async Task<Location> SaveUserLocation(string userId, Location location)
    {
        location.AppUserId = userId;

        var createdLocation = await _applicationDbContext.Locations.AddAsync(location);
        await _applicationDbContext.SaveChangesAsync();

        return createdLocation.Entity;
    }

    public async Task<Location?> UpdateUserLocation(string userId, Location location)
    {
        var existingLocation = await _applicationDbContext.Locations.FirstOrDefaultAsync(l =>
            l.Id == location.Id && l.AppUserId == userId
        );

        // TODO: Make this more robust, maybe throw an exception or return a specific error
        if (existingLocation == null)
            return null;

        _applicationDbContext.Entry(existingLocation).CurrentValues.SetValues(location);
        existingLocation.AppUserId = userId;

        await _applicationDbContext.SaveChangesAsync();

        return existingLocation;
    }

    public async Task<Location?> DeleteUserLocation(string userId, long id)
    {
        var existingLocation = await _applicationDbContext.Locations.FirstOrDefaultAsync(l =>
            l.Id == id && l.AppUserId == userId
        );

        // TODO: Make this more robust, maybe throw an exception or return a specific error
        if (existingLocation == null)
            return null;

        _applicationDbContext.Locations.Remove(existingLocation);
        await _applicationDbContext.SaveChangesAsync();

        return existingLocation;
    }

    public async Task<bool> ExistsUserLocation(string userId, long id)
    {
        return await _applicationDbContext.Locations.AnyAsync(l =>
            l.Id == id && l.AppUserId == userId
        );
    }
}
