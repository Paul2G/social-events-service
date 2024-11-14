﻿namespace web_api_learning.Modules.SocialEvents.DTOs;

public class CreateSocialEventDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}