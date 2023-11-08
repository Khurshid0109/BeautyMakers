using BeautyMakers.Data.Data;
using BeautyMakers.Domain.Entities;
using BeautyMakers.Data.IRepositories;

namespace BeautyMakers.Data.Repositories;
public class PastWorksRepository : Repository<PastWork>, IPastWorksRepository
{
    public PastWorksRepository(DataContext context) : base(context)
    {
    }
}
