using BeautyMakers.Data.Data;
using BeautyMakers.Data.IRepositories;
using BeautyMakers.Domain.Entities;

namespace BeautyMakers.Data.Repositories;
public class SalonRepository : Repository<Salon>, ISalonRepository
{
    public SalonRepository(DataContext context) : base(context)
    {
    }
}

