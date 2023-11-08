using BeautyMakers.Domain.Commons;

namespace BeautyMakers.Domain.Entities;
public class Salon:Auditable
{
    public long OwnerId { get; set; }
    public BeautyProfessional Owner { get; set; }
    public string SalonName { get; set; }
    public string Location { get; set; }
    public string SalonImg { get; set; }
}
