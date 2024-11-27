using web_api_learning.Modules.Locations.DTOs;
using web_api_learning.Modules.Locations.Models;

namespace web_api_learning.Modules.Locations.Interfaces;

public interface ILocationRepository
{
    Task<List<Location>> GetAllAsync();
    Task<Location?> GetByIdAsync(long id);
    Task<Location> CreateAsync(CreateLocationDto locationDto);
    Task<Location?> UpdateAsync(long id, UpdateLocationDto locationDto);
    Task<Location?> DeleteAsync(long id);
    Task<bool> ExistsAsync(long id);
}