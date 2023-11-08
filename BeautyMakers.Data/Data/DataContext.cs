using BeautyMakers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeautyMakers.Data.Data;
public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Salon> Salons { get; set; }
    public DbSet<PastWork> PastWorks { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<BeautyProfessional> BeautyProfessionals { get; set; }
    public DbSet<AppointmentResult> AppointmentServices { get; set; }
}
