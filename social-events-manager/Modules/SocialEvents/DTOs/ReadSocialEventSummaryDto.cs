namespace social_events_manager.Modules.SocialEvents.DTOs;

public class ReadSocialEventSummaryDto
{
    public long Id { get; init; }
    public string Name { get; set; }
    public string? Description { get; set; }
}
