using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.SocialEvents.DTOs;

public class UpdateSocialEventDto
{
    [Required]
    [MinLength(6, ErrorMessage = "Name have to be 6 characters length")]
    [MaxLength(255, ErrorMessage = "Name cannot be over 255 characters")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(255, ErrorMessage = "Description cannot be over 255 characters")]
    public string? Description { get; set; }

    public long? LocationId { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; set; }
}