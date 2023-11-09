using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BeautyMakers.Services.DTOs.Salons;
public class SalonForUpdateDto
{

    [Required]
    [MinLength(5)]
    public string SalonName { get; set; }

    [Required]
    [MinLength(10)]
    public string Location { get; set; }

    [Required]
    public IFormFile? SalonImg { get; set; }
}
