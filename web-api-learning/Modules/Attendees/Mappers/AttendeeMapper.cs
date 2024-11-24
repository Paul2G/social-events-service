using web_api_learning.Modules.Attendees.DTOs;
using web_api_learning.Modules.Attendees.Models;

namespace web_api_learning.Modules.Attendees.Mappers;

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
            SocialEvent = attendee.SocialEvent
        };
    }

    public static Attendee ToAttendeeFromCreateDto(this CreateAttendeeDto attendeeDto)
    {
        return new Attendee
        {
            Name = attendeeDto.Name,
            SocialEventId = attendeeDto.SocialEventId
        };
    }
}