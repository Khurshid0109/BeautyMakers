using Microsoft.AspNetCore.Mvc;
using BeautyMakers.Services.DTOs.Users;
using BeautyMakers.Services.Configurations;
using BeautyMakers.Services.Interfaces.Users;

namespace BeautyMakers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] UserForCreationDto dto) =>
           Ok(await _service.AddAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params) =>
           Ok(await _service.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)=>
            Ok(await _service.RetrieveByIdAsync(id));

        [HttpGet("email")]
        public async Task<IActionResult> GetByEmailAsync(string email) =>
            Ok(await _service.RetrieveByEmailAsync(email));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromForm] UserForUpdateDto dto) =>
            Ok(await _service.ModifyAsync(id,dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]long id) =>
            Ok(await _service.RemoveAsync(id));
    }
}
