using social_events_manager.Modules.Attendees.Models;

namespace social_events_manager.Modules.Attendees.Interfaces;

public interface IAttendeeRepository
{
    Task<List<Attendee>> FindUserAttendees(string userId);
    Task<Attendee?> FindUserAttendeeById(string userId, long id);
    Task<Attendee> SaveUserAttendee(string userId, Attendee attendee);
    Task<Attendee?> UpdateUserAttendee(string userId, Attendee attendee);
    Task<Attendee?> DeleteUserAttendee(string userId, long id);
    Task<bool> ExistsUserAttendee(string userId, long id);
}
