using social_events_manager.Modules.Auth.Interfaces;
using social_events_manager.Modules.Locations.DTOs;
using social_events_manager.Modules.Locations.Interfaces;

namespace social_events_manager.Modules.Locations;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly IUserService _userService;

    public async Task<List<ReadLocationDto>> GetAllAsync()
    {
        var existingLocation = await _locationRepository.FindUserLocations(
            _userService.GetUserId()
        );

        return (List<ReadLocationDto>)existingLocation.Select(l => l.ToLocationDto());
    }

    public async Task<ReadLocationDto?> GetByIdAsync(long id)
    {
        var existingLocation = await _locationRepository.FindUserLocationById(
            _userService.GetUserId(),
            id
        );

        return existingLocation.ToLocationDto();
    }

    public async Task<ReadLocationDto> CreateAsync(CreateLocationDto locationDto)
    {
        var incomingLocation = locationDto.ToLocation();

        var locationModel = await _locationRepository.SaveUserLocation(
            _userService.GetUserId(),
            incomingLocation
        );

        return locationModel.ToLocationDto();
    }

    public async Task<ReadLocationDto?> UpdateAsync(long id, UpdateLocationDto locationDto)
    {
        var incomingLocation = locationDto.ToLocation();
        incomingLocation.Id = id;

        var existingLocation = await _locationRepository.UpdateUserLocation(
            _userService.GetUserId(),
            incomingLocation
        );

        return existingLocation.ToLocationDto();
    }

    public async Task<ReadLocationDto?> DeleteAsync(long id)
    {
        var existingLocation = await _locationRepository.DeleteUserLocation(
            _userService.GetUserId(),
            id
        );

        return existingLocation.ToLocationDto();
    }

    public Task<bool> ExistsAsync(long id)
    {
        return _locationRepository.ExistsUserLocation(_userService.GetUserId(), id);
    }
}
