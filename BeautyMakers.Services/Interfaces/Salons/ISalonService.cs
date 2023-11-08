using BeautyMakers.Services.Configurations;
using BeautyMakers.Services.DTOs.Salons;

namespace BeautyMakers.Services.Interfaces.Salons;
public interface ISalonService
{
    Task<bool> RemoveAsync(long id);
    Task<SalonForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<SalonForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<SalonForResultDto> AddAsync(SalonForCreationDto dto);
    Task<SalonForResultDto> ModifyAsync(long id, SalonForUpdateDto dto);
}
