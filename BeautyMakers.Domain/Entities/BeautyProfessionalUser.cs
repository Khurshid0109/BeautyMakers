using BeautyMakers.Domain.Commons;

namespace BeautyMakers.Domain.Entities;
public class BeautyProfessionalUser:Auditable
{
    public int BeautyProfessionalId { get; set; }
    public BeautyProfessional BeautyProfessional { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}
