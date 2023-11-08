using BeautyMakers.Data.Data;
using BeautyMakers.Domain.Entities;
using BeautyMakers.Data.IRepositories;

namespace BeautyMakers.Data.Repositories;
public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(DataContext context) : base(context)
    {
    }
}
