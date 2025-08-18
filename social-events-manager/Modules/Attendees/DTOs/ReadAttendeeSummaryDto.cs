namespace social_events_manager.Modules.Attendees.DTOs;

public class ReadAttendeeSummaryDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public long SocialEventId { get; set; }
}
