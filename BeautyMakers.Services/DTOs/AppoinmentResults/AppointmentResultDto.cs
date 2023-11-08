using BeautyMakers.Domain.Entities;
using BeautyMakers.Services.DTOs.Appoinments;

namespace BeautyMakers.Services.DTOs.AppoinmentResults;
public class AppointmentResultDto
{
    public long Id { get; set; }
    public long AppointmentId { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}
