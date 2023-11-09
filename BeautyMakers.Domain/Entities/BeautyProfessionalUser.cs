using BeautyMakers.Domain.Commons;

namespace BeautyMakers.Domain.Entities;
public class BeautyProfessionalUser:Auditable
{
    public long BeautyProfessionalId { get; set; }
    public BeautyProfessional BeautyProfessional { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
