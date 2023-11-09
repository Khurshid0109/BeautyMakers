using BeautyMakers.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BeautyMakers.Services.DTOs.Appoinments;
public class AppointmentForUpdateDto
{
    [Required]
    public long CustomerId { get; set; }

    [Required]
    public long BeautyProfessionalId { get; set; }

    public DateTime Date { get; set; }

    [Required]
    public AppointmentStatus Status { get; set; }
    public decimal Price { get; set; }
 
}
