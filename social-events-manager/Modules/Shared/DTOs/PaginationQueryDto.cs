using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace social_events_manager.Modules.Shared.DTOs;

public class PaginationQueryDto
{
    [Range(1, int.MaxValue)]
    [FromQuery(Name = "page_size")]
    public int? PageSize { get; set; }

    [Range(1, int.MaxValue)]
    [FromQuery(Name = "page")]
    public int? Page { get; set; }
}
