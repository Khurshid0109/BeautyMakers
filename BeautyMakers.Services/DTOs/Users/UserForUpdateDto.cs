using BeautyMakers.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using BeautyMakers.Services.Helpers.CustomAttributes;
using Microsoft.AspNetCore.Http;

namespace BeautyMakers.Services.DTOs.Users;
public class UserForUpdateDto
{

    [Required]
    [MinLength(5), MaxLength(20)]
    public string Name { get; set; }

    [Required]
    [EmailValidation(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required]
    public string Phone { get; set; }

    public Gender Gender { get; set; }

    public IFormFile? UserImg { get; set; }
}
