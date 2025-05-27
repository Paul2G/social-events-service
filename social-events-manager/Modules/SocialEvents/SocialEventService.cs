using social_events_manager.Modules.Auth.Interfaces;
using social_events_manager.Modules.SocialEvents.DTOs;
using social_events_manager.Modules.SocialEvents.Interfaces;

namespace social_events_manager.Modules.SocialEvents;

public class SocialEventService : ISocialEventService
{
    private readonly ISocialEventRepository _socialEventRepository;
    private readonly IUserService _userService;

    public SocialEventService(
        ISocialEventRepository socialEventRepository,
        IUserService userService
    )
    {
        _socialEventRepository = socialEventRepository;
        _userService = userService;
    }

    public async Task<List<ReadSocialEventDto>> GetAllAsync()
    {
        var existingSocialEvents = await _socialEventRepository.FindUserSocialEvents(
            _userService.GetUserId()
        );

        return (List<ReadSocialEventDto>)existingSocialEvents.Select(s => s.ToSocialEventDto());
    }

    public async Task<ReadSocialEventDto?> GetByIdAsync(long id)
    {
        var existingSocialEvent = await _socialEventRepository.FindUserSocialEventById(
            _userService.GetUserId(),
            id
        );
        return existingSocialEvent.ToSocialEventDto();
    }

    public async Task<ReadSocialEventDto> CreateAsync(CreateSocialEventDto socialEventDto)
    {
        var incomingSocialEvent = socialEventDto.ToSocialEvent();

        var socialEventModel = await _socialEventRepository.SaveUserSocialEvent(
            _userService.GetUserId(),
            incomingSocialEvent
        );

        return socialEventModel.ToSocialEventDto();
    }

    public async Task<ReadSocialEventDto?> UpdateAsync(long id, UpdateSocialEventDto socialEventDto)
    {
        var incomingSocialEvent = socialEventDto.ToSocialEvent();
        incomingSocialEvent.Id = id;

        var socialEventModel = await _socialEventRepository.UpdateUserSocialEvent(
            _userService.GetUserId(),
            incomingSocialEvent
        );

        return socialEventModel.ToSocialEventDto();
    }

    public async Task<ReadSocialEventDto?> DeleteAsync(long id)
    {
        var existingSocialEvent = await _socialEventRepository.FindUserSocialEventById(
            _userService.GetUserId(),
            id
        );

        return existingSocialEvent.ToSocialEventDto();
    }

    public async Task<bool> ExitsAsync(long id)
    {
        return await _socialEventRepository.ExitsUserSocialEvent(_userService.GetUserId(), id);
    }
}
