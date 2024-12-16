using social_events_manager.Modules.Attendees.DTOs;
using social_events_manager.Modules.Locations.Models;

namespace social_events_manager.Modules.SocialEvents.DTOs;

public class ReadSocialEventDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Location Location { get; set; } = new();
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int AttendeesCount { get; set; }

    public List<ReadAttendeeDto> Attendees { get; set; } = [];
}