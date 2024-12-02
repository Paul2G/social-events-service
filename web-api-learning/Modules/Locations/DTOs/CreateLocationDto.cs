using System.ComponentModel.DataAnnotations;

namespace web_api_learning.Modules.Locations.DTOs;

public class CreateLocationDto
{
    [Required] public string Name { get; set; } = string.Empty;

    [Phone] public string? Phone { get; set; }

    [Required] public string Country { get; set; } = string.Empty;

    [Required] public int PostalCode { get; set; }

    [Required] public string Address { get; set; } = string.Empty;
}