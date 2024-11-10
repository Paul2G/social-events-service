using wep_api_learning.Dtos.SocialEvent;
using wep_api_learning.Models;

namespace wep_api_learning.Mappers;

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
            CreatedBy = socialEventModel.CreatedBy,
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
            CreatedBy = 1,
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
