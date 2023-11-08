using BeautyMakers.Domain.Enums;
using BeautyMakers.Domain.Commons;

namespace BeautyMakers.Domain.Entities;
public class User:Auditable
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }
    public List<Appointment> Appointments { get; set; }
    public List<BeautyProfessional> BeautyProfessionals { get; set; }
}
