using social_events_manager.Modules.Locations.Models;

namespace social_events_manager.Modules.Locations.Interfaces;

public interface ILocationRepository
{
    Task<List<Location>> FindLocations();
    Task<List<Location>> FindLocationsPaginated(int limit, int offset);
    Task<Location?> FindLocationById(long id);
    Task<Location> SaveLocation(Location location);
    Task<Location?> UpdateLocation(Location location);
    Task<Location?> DeleteLocation(long id);
    Task<bool> ExistsLocation(long id);
    Task<int> CountLocations();
}
