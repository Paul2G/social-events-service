using social_events_manager.Modules.Shared.DTOs;
using social_events_manager.Modules.Shared.Models;

namespace social_events_manager.Modules.Shared;

public static class PaginationMapper
{
    public static PaginationQuery ToPaginationQuery(this PaginationQueryDto paginationQueryDto)
    {
        return new PaginationQuery
        {
            Limit = paginationQueryDto.PageSize ?? 10,
            Offset = ((paginationQueryDto.Page ?? 1) - 1) * (paginationQueryDto.PageSize ?? 10),
        };
    }
}
