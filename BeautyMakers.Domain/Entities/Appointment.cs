using BeautyMakers.Domain.Enums;
using BeautyMakers.Domain.Commons;

namespace BeautyMakers.Domain.Entities;
public class Appointment:Auditable
{
    public long CustomerId { get; set; }
    public User Customer { get; set; }
    public long BeautyProfessionalId { get; set; }
    public BeautyProfessional BeautyProfessional { get; set; }
    public AppointmentResult AppointmentService { get; set; }
    public DateTime Date { get; set; }
    public AppointmentStatus Status { get; set; }
    public decimal Price { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
   
}
