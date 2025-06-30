namespace social_events_manager.Modules.Shared.DTOs;

public class PaginatedListDto<T>(List<T> items, int page, int pageSize, int total)
{
    public List<T> Items { get; set; } = items;
    public PaginatedListMetadata Meta = new(page, pageSize, total);
}

public class PaginatedListMetadata(int page, int pageSize, int total)
{
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
    public int Total { get; set; } = total;
}
