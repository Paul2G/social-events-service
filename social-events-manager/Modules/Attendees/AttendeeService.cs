using social_events_manager.Exceptions;
using social_events_manager.Modules.Attendees.DTOs;
using social_events_manager.Modules.Attendees.Interfaces;
using social_events_manager.Modules.Auth.Interfaces;
using social_events_manager.Modules.Shared;
using social_events_manager.Modules.Shared.DTOs;

namespace social_events_manager.Modules.Attendees;

public class AttendeeService(IAttendeeRepository attendeeRepository, IUserService userService)
    : IAttendeeService
{
    public async Task<List<ReadAttendeeSummaryDto>> GetAllAsync()
    {
        var attendees = await attendeeRepository.FindAttendees();

        return attendees.Select(a => a.ToAttendeeSummaryDto()).ToList();
    }

    public async Task<PaginatedListDto<ReadAttendeeDto>> GetAllPaginatedAsync(
        PaginationQueryDto paginationQueryDto
    )
    {
        var paginationQuery = paginationQueryDto.ToPaginationQuery();

        var attendees = await attendeeRepository.FindAttendeesPaginated(
            paginationQuery.Limit,
            paginationQuery.Offset
        );

        var totalCount = await attendeeRepository.CountAttendees();

        return new PaginatedListDto<ReadAttendeeDto>(
            attendees.Select(a => a.ToAttendeeDto()).ToList(),
            paginationQuery.Page,
            paginationQuery.PageSize,
            totalCount
        );
    }

    public async Task<ReadAttendeeDto> GetByIdAsync(long id)
    {
        var attendee = await attendeeRepository.FindAttendeeById(id);

        if (attendee == null)
            throw new ItemNotFoundException($"Attendee with ID {id} not found.");

        return attendee.ToAttendeeDto();
    }

    public async Task<ReadAttendeeDto> CreateAsync(CreateAttendeeDto attendeeDto)
    {
        bool existsSocialEvent = await attendeeRepository.ExistsAttendee(attendeeDto.SocialEventId);

        if (!existsSocialEvent)
            throw new ItemNotFoundException(
                $"Social event with ID {attendeeDto.SocialEventId} not found."
            );

        var incomingAttendee = attendeeDto.ToAttendee();
        incomingAttendee.AppUserId = userService.GetUserId();

        var attendee = await attendeeRepository.SaveAttendee(incomingAttendee);

        return attendee.ToAttendeeDto();
    }

    public async Task<ReadAttendeeDto> UpdateAsync(long id, UpdateAttendeeDto attendeeDto)
    {
        bool existsSocialEvent = await attendeeRepository.ExistsAttendee(attendeeDto.SocialEventId);

        if (!existsSocialEvent)
            throw new ItemNotFoundException(
                $"Social event with ID {attendeeDto.SocialEventId} not found."
            );

        var incomingAttendee = attendeeDto.ToAttendee();
        incomingAttendee.Id = id;

        var attendee = await attendeeRepository.UpdateAttendee(incomingAttendee);

        if (attendee == null)
            throw new ItemNotFoundException($"Attendee with ID {id} not found.");

        return attendee.ToAttendeeDto();
    }

    public async Task<ReadAttendeeDto> DeleteAsync(long id)
    {
        var attendee = await attendeeRepository.DeleteAttendee(id);

        if (attendee == null)
            throw new ItemNotFoundException($"Attendee with ID {id} not found.");

        return attendee.ToAttendeeDto();
    }
}
