using BeautyMakers.Domain.Enums;
using BeautyMakers.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BeautyMakers.Services.DTOs.Appoinments;
public class AppointmentForUpdateDto
{
    [Required]
    public long CustomerId { get; set; }

    [Required]
    public long BeautyProfessionalId { get; set; }

    [Required]
    public AppointmentResult AppointmentService { get; set; }
    public DateTime Date { get; set; }
    public AppointmentStatus Status { get; set; }
    public decimal Price { get; set; }
 
}
