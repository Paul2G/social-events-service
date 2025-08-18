using social_events_manager.Modules.Attendees;
using social_events_manager.Modules.Attendees.Models;
using social_events_manager.Modules.Locations;
using social_events_manager.Modules.SocialEvents.DTOs;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.SocialEvents;

public static class SocialEventMapper
{
    public static ReadSocialEventDto ToSocialEventDto(this SocialEvent socialEventModel)
    {
        return new ReadSocialEventDto
        {
            Id = socialEventModel.Id,
            Name = socialEventModel.Name,
            Description = socialEventModel.Description,
            StartTime = socialEventModel.StartTime.ToUniversalTime(),
            EndTime = socialEventModel.EndTime.ToUniversalTime(),
            CreatedAt = socialEventModel.CreatedAt.ToUniversalTime(),
            Location = socialEventModel.Location?.ToLocationSummaryDto(),
            Attendees = socialEventModel.Attendees.Select(c => c.ToAttendeeDto()).ToList(),
        };
    }

    public static ReadSocialEventSummaryDto ToSocialEventSummaryDto(
        this SocialEvent socialEventModel
    )
    {
        return new ReadSocialEventSummaryDto
        {
            Id = socialEventModel.Id,
            Name = socialEventModel.Name,
            Description = socialEventModel.Description,
        };
    }

    public static SocialEvent ToSocialEvent(this CreateSocialEventDto createSocialEventDto)
    {
        return new SocialEvent
        {
            Name = createSocialEventDto.Name,
            Description = createSocialEventDto.Description,
            StartTime = createSocialEventDto.StartTime,
            EndTime = createSocialEventDto.EndTime,
            LocationId = createSocialEventDto.LocationId,
            CreatedAt = DateTime.UtcNow,
        };
    }

    public static SocialEvent ToSocialEvent(this UpdateSocialEventDto updateSocialEventDto)
    {
        return new SocialEvent
        {
            Name = updateSocialEventDto.Name,
            Description = updateSocialEventDto.Description,
            StartTime = updateSocialEventDto.StartTime,
            EndTime = updateSocialEventDto.EndTime,
            LocationId = updateSocialEventDto.LocationId,
        };
    }
}
