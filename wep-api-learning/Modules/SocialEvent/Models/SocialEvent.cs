namespace wep_api_learning.Modules.SocialEvent.Models;

public class SocialEvent
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<Attendee.Models.Attendee> Attendees { get; } = new();
}
