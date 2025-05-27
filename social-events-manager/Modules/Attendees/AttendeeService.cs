using social_events_manager.Modules.Attendees.DTOs;
using social_events_manager.Modules.Attendees.Interfaces;
using social_events_manager.Modules.Auth.Interfaces;

namespace social_events_manager.Modules.Attendees;

public class AttendeeService(IAttendeeRepository attendeeRepository, IUserService userService)
    : IAttendeeService
{
    public async Task<List<ReadAttendeeDto>> GetAllAsync()
    {
        var attendees = await attendeeRepository.FindUserAttendees(userService.GetUserId());

        return (List<ReadAttendeeDto>)attendees.Select(a => a.ToAttendeeDto());
    }

    public async Task<ReadAttendeeDto?> GetByIdAsync(long id)
    {
        var attendee = await attendeeRepository.FindUserAttendeeById(userService.GetUserId(), id);

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

    public async Task<ReadAttendeeDto?> UpdateAsync(long id, UpdateAttendeeDto attendeeDto)
    {
        var incomingAttendee = attendeeDto.ToAttendee();
        incomingAttendee.Id = id;

        var attendee = await attendeeRepository.UpdateUserAttendee(
            userService.GetUserId(),
            incomingAttendee
        );

        return attendee?.ToAttendeeDto();
    }

    public async Task<ReadAttendeeDto?> DeleteAsync(long id)
    {
        var attendee = await attendeeRepository.DeleteUserAttendee(userService.GetUserId(), id);

        return attendee?.ToAttendeeDto();
    }
}
