using Microsoft.EntityFrameworkCore;
using web_api_learning.Data;
using web_api_learning.Modules.Locations.Interfaces;
using web_api_learning.Modules.Locations.Models;

namespace web_api_learning.Modules.Locations.Repositories;

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
}