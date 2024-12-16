using social_events_manager.Modules.Attendees.DTOs;
using social_events_manager.Modules.Attendees.Models;
using social_events_manager.Modules.Auth.Models;

namespace social_events_manager.Modules.Attendees.Interfaces;

public interface IAttendeeRepository
{
    Task<List<Attendee>> GetAllAsync(AppUser appUser);
    Task<Attendee?> GetByIdAsync(AppUser appUser, long id);
    Task<Attendee> CreateAsync(AppUser appUser, CreateAttendeeDto attendeeDto);
    Task<Attendee?> UpdateAsync(AppUser appUser, long id, UpdateAttendeeDto attendeeDto);
    Task<Attendee?> DeleteAsync(AppUser appUser, long id);
    Task<bool> ExistsAsync(AppUser appUser, long id);
}