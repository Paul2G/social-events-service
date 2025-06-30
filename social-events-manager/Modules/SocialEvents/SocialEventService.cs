using social_events_manager.Exceptions;
using social_events_manager.Modules.Auth.Interfaces;
using social_events_manager.Modules.Locations.Interfaces;
using social_events_manager.Modules.Shared;
using social_events_manager.Modules.Shared.DTOs;
using social_events_manager.Modules.SocialEvents.DTOs;
using social_events_manager.Modules.SocialEvents.Interfaces;

namespace social_events_manager.Modules.SocialEvents;

public class SocialEventService(
    ISocialEventRepository socialEventRepository,
    ILocationRepository locationRepository,
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

    public async Task<PaginatedListDto<ReadSocialEventDto>> GetAllPaginatedAsync(
        PaginationQueryDto paginationQueryDto
    )
    {
        var paginationQuery = paginationQueryDto.ToPaginationQuery();

        var socialEvents = await socialEventRepository.FindUserSocialEventsPaginated(
            userService.GetUserId(),
            paginationQuery.Limit,
            paginationQuery.Offset
        );

        var totalCount = await socialEventRepository.CountUserSocialEvents(userService.GetUserId());

        return new PaginatedListDto<ReadSocialEventDto>(
            socialEvents.Select(s => s.ToSocialEventDto()).ToList(),
            paginationQuery.Page,
            paginationQuery.PageSize,
            totalCount
        );
    }

    public async Task<ReadSocialEventDto> GetByIdAsync(long id)
    {
        var socialEvent = await socialEventRepository.FindUserSocialEventById(
            userService.GetUserId(),
            id
        );

        if (socialEvent == null)
            throw new ItemNotFoundException($"Social event with ID {id} not found.");

        return socialEvent.ToSocialEventDto();
    }

    public async Task<ReadSocialEventDto> CreateAsync(CreateSocialEventDto socialEventDto)
    {
        if (socialEventDto.LocationId != null)
        {
            bool exitsLocation = await locationRepository.ExistsUserLocation(
                userService.GetUserId(),
                socialEventDto.LocationId.Value
            );
            if (!exitsLocation)
                throw new InvalidInputException(
                    $"Location with ID {socialEventDto.LocationId} does not exist."
                );
        }

        var incomingSocialEvent = socialEventDto.ToSocialEvent();

        var socialEvent = await socialEventRepository.SaveUserSocialEvent(
            userService.GetUserId(),
            incomingSocialEvent
        );

        return socialEvent.ToSocialEventDto();
    }

    public async Task<ReadSocialEventDto> UpdateAsync(long id, UpdateSocialEventDto socialEventDto)
    {
        if (socialEventDto.LocationId != null)
        {
            bool exitsLocation = await locationRepository.ExistsUserLocation(
                userService.GetUserId(),
                socialEventDto.LocationId.Value
            );
            if (!exitsLocation)
                throw new InvalidInputException(
                    $"Location with ID {socialEventDto.LocationId} does not."
                );
        }

        var incomingSocialEvent = socialEventDto.ToSocialEvent();
        incomingSocialEvent.Id = id;

        var socialEvent = await socialEventRepository.UpdateUserSocialEvent(
            userService.GetUserId(),
            incomingSocialEvent
        );

        if (socialEvent == null)
            throw new ItemNotFoundException($"Social event with ID {id} not found.");

        return socialEvent.ToSocialEventDto();
    }

    public async Task<ReadSocialEventDto> DeleteAsync(long id)
    {
        var socialEvent = await socialEventRepository.DeleteUserSocialEvent(
            userService.GetUserId(),
            id
        );

        if (socialEvent == null)
            throw new ItemNotFoundException($"Social event with ID {id} not found.");

        return socialEvent.ToSocialEventDto();
    }
}
