using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using social_events_manager.Modules.Auth.Models;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.Attendees.Models;

[Table("Attendees")]
public class Attendee
{
    public enum AttendanceStatus
    {
        Confirmed,
        Pending,
        Declined,
    }

    [Required]
    public long Id { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public AttendanceStatus Status { get; set; } = AttendanceStatus.Pending;

    [Required]
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    [Required]
    public long SocialEventId { get; set; }

    [Required]
    public string AppUserId { get; set; } = string.Empty;

    // Navigation properties
    public SocialEvent SocialEvent { get; set; }
    public AppUser AppUser { get; set; }
}
