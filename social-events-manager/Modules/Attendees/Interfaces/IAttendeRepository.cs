using social_events_manager.Modules.Attendees.Models;

namespace social_events_manager.Modules.Attendees.Interfaces;

public interface IAttendeeRepository
{
    Task<List<Attendee>> FindAttendees();
    Task<List<Attendee>> FindAttendeesPaginated(int limit, int offset);
    Task<Attendee?> FindAttendeeById(long id);
    Task<Attendee> SaveAttendee(Attendee attendee);
    Task<Attendee?> UpdateAttendee(Attendee attendee);
    Task<Attendee?> DeleteAttendee(long id);
    Task<bool> ExistsAttendee(long id);
    Task<int> CountAttendees();
}
