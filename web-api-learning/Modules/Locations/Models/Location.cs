using System.ComponentModel.DataAnnotations.Schema;
using web_api_learning.Modules.SocialEvents.Models;

namespace web_api_learning.Modules.Locations.Models;

[Table("Locations")]
public class Location
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public int PostalCode { get; set; }
    public string Address { get; set; } = string.Empty;
    public string AppUserId { get; set; } = string.Empty;

    // Navigation

    public List<SocialEvent> SocialEvents { get; set; } = new();
}