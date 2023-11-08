﻿using BeautyMakers.Domain.Enums;
using BeautyMakers.Services.Helpers.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace BeautyMakers.Services.DTOs.Users;
public class UserForCreationDto
{
    [Required]
    [MinLength(5),MaxLength(20)]
    public string Name { get; set; }

    [Required]
    [EmailValidation(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public Gender Gender { get; set; }
}
