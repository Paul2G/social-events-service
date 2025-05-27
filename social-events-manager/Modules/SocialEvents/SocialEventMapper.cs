using social_events_manager.Modules.Attendees;
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
            Location = socialEventModel.Location,
            StartTime = socialEventModel.StartTime,
            EndTime = socialEventModel.EndTime,
            CreatedAt = socialEventModel.CreatedAt,
            AttendeesCount = socialEventModel.Attendees.Count,
            Attendees = socialEventModel.Attendees.Select(c => c.ToAttendeeDto()).ToList(),
        };
    }

    public static SocialEvent ToSocialEvent(this CreateSocialEventDto createSocialEventDto)
    {
        return new SocialEvent
        {
            Name = createSocialEventDto.Name,
            LocationId = createSocialEventDto.LocationId,
            Description = createSocialEventDto.Description,
            StartTime = createSocialEventDto.StartTime,
            EndTime = createSocialEventDto.EndTime,
            CreatedAt = DateTime.Now,
        };
    }

    public static SocialEvent ToSocialEvent(this UpdateSocialEventDto updateSocialEventDto)
    {
        return new SocialEvent
        {
            Name = updateSocialEventDto.Name,
            LocationId = updateSocialEventDto.LocationId,
            Description = updateSocialEventDto.Description,
            StartTime = updateSocialEventDto.StartTime,
            EndTime = updateSocialEventDto.EndTime,
        };
    }

    public static void ParseFromUpdateSocialEventDto(
        this SocialEvent socialEvent,
        UpdateSocialEventDto updateSocialEventDto
    )
    {
        socialEvent.Name = updateSocialEventDto.Name;
        socialEvent.Description = updateSocialEventDto.Description;
        socialEvent.LocationId = updateSocialEventDto.LocationId;
        socialEvent.StartTime = updateSocialEventDto.StartTime;
        socialEvent.EndTime = updateSocialEventDto.EndTime;
    }
}
