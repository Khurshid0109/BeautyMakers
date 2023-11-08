using BeautyMakers.Domain.Entities;

namespace BeautyMakers.Services.DTOs.PastWorks;
public class PastWorkForResultDto
{
    public long Id { get; set; }
    public long BeautyProfessionalId { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
