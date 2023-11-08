using Microsoft.AspNetCore.Mvc;
using BeautyMakers.Services.DTOs.Appoinments;
using BeautyMakers.Services.Interfaces.PastWorks;
using BeautyMakers.Services.DTOs.PastWorks;

namespace BeautyMakers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PastWorksController : ControllerBase
    {
        private readonly IPastWorkService _service;

        public PastWorksController(IPastWorkService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] PastWorkForCreationDto dto) =>
       Ok(await _service.AddAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() =>
           Ok(await _service.RetrieveAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id) =>
            Ok(await _service.RetrieveByIdAsync(id));


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] PastWorkForUpdateDto dto) =>
            Ok(await _service.ModifyAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id) =>
            Ok(await _service.RemoveAsync(id));
    }
}
