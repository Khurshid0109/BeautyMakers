using BeautyMakers.Domain.Enums;

namespace BeautyMakers.Services.DTOs.BeautyProfessionals;
public class BeautyProfessionalForCreationDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }
    public string Description { get; set; }
    public string Experience { get; set; }
}
