using BeautyMakers.Services.DTOs.PastWorks;

namespace BeautyMakers.Services.Interfaces.PastWorks;
public interface IPastWorkService
{
    Task<bool> RemoveAsync(long id);
    Task<PastWorkForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<PastWorkForResultDto>> RetrieveAllAsync();
    Task<PastWorkForResultDto> AddAsync(PastWorkForCreationDto dto);
    Task<PastWorkForResultDto> ModifyAsync(long id, PastWorkForUpdateDto dto);
}
