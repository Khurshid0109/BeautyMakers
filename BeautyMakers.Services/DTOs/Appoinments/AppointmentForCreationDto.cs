using BeautyMakers.Domain.Enums;
using BeautyMakers.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BeautyMakers.Services.DTOs.Appoinments;
public class AppointmentForCreationDto
{
    [Required]
    public long CustomerId { get; set; }

    [Required]
    public long BeautyProfessionalId { get; set; }
    public DateTime Date { get; set; }

    [Required]
    public AppointmentStatus Status { get; set; }

    [Required]
    public decimal Price { get; set; }
   
}
