using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using social_events_manager.Modules.Auth.Models;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.Locations.Models;

[Table("Locations")]
public class Location
{
    [Required]
    public long Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(15)]
    public string? Phone { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Country { get; set; } = string.Empty;

    [Required]
    [Length(5, 5)]
    public string PostalCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string Address { get; set; } = string.Empty;

    [Required]
    public string AppUserId { get; set; } = string.Empty;

    // Navigation
    public List<SocialEvent> SocialEvents { get; } = [];
    public AppUser AppUser { get; set; }
}
