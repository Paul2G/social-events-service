using social_events_manager.Modules.Attendees.DTOs;
using social_events_manager.Modules.Attendees.Models;

namespace social_events_manager.Modules.Attendees;

public static class AttendeeMapper
{
    public static ReadAttendeeDto ToAttendeeDto(this Attendee attendee)
    {
        return new ReadAttendeeDto
        {
            Id = attendee.Id,
            Name = attendee.Name,
            RegisteredAt = attendee.RegisteredAt,
            Status = attendee.Status,
        };
    }

    public static Attendee ToAttendee(this CreateAttendeeDto attendeeDto)
    {
        return new Attendee { Name = attendeeDto.Name };
    }

    public static Attendee ToAttendee(this UpdateAttendeeDto attendeeDto)
    {
        return new Attendee { Name = attendeeDto.Name, Status = attendeeDto.Status };
    }
}
