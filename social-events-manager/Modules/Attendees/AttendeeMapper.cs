using social_events_manager.Modules.Attendees.DTOs;
using social_events_manager.Modules.Attendees.Models;
using social_events_manager.Modules.SocialEvents;

namespace social_events_manager.Modules.Attendees;

public static class AttendeeMapper
{
    public static ReadAttendeeDto ToAttendeeDto(this Attendee attendeeModel)
    {
        return new ReadAttendeeDto
        {
            Id = attendeeModel.Id,
            Name = attendeeModel.Name,
            RegisteredAt = attendeeModel.RegisteredAt.ToUniversalTime(),
            Status = attendeeModel.Status.ToString(),
            SocialEvent = attendeeModel.SocialEvent.ToSocialEventSummaryDto(),
        };
    }

    public static ReadAttendeeSummaryDto ToAttendeeSummaryDto(this Attendee attendeeModel)
    {
        return new ReadAttendeeSummaryDto
        {
            Id = attendeeModel.Id,
            Name = attendeeModel.Name,
            Status = attendeeModel.Status.ToString(),
            SocialEventId = attendeeModel.SocialEventId,
        };
    }

    public static Attendee ToAttendee(this CreateAttendeeDto attendeeDto)
    {
        return new Attendee
        {
            Name = attendeeDto.Name,
            Status = Enum.TryParse(attendeeDto.Status, true, out Attendee.AttendanceStatus status)
                ? status
                : Attendee.AttendanceStatus.Pending,
            SocialEventId = attendeeDto.SocialEventId,
        };
    }

    public static Attendee ToAttendee(this UpdateAttendeeDto attendeeDto)
    {
        return new Attendee
        {
            Name = attendeeDto.Name,
            Status = Enum.TryParse(attendeeDto.Status, true, out Attendee.AttendanceStatus status)
                ? status
                : Attendee.AttendanceStatus.Pending,
            SocialEventId = attendeeDto.SocialEventId,
        };
    }
}
