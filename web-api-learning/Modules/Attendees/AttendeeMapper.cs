using web_api_learning.Modules.Attendees.DTOs;
using web_api_learning.Modules.Attendees.Models;

namespace web_api_learning.Modules.Attendees;

public static class AttendeeMapper
{
    public static ReadAttendeeDto ToAttendeeDto(this Attendee attendee)
    {
        return new ReadAttendeeDto
        {
            Id = attendee.Id,
            Name = attendee.Name,
            RegisteredAt = attendee.RegisteredAt,
            Status = attendee.Status
        };
    }

    public static Attendee ToAttendee(this CreateAttendeeDto attendeeDto, string appUserId)
    {
        return new Attendee
        {
            Name = attendeeDto.Name,
            AppUserId = appUserId
        };
    }

    public static void ParseFromUpdateAttendeeDto(this Attendee attendee, UpdateAttendeeDto updateAttendeeDto)
    {
        attendee.Name = updateAttendeeDto.Name;
        attendee.Status = updateAttendeeDto.Status;
    }
}