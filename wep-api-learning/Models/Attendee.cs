namespace wep_api_learning.Models;

using System;

public class Attendee
{
    public long Id { get; set; }
    public long? EventId { get; set; }
    public SocialEvent? SocialEvent { get; set; }
    public AttendanceStatus Status { get; set; } = AttendanceStatus.Pending;
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    

    public enum AttendanceStatus
    {
        Confirmed,
        Pending,
        Declined
    }
}
