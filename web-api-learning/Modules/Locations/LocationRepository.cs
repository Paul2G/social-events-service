using Microsoft.EntityFrameworkCore;
using web_api_learning.Data;
using web_api_learning.Modules.Locations.DTOs;
using web_api_learning.Modules.Locations.Interfaces;
using web_api_learning.Modules.Locations.Models;

namespace web_api_learning.Modules.Locations;

public class LocationRepository(ApplicationDbContext context) : ILocationRepository
{
    public async Task<List<Location>> GetAllAsync()
    {
        return await context.Locations.ToListAsync();
    }

    public async Task<Location?> GetByIdAsync(long id)
    {
        return await context.Locations.FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<Location> CreateAsync(CreateLocationDto locationDto)
    {
        var locationModel = locationDto.ToLocation();
        await context.Locations.AddAsync(locationModel);
        await context.SaveChangesAsync();

        return locationModel;
    }

    public async Task<Location?> UpdateAsync(long id, UpdateLocationDto locationDto)
    {
        var locationModel = await context.Locations.FirstOrDefaultAsync(l => l.Id == id);

        if (locationModel == null) return null;

        locationModel.ParseFromUpdateLocationDto(locationDto);

        await context.SaveChangesAsync();

        return locationModel;
    }

    public async Task<Location?> DeleteAsync(long id)
    {
        var locationModel = await context.Locations.FirstOrDefaultAsync(l => l.Id == id);

        if (locationModel == null) return null;

        context.Locations.Remove(locationModel);
        await context.SaveChangesAsync();

        return locationModel;
    }

    public Task<bool> ExistsAsync(long id)
    {
        return context.Locations.AnyAsync(l => l.Id == id);
    }
}