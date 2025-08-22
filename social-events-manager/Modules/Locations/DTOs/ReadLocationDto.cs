using social_events_manager.Modules.SocialEvents.DTOs;

namespace social_events_manager.Modules.Locations.DTOs;

public class ReadLocationDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Phone { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Address { get; set; }
    public List<ReadSocialEventSummaryDto> SocialEvents { get; set; } = [];
}
