using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using social_events_manager.Modules.Attendees.Models;
using social_events_manager.Modules.Locations.Models;

namespace social_events_manager.Modules.SocialEvents.Models;

[Table("SocialEvents")]
public class SocialEvent
{
    [Required]
    public long Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? Description { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    public long? LocationId { get; set; }

    // Auto generated properties
    [Required]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    [MaxLength(255)]
    public string AppUserId { get; set; } = string.Empty;

    // Navigation properties
    public Location? Location { get; init; }
    public List<Attendee> Attendees { get; } = [];
}
