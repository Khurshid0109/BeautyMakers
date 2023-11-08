using Microsoft.AspNetCore.Http;
using BeautyMakers.Domain.Entities;

namespace BeautyMakers.Services.DTOs.Salons;
public class SalonForUpdateDto
{
    public long OwnerId { get; set; }
    public BeautyProfessional Owner { get; set; }
    public string SalonName { get; set; }
    public string Location { get; set; }
    public IFormFile? SalonImg { get; set; }
}
