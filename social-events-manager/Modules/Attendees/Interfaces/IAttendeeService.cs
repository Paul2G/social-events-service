using social_events_manager.Modules.Attendees.DTOs;
using social_events_manager.Modules.Shared.DTOs;

namespace social_events_manager.Modules.Attendees.Interfaces;

public interface IAttendeeService
{
    Task<List<ReadAttendeeDto>> GetAllAsync();
    Task<PaginatedListDto<ReadAttendeeDto>> GetAllPaginatedAsync(
        PaginationQueryDto paginationQueryDto
    );
    Task<ReadAttendeeDto> GetByIdAsync(long id);
    Task<ReadAttendeeDto> CreateAsync(CreateAttendeeDto attendeeDto);
    Task<ReadAttendeeDto> UpdateAsync(long id, UpdateAttendeeDto attendeeDto);
    Task<ReadAttendeeDto> DeleteAsync(long id);
}
