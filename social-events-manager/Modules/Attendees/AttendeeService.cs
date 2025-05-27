using social_events_manager.Modules.Attendees.DTOs;
using social_events_manager.Modules.Attendees.Interfaces;
using social_events_manager.Modules.Auth.Interfaces;

namespace social_events_manager.Modules.Attendees;

public class AttendeeService : IAttendeeService
{
    private readonly IAttendeeRepository _attendeeRepository;
    private readonly IUserService _userService;

    public AttendeeService(IAttendeeRepository attendeeRepository, IUserService userService)
    {
        _attendeeRepository = attendeeRepository;
        _userService = userService;
    }

    public async Task<List<ReadAttendeeDto>> GetAllAsync()
    {
        var attendees = await _attendeeRepository.FindUserAttendees(_userService.GetUserId());

        return (List<ReadAttendeeDto>)attendees.Select(a => a.ToAttendeeDto());
    }

    public async Task<ReadAttendeeDto?> GetByIdAsync(long id)
    {
        var attendee = await _attendeeRepository.FindUserAttendeeById(_userService.GetUserId(), id);

        return attendee.ToAttendeeDto();
    }

    public async Task<ReadAttendeeDto> CreateAsync(CreateAttendeeDto attendeeDto)
    {
        var incomingAttendee = attendeeDto.ToAttendee();

        var attendee = await _attendeeRepository.SaveUserAttendee(
            _userService.GetUserId(),
            incomingAttendee
        );

        return attendee.ToAttendeeDto();
    }

    public async Task<ReadAttendeeDto?> UpdateAsync(long id, UpdateAttendeeDto attendeeDto)
    {
        var incomingAttendee = attendeeDto.ToAttendee();
        incomingAttendee.Id = id;

        var attendee = await _attendeeRepository.UpdateUserAttendee(
            _userService.GetUserId(),
            incomingAttendee
        );

        return attendee?.ToAttendeeDto();
    }

    public async Task<ReadAttendeeDto?> DeleteAsync(long id)
    {
        var attendee = await _attendeeRepository.DeleteUserAttendee(_userService.GetUserId(), id);

        return attendee?.ToAttendeeDto();
    }
}
