namespace wep_api_learning.Models;

using System;

public class Attendee
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long EventId { get; set; }
    public string Status { get; set; } = "pending";
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    
    // Optional: Enum for status, if preferred for type safety
    public enum AttendanceStatus
    {
        Confirmed,
        Pending,
        Declined
    }
}
