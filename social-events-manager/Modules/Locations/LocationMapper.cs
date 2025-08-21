using social_events_manager.Modules.Locations.DTOs;
using social_events_manager.Modules.Locations.Models;
using social_events_manager.Modules.SocialEvents;

namespace social_events_manager.Modules.Locations;

public static class LocationMapper
{
    public static ReadLocationDto ToLocationDto(this Location locationModel)
    {
        return new ReadLocationDto
        {
            Id = locationModel.Id,
            Name = locationModel.Name,
            Phone = locationModel.Phone,
            Country = locationModel.Country,
            PostalCode = locationModel.PostalCode,
            Address = locationModel.Address,
            SocialEvents = locationModel.SocialEvents,
        };
    }

    public static ReadLocationSummaryDto ToLocationSummaryDto(this Location locationModel)
    {
        return new ReadLocationSummaryDto
        {
            Id = locationModel.Id,
            Name = locationModel.Name,
            Phone = locationModel.Phone,
            Country = locationModel.Country,
            PostalCode = locationModel.PostalCode,
            Address = locationModel.Address,
        };
    }

    public static Location ToLocation(this CreateLocationDto createLocationDto)
    {
        return new Location
        {
            Name = createLocationDto.Name,
            Phone = createLocationDto.Phone,
            Country = createLocationDto.Country,
            PostalCode = createLocationDto.PostalCode,
            Address = createLocationDto.Address,
        };
    }

    public static Location ToLocation(this UpdateLocationDto updateLocationDto)
    {
        return new Location
        {
            Name = updateLocationDto.Name,
            Phone = updateLocationDto.Phone,
            Country = updateLocationDto.Country,
            PostalCode = updateLocationDto.PostalCode,
            Address = updateLocationDto.Address,
        };
    }
}
