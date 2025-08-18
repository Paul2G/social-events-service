using social_events_manager.Modules.SocialEvents.DTOs;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.Locations.DTOs;

public class ReadLocationDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Phone { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Address { get; set; }
    public List<SocialEvent> SocialEvents { get; set; } = [];
}
