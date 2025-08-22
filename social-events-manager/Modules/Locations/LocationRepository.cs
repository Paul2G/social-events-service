using Microsoft.EntityFrameworkCore;
using social_events_manager.Data;
using social_events_manager.Modules.Locations.Interfaces;
using social_events_manager.Modules.Locations.Models;

namespace social_events_manager.Modules.Locations;

public class LocationRepository(ApplicationDbContext applicationDbContext) : ILocationRepository
{
    public async Task<List<Location>> FindLocations()
    {
        return await applicationDbContext.Locations.ToListAsync();
    }

    public async Task<List<Location>> FindLocationsPaginated(int limit, int offset)
    {
        return await applicationDbContext
            .Locations.Include((l) => l.SocialEvents)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<Location?> FindLocationById(long id)
    {
        return await applicationDbContext
            .Locations.Include((l) => l.SocialEvents)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<Location> SaveLocation(Location location)
    {
        var createdLocation = await applicationDbContext.Locations.AddAsync(location);
        await applicationDbContext.SaveChangesAsync();

        return createdLocation.Entity;
    }

    public async Task<Location?> UpdateLocation(Location location)
    {
        var existingLocation = await applicationDbContext.Locations.FirstOrDefaultAsync(l =>
            l.Id == location.Id
        );

        if (existingLocation == null)
            return null;

        applicationDbContext.Entry(existingLocation).CurrentValues.SetValues(location);

        await applicationDbContext.SaveChangesAsync();

        return existingLocation;
    }

    public async Task<Location?> DeleteLocation(long id)
    {
        var existingLocation = await applicationDbContext.Locations.FirstOrDefaultAsync(l =>
            l.Id == id
        );

        if (existingLocation == null)
            return null;

        applicationDbContext.Locations.Remove(existingLocation);
        await applicationDbContext.SaveChangesAsync();

        return existingLocation;
    }

    public Task<bool> ExistsLocation(long id)
    {
        return applicationDbContext.Locations.AnyAsync(l => l.Id == id);
    }

    public Task<int> CountLocations()
    {
        return applicationDbContext.Locations.CountAsync();
    }
}
