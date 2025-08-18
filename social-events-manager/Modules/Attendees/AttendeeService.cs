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
        var attendees = await attendeeRepository.FindUserAttendees(userService.GetUserId());

        return attendees.Select(a => a.ToAttendeeSummaryDto()).ToList();
    }

    public async Task<PaginatedListDto<ReadAttendeeDto>> GetAllPaginatedAsync(
        PaginationQueryDto paginationQueryDto
    )
    {
        var paginationQuery = paginationQueryDto.ToPaginationQuery();

        var attendees = await attendeeRepository.FindUserAttendeesPaginated(
            userService.GetUserId(),
            paginationQuery.Limit,
            paginationQuery.Offset
        );

        var totalCount = await attendeeRepository.CountUserAttendees(userService.GetUserId());

        return new PaginatedListDto<ReadAttendeeDto>(
            attendees.Select(a => a.ToAttendeeDto()).ToList(),
            paginationQuery.Page,
            paginationQuery.PageSize,
            totalCount
        );
    }

    public async Task<ReadAttendeeDto> GetByIdAsync(long id)
    {
        var attendee = await attendeeRepository.FindUserAttendeeById(userService.GetUserId(), id);

        if (attendee == null)
            throw new ItemNotFoundException($"Attendee with ID {id} not found.");

        return attendee.ToAttendeeDto();
    }

    public async Task<ReadAttendeeDto> CreateAsync(CreateAttendeeDto attendeeDto)
    {
        var incomingAttendee = attendeeDto.ToAttendee();

        var attendee = await attendeeRepository.SaveUserAttendee(
            userService.GetUserId(),
            incomingAttendee
        );

        return attendee.ToAttendeeDto();
    }

    public async Task<ReadAttendeeDto> UpdateAsync(long id, UpdateAttendeeDto attendeeDto)
    {
        var incomingAttendee = attendeeDto.ToAttendee();
        incomingAttendee.Id = id;

        var attendee = await attendeeRepository.UpdateUserAttendee(
            userService.GetUserId(),
            incomingAttendee
        );

        if (attendee == null)
            throw new ItemNotFoundException($"Attendee with ID {id} not found.");

        return attendee.ToAttendeeDto();
    }

    public async Task<ReadAttendeeDto> DeleteAsync(long id)
    {
        var attendee = await attendeeRepository.DeleteUserAttendee(userService.GetUserId(), id);

        if (attendee == null)
            throw new ItemNotFoundException($"Attendee with ID {id} not found.");

        return attendee.ToAttendeeDto();
    }
}
