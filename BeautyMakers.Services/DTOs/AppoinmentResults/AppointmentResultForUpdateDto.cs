using BeautyMakers.Domain.Entities;

namespace BeautyMakers.Services.DTOs.AppoinmentResults;
public class AppointmentResultForUpdateDto
{
    public long AppointmentId { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}
