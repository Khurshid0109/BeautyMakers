using BeautyMakers.Services.Configurations;
using BeautyMakers.Services.DTOs.BeautyProfessionals;

namespace BeautyMakers.Services.Interfaces.BeautyProfessionals;
public interface IBeautyProfessionalService
{
    Task<bool> RemoveAsync(long id);
    Task<BeautyProfessionalForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<BeautyProfessionalForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<BeautyProfessionalForResultDto> AddAsync(BeautyProfessionalForCreationDto dto);
    Task<BeautyProfessionalForResultDto> RetrieveByEmailAsync(string email);
    Task<BeautyProfessionalForResultDto> ModifyAsync(long id, BeautyProfessionalForUpdateDto dto);
}
