using social_events_manager.Modules.Auth.Interfaces;
using social_events_manager.Modules.Locations.DTOs;
using social_events_manager.Modules.Locations.Interfaces;

namespace social_events_manager.Modules.Locations;

public class LocationService(ILocationRepository locationRepository, IUserService userService)
    : ILocationService
{
    public async Task<List<ReadLocationDto>> GetAllAsync()
    {
        var locations = await locationRepository.FindUserLocations(userService.GetUserId());

        return (List<ReadLocationDto>)locations.Select(l => l.ToLocationDto());
    }

    public async Task<ReadLocationDto?> GetByIdAsync(long id)
    {
        var location = await locationRepository.FindUserLocationById(userService.GetUserId(), id);

        return location.ToLocationDto();
    }

    public async Task<ReadLocationDto> CreateAsync(CreateLocationDto locationDto)
    {
        var incomingLocation = locationDto.ToLocation();

        var location = await locationRepository.SaveUserLocation(
            userService.GetUserId(),
            incomingLocation
        );

        return location.ToLocationDto();
    }

    public async Task<ReadLocationDto?> UpdateAsync(long id, UpdateLocationDto locationDto)
    {
        var incomingLocation = locationDto.ToLocation();
        incomingLocation.Id = id;

        var location = await locationRepository.UpdateUserLocation(
            userService.GetUserId(),
            incomingLocation
        );

        return location.ToLocationDto();
    }

    public async Task<ReadLocationDto?> DeleteAsync(long id)
    {
        var location = await locationRepository.DeleteUserLocation(userService.GetUserId(), id);

        return location.ToLocationDto();
    }
}
