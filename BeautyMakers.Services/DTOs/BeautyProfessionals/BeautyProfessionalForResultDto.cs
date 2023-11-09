using BeautyMakers.Domain.Entities;
using BeautyMakers.Domain.Enums;
using BeautyMakers.Services.DTOs.Salons;

namespace BeautyMakers.Services.DTOs.BeautyProfessionals;
public class BeautyProfessionalForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }
    public string Description { get; set; }
    public SalonForResultDto Salon { get; set; }
    public string Experience { get; set; }
    public string ProfessionalImg { get; set; }
}