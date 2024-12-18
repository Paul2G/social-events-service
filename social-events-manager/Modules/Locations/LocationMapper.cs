using social_events_manager.Modules.Locations.DTOs;
using social_events_manager.Modules.Locations.Models;

namespace social_events_manager.Modules.Locations;

public static class LocationMapper
{
    public static ReadLocationDto ToLocationDto(this Location location)
    {
        return new ReadLocationDto
        {
            Id = location.Id,
            Name = location.Name,
            Phone = location.Phone,
            Country = location.Country,
            PostalCode = location.PostalCode,
            Address = location.Address
        };
    }

    public static Location ToLocation(this CreateLocationDto createLocationDto, string appUserId)
    {
        return new Location
        {
            Name = createLocationDto.Name,
            Phone = createLocationDto.Phone,
            Country = createLocationDto.Country,
            PostalCode = createLocationDto.PostalCode,
            Address = createLocationDto.Address,
            AppUserId = appUserId
        };
    }

    public static void ParseFromUpdateLocationDto(this Location location, UpdateLocationDto updateLocationDto)
    {
        location.Name = updateLocationDto.Name;
        location.Phone = updateLocationDto.Phone;
        location.Country = updateLocationDto.Country;
        location.PostalCode = updateLocationDto.PostalCode;
        location.Address = updateLocationDto.Address;
    }
}