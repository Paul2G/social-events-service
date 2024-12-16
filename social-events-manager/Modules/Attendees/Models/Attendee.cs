using System.ComponentModel.DataAnnotations.Schema;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.Attendees.Models;

[Table("Attendees")]
public class Attendee
{
    public enum AttendanceStatus
    {
        Confirmed,
        Pending,
        Declined
    }

    public string? Name { get; set; } = string.Empty;

    public long Id { get; set; }
    public AttendanceStatus Status { get; set; } = AttendanceStatus.Pending;
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    public string AppUserId { get; set; } = string.Empty;

    // Navigation
    public List<SocialEvent> SocialEvents { get; set; } = [];
}