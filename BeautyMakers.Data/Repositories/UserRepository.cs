using BeautyMakers.Data.Data;
using BeautyMakers.Domain.Entities;
using BeautyMakers.Data.IRepositories;

namespace BeautyMakers.Data.Repositories;
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }
}
