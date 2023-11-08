using BeautyMakers.Domain.Commons;

namespace BeautyMakers.Domain.Entities;
public class AppointmentResult:Auditable
{
    public long AppointmentId { get; set; }
    public Appointment Appointment { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
