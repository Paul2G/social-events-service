using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.Locations.DTOs;

public class UpdateLocationDto
{
    [Required]
    [MaxLength(255, ErrorMessage = "Name cannot be over 255 characters")]
    public string Name { get; set; } = string.Empty;

    [Phone]
    [MaxLength(15, ErrorMessage = "Phone number cannot be over 15 characters")]
    public string? Phone { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "Country cannot be over 50 characters")]
    public string Country { get; set; } = string.Empty;

    [Required]
    public int PostalCode { get; set; }

    [Required]
    [MaxLength(255, ErrorMessage = "Address cannot be over 255 characters")]
    public string Address { get; set; } = string.Empty;
}
