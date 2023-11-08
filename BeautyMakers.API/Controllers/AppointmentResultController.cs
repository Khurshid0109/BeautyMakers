using Microsoft.AspNetCore.Mvc;
using BeautyMakers.Services.Configurations;
using BeautyMakers.Services.DTOs.AppoinmentResults;
using BeautyMakers.Services.Interfaces.AppoinmentResults;

namespace BeautyMakers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentResultController : ControllerBase
    {
        private readonly IAppointmentResultService _service;

        public AppointmentResultController(IAppointmentResultService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AppointmentResultForCreationDto dto) =>
         Ok(await _service.AddAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params) =>
           Ok(await _service.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id) =>
            Ok(await _service.RetrieveByIdAsync(id));


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] AppointmentResultForUpdateDto dto) =>
            Ok(await _service.ModifyAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id) =>
            Ok(await _service.RemoveAsync(id));
    }
}
