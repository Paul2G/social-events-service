using social_events_manager.Modules.Attendees.DTOs;
using social_events_manager.Modules.Locations.DTOs;
using social_events_manager.Modules.Locations.Models;

namespace social_events_manager.Modules.SocialEvents.DTOs;

public class ReadSocialEventDto
{
    public long Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ReadLocationSummaryDto? Location { get; set; }
    public List<ReadAttendeeSummaryDto> Attendees { get; set; } = [];
}
