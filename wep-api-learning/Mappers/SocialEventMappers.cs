using wep_api_learning.Dtos.SocialEvent;
using wep_api_learning.Models;

namespace wep_api_learning.Mappers;

public static class SocialEventMappers
{
    public static SocialEventDto ToSocialEventDto(this SocialEvent socialEventModel)
    {
        return new SocialEventDto
        {
            Id = socialEventModel.Id,
            Name = socialEventModel.Name,
            Description = socialEventModel.Description,
            Location = socialEventModel.Location,
            StartTime = socialEventModel.StartTime,
            EndTime = socialEventModel.EndTime,
            CreatedAt = socialEventModel.CreatedAt,
            CreatedBy = socialEventModel.CreatedBy,
            AttendeesCount = socialEventModel.Attendees.Count,
        };
    }

    public static SocialEvent ToSocialEventFromCreateDto(
        this CreateSocialEventRequestDto createSocialEventRequestDto
    )
    {
        return new SocialEvent
        {
            Name = createSocialEventRequestDto.Name,
            Location = createSocialEventRequestDto.Location,
            Description = createSocialEventRequestDto.Description,
            StartTime = createSocialEventRequestDto.StartTime,
            EndTime = createSocialEventRequestDto.EndTime,
            CreatedAt = DateTime.Now,
            CreatedBy = 1,
        };
    }
}
