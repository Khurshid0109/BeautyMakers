using BeautyMakers.Services.Configurations;
using BeautyMakers.Services.DTOs.AppoinmentResults;

namespace BeautyMakers.Services.Interfaces.AppoinmentResults;
public interface IAppointmentResultService
{
    Task<bool> RemoveAsync(long id);
    Task<AppointmentResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<AppointmentResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<AppointmentResultDto> AddAsync(AppointmentResultForCreationDto dto);
    Task<AppointmentResultDto> ModifyAsync(long id, AppointmentResultForUpdateDto dto);
}
