using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.Locations.DTOs;

public class UpdateLocationDto
{
    [Required] public string Name { get; set; } = string.Empty;

    [Phone] public string? Phone { get; set; }

    [Required] public string Country { get; set; } = string.Empty;

    [Required] public int PostalCode { get; set; }

    [Required] public string Address { get; set; } = string.Empty;
}