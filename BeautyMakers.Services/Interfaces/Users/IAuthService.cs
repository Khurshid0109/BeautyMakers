using BeautyMakers.Services.DTOs.Users;

namespace BeautyMakers.Services.Interfaces.Users;
public interface IAuthService
{
    public Task<LoginResultDto> AuthenticateAsync(LoginDto login);
}
