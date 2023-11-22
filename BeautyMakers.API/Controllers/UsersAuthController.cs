using Microsoft.AspNetCore.Mvc;
using BeautyMakers.Services.DTOs.Users;
using BeautyMakers.Services.Interfaces.Users;

namespace BeautyMakers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public UsersAuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> PostAsync(LoginDto dto) =>
            Ok(await _service.AuthenticateAsync(dto));
    }
}
