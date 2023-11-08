using BeautyMakers.Services.Configurations;
using BeautyMakers.Services.DTOs.Appoinments;

namespace BeautyMakers.Services.Interfaces.Appoinments;
public interface IAppointmentService
{
    Task<bool> RemoveAsync(long id);
    Task<AppointmentForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<AppointmentForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<AppointmentForResultDto> AddAsync(AppointmentForCreationDto dto);
    Task<AppointmentForResultDto> ModifyAsync(long id, AppointmentForUpdateDto dto);
}
