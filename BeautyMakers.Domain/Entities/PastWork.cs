using BeautyMakers.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyMakers.Domain.Entities;
public class PastWork:Auditable
{
    [ForeignKey("BeautyProfessional")]
    public long BeautyProfessionalId { get; set; }
    public BeautyProfessional BeautyProfessional { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
