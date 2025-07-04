using social_events_manager.Modules.Locations.DTOs;
using social_events_manager.Modules.Shared.DTOs;

namespace social_events_manager.Modules.Locations.Interfaces;

public interface ILocationService
{
    Task<List<ReadLocationDto>> GetAllAsync();
    Task<PaginatedListDto<ReadLocationDto>> GetAllPaginatedAsync(
        PaginationQueryDto paginationQueryDto
    );

    Task<ReadLocationDto> GetByIdAsync(long id);
    Task<ReadLocationDto> CreateAsync(CreateLocationDto locationDto);
    Task<ReadLocationDto> UpdateAsync(long id, UpdateLocationDto locationDto);
    Task<ReadLocationDto> DeleteAsync(long id);
}
