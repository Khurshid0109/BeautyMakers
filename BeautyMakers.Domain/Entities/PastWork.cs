using BeautyMakers.Domain.Commons;

namespace BeautyMakers.Domain.Entities;
public class PastWork:Auditable
{
    public long BeautyProfessionalId { get; set; }
    public BeautyProfessional BeautyProfessional { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
