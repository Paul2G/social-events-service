using System.ComponentModel.DataAnnotations;
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
    [MaxLength(255, ErrorMessage = "Name cannot be over 255 characters")]
    public string AppUserId { get; set; } = string.Empty;

    // Navigation
    public List<SocialEvent> SocialEvents { get; } = [];
}
