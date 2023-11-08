using Microsoft.AspNetCore.Mvc;
using BeautyMakers.Services.DTOs.Appoinments;
using BeautyMakers.Services.Interfaces.Appoinments;

namespace BeautyMakers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AppointmentForCreationDto dto) =>
         Ok(await _service.AddAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() =>
           Ok(await _service.RetrieveAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id) =>
            Ok(await _service.RetrieveByIdAsync(id));


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] AppointmentForUpdateDto dto) =>
            Ok(await _service.ModifyAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id) =>
            Ok(await _service.RemoveAsync(id));
    }
}
