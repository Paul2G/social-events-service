using web_api_learning.Modules.Attendees;
using web_api_learning.Modules.SocialEvents.DTOs;
using web_api_learning.Modules.SocialEvents.Models;

namespace web_api_learning.Modules.SocialEvents;

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
            Attendees = socialEventModel.Attendees.Select(c => c.ToAttendeeDto()).ToList()
        };
    }

    public static SocialEvent ToSocialEvent(
        this CreateSocialEventDto createSocialEventDto
    )
    {
        return new SocialEvent
        {
            Name = createSocialEventDto.Name,
            LocationId = createSocialEventDto.LocationId,
            Description = createSocialEventDto.Description,
            StartTime = createSocialEventDto.StartTime,
            EndTime = createSocialEventDto.EndTime,
            CreatedAt = DateTime.Now
        };
    }

    public static void ParseFromUpdateSocialEventDto(this SocialEvent socialEvent,
        UpdateSocialEventDto updateSocialEventDto)
    {
        socialEvent.Name = updateSocialEventDto.Name;
        socialEvent.Description = updateSocialEventDto.Description;
        socialEvent.LocationId = updateSocialEventDto.LocationId;
        socialEvent.StartTime = updateSocialEventDto.StartTime;
        socialEvent.EndTime = updateSocialEventDto.EndTime;
    }
}