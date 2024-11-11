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
            CreatedAt = DateTime.Now,
        };
    }

    public static SocialEvent ToSocialEventToUpdateDto(
        this UpdateSocialEventDto updateSocialEventDto
    )
    {
        return new SocialEvent
        {
            Name = updateSocialEventDto.Name,
            Location = updateSocialEventDto.Location,
            Description = updateSocialEventDto.Description,
            StartTime = updateSocialEventDto.StartTime,
            EndTime = updateSocialEventDto.EndTime,
        };
    }
}
