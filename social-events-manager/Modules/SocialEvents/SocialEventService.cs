using social_events_manager.Modules.Auth.Interfaces;
using social_events_manager.Modules.SocialEvents.DTOs;
using social_events_manager.Modules.SocialEvents.Interfaces;

namespace social_events_manager.Modules.SocialEvents;

public class SocialEventService(
    ISocialEventRepository socialEventRepository,
    IUserService userService
) : ISocialEventService
{
    public async Task<List<ReadSocialEventDto>> GetAllAsync()
    {
        var socialEvents = await socialEventRepository.FindUserSocialEvents(
            userService.GetUserId()
        );

        return socialEvents.Select(s => s.ToSocialEventDto()).ToList();
    }

    public async Task<ReadSocialEventDto?> GetByIdAsync(long id)
    {
        var socialEvent = await socialEventRepository.FindUserSocialEventById(
            userService.GetUserId(),
            id
        );
        return socialEvent.ToSocialEventDto();
    }

    public async Task<ReadSocialEventDto> CreateAsync(CreateSocialEventDto socialEventDto)
    {
        var incomingSocialEvent = socialEventDto.ToSocialEvent();

        var socialEvent = await socialEventRepository.SaveUserSocialEvent(
            userService.GetUserId(),
            incomingSocialEvent
        );

        return socialEvent.ToSocialEventDto();
    }

    public async Task<ReadSocialEventDto?> UpdateAsync(long id, UpdateSocialEventDto socialEventDto)
    {
        var incomingSocialEvent = socialEventDto.ToSocialEvent();
        incomingSocialEvent.Id = id;

        var socialEvent = await socialEventRepository.UpdateUserSocialEvent(
            userService.GetUserId(),
            incomingSocialEvent
        );

        return socialEvent.ToSocialEventDto();
    }

    public async Task<ReadSocialEventDto?> DeleteAsync(long id)
    {
        var socialEvent = await socialEventRepository.FindUserSocialEventById(
            userService.GetUserId(),
            id
        );

        return socialEvent.ToSocialEventDto();
    }
}
