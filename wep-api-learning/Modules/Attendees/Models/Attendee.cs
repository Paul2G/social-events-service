using wep_api_learning.Modules.SocialEvents.Models;

namespace wep_api_learning.Modules.Attendees.Models;

public class Attendee
{
    public enum AttendanceStatus
    {
        Confirmed,
        Pending,
        Declined,
    }

    public long Id { get; set; }
    public long? EventId { get; set; }
    public SocialEvent? SocialEvent { get; set; }
    public AttendanceStatus Status { get; set; } = AttendanceStatus.Pending;
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
}
