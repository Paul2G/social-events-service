using social_events_manager.Modules.Shared.DTOs;
using social_events_manager.Modules.SocialEvents.DTOs;

namespace social_events_manager.Modules.SocialEvents.Interfaces;

public interface ISocialEventService
{
    Task<List<ReadSocialEventDto>> GetAllAsync();
    Task<PaginatedListDto<ReadSocialEventDto>> GetAllPaginatedAsync(
        PaginationQueryDto paginationQueryDto
    );
    Task<ReadSocialEventDto> GetByIdAsync(long id);

    Task<ReadSocialEventDto> CreateAsync(CreateSocialEventDto socialEventDto);

    Task<ReadSocialEventDto> UpdateAsync(long id, UpdateSocialEventDto socialEventDto);

    Task<ReadSocialEventDto> DeleteAsync(long id);
}
