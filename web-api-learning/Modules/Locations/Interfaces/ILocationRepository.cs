using web_api_learning.Modules.Locations.Models;

namespace web_api_learning.Modules.Locations.Interfaces;

public interface ILocationRepository
{
    Task<List<Location>> GetAllAsync();
    Task<Location?> GetByIdAsync(long id);
}