using web_api_learning.Modules.Attendees.DTOs;
using web_api_learning.Modules.Attendees.Models;
using web_api_learning.Modules.Auth.Models;

namespace web_api_learning.Modules.Attendees.Interfaces;

public interface IAttendeeRepository
{
    Task<List<Attendee>> GetAllAsync(AppUser appUser);
    Task<Attendee?> GetByIdAsync(AppUser appUser, long id);
    Task<Attendee> CreateAsync(AppUser appUser, CreateAttendeeDto attendeeDto);
    Task<Attendee?> UpdateAsync(AppUser appUser, long id, UpdateAttendeeDto attendeeDto);
    Task<Attendee?> DeleteAsync(AppUser appUser, long id);
    Task<bool> ExistsAsync(AppUser appUser, long id);
}