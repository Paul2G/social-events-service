using social_events_manager.Exceptions;
using social_events_manager.Modules.Auth.Interfaces;
using social_events_manager.Modules.Locations.DTOs;
using social_events_manager.Modules.Locations.Interfaces;
using social_events_manager.Modules.Shared;
using social_events_manager.Modules.Shared.DTOs;

namespace social_events_manager.Modules.Locations;

public class LocationService(ILocationRepository locationRepository, IUserService userService)
    : ILocationService
{
    public async Task<List<ReadLocationSummaryDto>> GetAllAsync()
    {
        var locations = await locationRepository.FindLocations();

        return locations.Select(l => l.ToLocationSummaryDto()).ToList();
    }

    public async Task<PaginatedListDto<ReadLocationDto>> GetAllPaginatedAsync(
        PaginationQueryDto paginationQueryDto
    )
    {
        var paginationQuery = paginationQueryDto.ToPaginationQuery();

        var locationsCount = await locationRepository.CountLocations();
        var locations = await locationRepository.FindLocationsPaginated(
            paginationQuery.Limit,
            paginationQuery.Offset
        );

        return new PaginatedListDto<ReadLocationDto>(
            locations.Select(l => l.ToLocationDto()).ToList(),
            paginationQuery.Page,
            paginationQuery.PageSize,
            locationsCount
        );
    }

    public async Task<ReadLocationDto> GetByIdAsync(long id)
    {
        var location = await locationRepository.FindLocationById(id);

        if (location == null)
            throw new ItemNotFoundException($"Location with ID {id} not found");

        return location.ToLocationDto();
    }

    public async Task<ReadLocationDto> CreateAsync(CreateLocationDto locationDto)
    {
        var incomingLocation = locationDto.ToLocation();
        incomingLocation.AppUserId = userService.GetUserId();

        var location = await locationRepository.SaveLocation(incomingLocation);

        return location.ToLocationDto();
    }

    public async Task<ReadLocationDto> UpdateAsync(long id, UpdateLocationDto locationDto)
    {
        var incomingLocation = locationDto.ToLocation();
        incomingLocation.Id = id;

        var location = await locationRepository.UpdateLocation(incomingLocation);

        if (location == null)
            throw new ItemNotFoundException($"Location with ID {id} not found");

        return location.ToLocationDto();
    }

    public async Task<ReadLocationDto> DeleteAsync(long id)
    {
        var location = await locationRepository.DeleteLocation(id);

        if (location == null)
            throw new ItemNotFoundException($"Location with ID {id} not found");

        return location.ToLocationDto();
    }
}
