using Microsoft.AspNetCore.Mvc;
using BeautyMakers.Services.DTOs.BeautyProfessionals;
using BeautyMakers.Services.Interfaces.BeautyProfessionals;

namespace BeautyMakers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeautyProfessionalsController : ControllerBase
    {
        private readonly IBeautyProfessionalService _service;

        public BeautyProfessionalsController(IBeautyProfessionalService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] BeautyProfessionalForCreationDto dto) =>
           Ok(await _service.AddAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() =>
           Ok(await _service.RetrieveAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id) =>
            Ok(await _service.RetrieveByIdAsync(id));

        [HttpGet("email")]
        public async Task<IActionResult> GetByEmailAsync(string email) =>
            Ok(await _service.RetrieveByEmailAsync(email));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] BeautyProfessionalForUpdateDto dto) =>
            Ok(await _service.ModifyAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id) =>
            Ok(await _service.RemoveAsync(id));
    }
}
