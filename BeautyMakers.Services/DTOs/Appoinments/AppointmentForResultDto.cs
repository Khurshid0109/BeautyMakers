using BeautyMakers.Domain.Enums;
using BeautyMakers.Domain.Entities;

namespace BeautyMakers.Services.DTOs.Appoinments;
public class AppointmentForResultDto
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public long BeautyProfessionalId { get; set; }
    public AppointmentResult AppointmentService { get; set; }
    public DateTime Date { get; set; }
    public AppointmentStatus Status { get; set; }
    public decimal Price { get; set; }
}
