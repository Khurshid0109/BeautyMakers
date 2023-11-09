using BeautyMakers.Domain.Commons;

namespace BeautyMakers.Domain.Entities;
public class Salon:Auditable
{
    public string SalonName { get; set; }
    public string Location { get; set; }
    public string SalonImg { get; set; }
    public List<BeautyProfessional> Professionals { get; set; }
}
