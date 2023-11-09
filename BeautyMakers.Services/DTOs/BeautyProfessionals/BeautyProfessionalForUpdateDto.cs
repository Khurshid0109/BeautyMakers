using BeautyMakers.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace BeautyMakers.Services.DTOs.BeautyProfessionals;
public class BeautyProfessionalForUpdateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }
    public string Description { get; set; }
    public long SalonId { get; set; }
    public string Experience { get; set; }
    public IFormFile? ProfessionalImg { get; set; }
}
