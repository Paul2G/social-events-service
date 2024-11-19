using web_api_learning.Modules.Attendees.Mappers;
using web_api_learning.Modules.SocialEvents.DTOs;
using web_api_learning.Modules.SocialEvents.Models;

namespace web_api_learning.Modules.SocialEvents.Mappers;

public static class SocialEventMappers
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

    public static SocialEvent ToSocialEventFromCreateDto(
        this CreateSocialEventDto createSocialEventDto
    )
    {
        return new SocialEvent
        {
            Name = createSocialEventDto.Name,
            Location = createSocialEventDto.Location,
            Description = createSocialEventDto.Description,
            StartTime = createSocialEventDto.StartTime,
            EndTime = createSocialEventDto.EndTime,
            CreatedAt = DateTime.Now
        };
    }
}