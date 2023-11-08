using Microsoft.AspNetCore.Http;

namespace BeautyMakers.Services.DTOs.Salons;
public class SalonForCreationDto
{
    public long OwnerId { get; set; }
    public string SalonName { get; set; }
    public string Location { get; set; }
    public IFormFile SalonImg { get; set; }
}
