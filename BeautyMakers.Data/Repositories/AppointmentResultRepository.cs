using BeautyMakers.Data.Data;
using BeautyMakers.Domain.Entities;
using BeautyMakers.Data.IRepositories;

namespace BeautyMakers.Data.Repositories;
public class AppointmentResultRepository : Repository<AppointmentResult>, IAppointmentResultRepository
{
    public AppointmentResultRepository(DataContext context) : base(context)
    {
    }
}
