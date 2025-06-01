namespace social_events_manager.Modules.Locations.DTOs;

public class ReadLocationDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string Country { get; set; } = string.Empty;
    public int PostalCode { get; set; }
    public string Address { get; set; } = string.Empty;
}
