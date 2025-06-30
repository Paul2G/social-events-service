namespace social_events_manager.Modules.Shared.Models;

public class PaginationQuery
{
    public int Limit { get; set; }
    public int Offset { get; set; }

    public int PageSize => Limit;
    public int Page => (Offset / Limit) + 1;
}
