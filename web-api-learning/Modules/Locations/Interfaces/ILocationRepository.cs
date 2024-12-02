using web_api_learning.Modules.Auth.Models;
using web_api_learning.Modules.Locations.DTOs;
using web_api_learning.Modules.Locations.Models;

namespace web_api_learning.Modules.Locations.Interfaces;

public interface ILocationRepository
{
    Task<List<Location>> GetAllAsync(AppUser appUser);
    Task<Location?> GetByIdAsync(AppUser appUser, long id);
    Task<Location> CreateAsync(AppUser appUser, CreateLocationDto locationDto);
    Task<Location?> UpdateAsync(AppUser appUser, long id, UpdateLocationDto locationDto);
    Task<Location?> DeleteAsync(AppUser appUser, long id);
    Task<bool> ExistsAsync(AppUser appUser, long id);
}