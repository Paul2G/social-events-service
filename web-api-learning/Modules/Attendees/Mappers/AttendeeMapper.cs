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
            SocialEventId = attendee.SocialEventId
        };
    }
}