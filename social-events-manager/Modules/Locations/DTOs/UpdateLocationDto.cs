using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.Locations.DTOs;

public class UpdateLocationDto
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;

    [Phone]
    [StringLength(15)]
    public string? Phone { get; set; }

    [Required]
    [StringLength(50)]
    public string Country { get; set; } = string.Empty;

    [Required]
    public int PostalCode { get; set; }

    [Required]
    [StringLength(255)]
    public string Address { get; set; } = string.Empty;
}
