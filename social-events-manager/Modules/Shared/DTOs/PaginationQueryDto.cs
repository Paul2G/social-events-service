using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.Shared.DTOs;

public class PaginationQueryDto
{
    [Range(1, int.MaxValue)]
    public int? PageSize { get; set; }

    [Range(1, int.MaxValue)]
    public int? Page { get; set; }
}
