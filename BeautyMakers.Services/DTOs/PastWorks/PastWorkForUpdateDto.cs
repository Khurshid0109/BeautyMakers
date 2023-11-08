using BeautyMakers.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace BeautyMakers.Services.DTOs.PastWorks;
public class PastWorkForUpdateDto
{
    public long BeautyProfessionalId { get; set; }
    public string Description { get; set; }
    public IFormFile ImageUrl { get; set; }
}
