using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.SocialEvents.DTOs;

public class CreateSocialEventDto
{
    [Required]
    [StringLength(255, MinimumLength = 6)]
    public string Name { get; set; } = string.Empty;

    [StringLength(255)]
    public string? Description { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; set; }

    public long? LocationId { get; set; }
}
