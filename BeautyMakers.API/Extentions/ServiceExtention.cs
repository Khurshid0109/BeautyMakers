using BeautyMakers.Data.Repositories;
using BeautyMakers.Data.IRepositories;
using BeautyMakers.Services.Services.Users;
using BeautyMakers.Services.Services.Salons;
using BeautyMakers.Services.Interfaces.Users;
using BeautyMakers.Services.Interfaces.Salons;

namespace BeautyMakers.API.Extentions;
public static class ServiceExtention 
{
    public static void CustomExtention(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<ISalonRepository, SalonRepository>();
        services.AddScoped<ISalonService, SalonService>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IPastWorksRepository, PastWorksRepository>();

        services.AddScoped<IBeautyProfessionalRepository, BeautyProfessionalRepository>();

        services.AddScoped<IAppointmentResultRepository, AppointmentResultRepository>();

        services.AddScoped<IAppointmentRepository,AppointmentRepository>();

    }
}
