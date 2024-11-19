using web_api_learning.Modules.Attendees.Models;

namespace web_api_learning.Modules.Attendees.DTOs;

public class ReadAttendeeDto
{
    public string Name { get; set; } = string.Empty;
    public long Id { get; set; }
    public Attendee.AttendanceStatus Status { get; set; } = Attendee.AttendanceStatus.Pending;
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    public long? SocialEventId { get; set; }
}