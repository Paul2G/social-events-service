using social_events_manager.Modules.Locations.Models;

namespace social_events_manager.Modules.Locations.Interfaces;

public interface ILocationRepository
{
    Task<List<Location>> FindUserLocations(string userId);
    Task<List<Location>> FindUserLocationsPaginated(string userId, int limit, int offset);
    Task<Location?> FindUserLocationById(string userId, long id);
    Task<Location> SaveUserLocation(string userId, Location location);
    Task<Location?> UpdateUserLocation(string userId, Location location);
    Task<Location?> DeleteUserLocation(string userId, long id);
    Task<bool> ExistsUserLocation(string userId, long id);
    Task<int> CountUserLocations(string userId);
}
