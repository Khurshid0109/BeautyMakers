using BeautyMakers.Domain.Entities;

namespace BeautyMakers.Services.DTOs.AppoinmentResults;
public class AppointmentResultForCreationDto
{
    public long AppointmentId { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}
