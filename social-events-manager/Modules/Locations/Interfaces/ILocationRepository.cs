using social_events_manager.Modules.Auth.Models;
using social_events_manager.Modules.Locations.DTOs;
using social_events_manager.Modules.Locations.Models;

namespace social_events_manager.Modules.Locations.Interfaces;

public interface ILocationRepository
{
    Task<List<Location>> GetAllAsync(AppUser appUser);
    Task<Location?> GetByIdAsync(AppUser appUser, long id);
    Task<Location> CreateAsync(AppUser appUser, CreateLocationDto locationDto);
    Task<Location?> UpdateAsync(AppUser appUser, long id, UpdateLocationDto locationDto);
    Task<Location?> DeleteAsync(AppUser appUser, long id);
    Task<bool> ExistsAsync(AppUser appUser, long id);
}