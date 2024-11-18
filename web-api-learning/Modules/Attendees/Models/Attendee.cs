using web_api_learning.Modules.SocialEvents.Models;

namespace web_api_learning.Modules.Attendees.Models;

public class Attendee
{
    public enum AttendanceStatus
    {
        Confirmed,
        Pending,
        Declined
    }

    public string Name = string.Empty;
    public long Id { get; set; }
    public AttendanceStatus Status { get; set; } = AttendanceStatus.Pending;
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    public long? EventId { get; set; }
    public SocialEvent? SocialEvent { get; set; }
}