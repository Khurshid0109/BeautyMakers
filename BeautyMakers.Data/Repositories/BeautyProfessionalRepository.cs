using BeautyMakers.Data.Data;
using BeautyMakers.Domain.Entities;
using BeautyMakers.Data.IRepositories;

namespace BeautyMakers.Data.Repositories;
public class BeautyProfessionalRepository : Repository<BeautyProfessional>, IBeautyProfessionalRepository
{
    public BeautyProfessionalRepository(DataContext context) : base(context)
    {
    }
}
