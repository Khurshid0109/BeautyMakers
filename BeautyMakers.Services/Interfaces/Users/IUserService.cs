using BeautyMakers.Services.Configurations;
using BeautyMakers.Services.DTOs.Users;

namespace BeautyMakers.Services.Interfaces.Users;
public interface IUserService
{
    Task<bool> RemoveAsync(long id);
    Task<UserForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<UserForResultDto> RetrieveByEmailAsync(string email);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
}
