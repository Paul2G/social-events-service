using System.ComponentModel.DataAnnotations.Schema;
using social_events_manager.Modules.Attendees.Models;
using social_events_manager.Modules.Locations.Models;

namespace social_events_manager.Modules.SocialEvents.Models;

[Table("SocialEvents")]
public class SocialEvent
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public long? LocationId { get; set; }
    public string AppUserId { get; set; } = string.Empty;

    // Navigation
    public Location? Location { get; set; }
    public List<Attendee> Attendees { get; } = [];
}