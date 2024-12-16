using social_events_manager.Modules.Attendees.Models;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.Attendees.DTOs;

public class ReadAttendeeDto
{
    public string? Name { get; set; } = string.Empty;
    public long Id { get; set; }
    public Attendee.AttendanceStatus Status { get; set; } = Attendee.AttendanceStatus.Pending;
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    public SocialEvent SocialEvent { get; set; } = new();
}