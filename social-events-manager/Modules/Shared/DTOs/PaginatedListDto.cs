namespace social_events_manager.Modules.Shared.DTOs;

public class PaginatedListDto<T>(List<T> items, int page, int limit, int total)
{
    public List<T> Data { get; set; } = items;
    public PaginatedListMetadata Meta = new(page, limit, total);
}

public class PaginatedListMetadata(int page, int limit, int total)
{
    public int Page { get; set; } = page;
    public int Limit { get; set; } = limit;
    public int Total { get; set; } = total;
}