using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.Locations.DTOs;

public class CreateLocationDto
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
    [RegularExpression(@"^\d{5}$", ErrorMessage = "Postal code must be exactly 5 digits.")]
    public string PostalCode { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string Address { get; set; } = string.Empty;
}
