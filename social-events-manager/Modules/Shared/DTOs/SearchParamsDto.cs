namespace social_events_manager.Modules.Shared.DTOs;

public class SearchParamsDto
{
    public int Limit { get; set; } = 10;
    public int Page { get; set; } = 1;
}